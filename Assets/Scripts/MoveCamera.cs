using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Camera;

    private Vector3 firstPos = new Vector3(-4.2f, 3.8f, -3.5f);
    private Vector3 secondPos = new Vector3(0, 3.3f, -7.4f);

    private Vector3 firstRotation = new Vector3(15.2f, 62.8f, 0);
    private Vector3 secondRotation = new Vector3(20.8f, 0, 0);

    private void Start()
    {
        Camera.transform.localPosition = firstPos;
        Camera.transform.eulerAngles = firstRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Camera.transform.localPosition = secondPos;
        LeanTween.moveLocal(Camera, secondPos, 1.5f);
        //Camera.transform.eulerAngles = secondRotation;
        LeanTween.rotateLocal(Camera, secondRotation, 1.5f);
        Destroy(gameObject, 1.6f);
    }
}
