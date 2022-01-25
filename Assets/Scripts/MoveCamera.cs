using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Camera;

    private List<Vector3> positions = new List<Vector3>();
    private List<Vector3> rotations = new List<Vector3>();

    private static int index = 1;

    private void Start()
    {
        positions.Add(new Vector3(-4.2f, 3.8f, -3.5f));
        rotations.Add(new Vector3(15.2f, 62.8f, 0));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        positions.Add(new Vector3(-3.05f, 10.14f, -7.07f));
        rotations.Add(new Vector3(27f, 26.3f, 6.4f));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        Camera.transform.localPosition = positions[0];
        Camera.transform.eulerAngles = rotations[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        LeanTween.moveLocal(Camera, positions[index], 1.5f);
        LeanTween.rotateLocal(Camera, rotations[index], 1.5f);
        Destroy(gameObject, 1.6f);
        index += 1;
    }
}
