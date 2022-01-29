using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Camera;

    private List<Vector3> positions = new List<Vector3>();
    private List<Vector3> rotations = new List<Vector3>();

    private static int index = 0;

    private void Start()
    {
        Camera = GameObject.Find("Main Camera");

        positions.Add(new Vector3(-4.2f, 3.8f, -3.5f));
        rotations.Add(new Vector3(15.2f, 62.8f, 0));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        positions.Add(new Vector3(-3.05f, 10.14f, -7.07f));
        rotations.Add(new Vector3(27f, 26.3f, 6.4f));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        positions.Add(new Vector3(0.5f, 17.92f, -4.94f));
        rotations.Add(new Vector3(65.47f, 0, 0));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        positions.Add(new Vector3(-9.39f, 4.35f, -0.63f));
        rotations.Add(new Vector3(14.47f, 75.1f, 0));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        positions.Add(new Vector3(8.75f, 23.86f, -0.63f));
        rotations.Add(new Vector3(90f, 0, 0));

        positions.Add(new Vector3(0, 3.3f, -7.4f));
        rotations.Add(new Vector3(20.8f, 0, 0));

        Camera.transform.localPosition = positions[index];
        Camera.transform.eulerAngles = rotations[index];
    }

    private void OnTriggerEnter(Collider other)
    {
        index += 1;
        LeanTween.moveLocal(Camera, positions[index], 1.5f);
        LeanTween.rotateLocal(Camera, rotations[index], 1.5f);
        Destroy(gameObject, 1.6f);
    }
}
