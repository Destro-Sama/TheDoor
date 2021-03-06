using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public TurnBackController turnBackCanvas;

    private Transform checkpoint;
    public int resets = 0;
    public int turnBackAttempts;

    private bool paused;
    private bool turningBack;

    public int inverseMultiplier = 1;

    public GameObject scene;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        transform.position = new Vector3(-2.72f, 2.11f, -0.54f);
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal") < 0 && turningBack == false)
            {
                turningBack = true;
                turnBackCanvas.Activate();
                return;
            }
            if (Input.GetAxisRaw("Horizontal") >= 0 && turningBack == true)
            {
                turningBack = false;
                turnBackCanvas.DeActivate();
                turnBackAttempts += 1;
            }
            moveDirection = new Vector3((Mathf.Abs(Input.GetAxis("Horizontal"))*inverseMultiplier), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if (paused == false && turningBack == false)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            Physics.SyncTransforms();
            characterController.Move(moveDirection * Time.deltaTime);
        }
        
        if (paused)
        {
            characterController.Move(Vector3.zero);
        }
    }

    public void SetCheckpoint(Transform cords)
    {
        checkpoint = cords;
    }

    public void GoToCheckpoint()
    {
        resets += 1;
        transform.position = checkpoint.position;
        inverseMultiplier = 1;
        Destroy(GameObject.Find("Objects"));
        Destroy(GameObject.Find("Objects(Clone)"));
        Instantiate(scene);
    }

    public void SetPause()
    {
        paused = paused == true ? false : true;
    }

    public void ChangeDirection()
    {
        inverseMultiplier = inverseMultiplier == 1 ? -1 : 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DontTouch")
        {
            GoToCheckpoint();
        }
    }
}
