using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDoor : MonoBehaviour
{
    public LockedDoor lockedDoor;

    private IEnumerator PressSwitch()
    {
        yield return new WaitForSeconds(10f);
        lockedDoor.OpenDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(PressSwitch());
        Destroy(gameObject, 10.2f);
    }
}
