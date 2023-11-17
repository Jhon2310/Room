using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Door _door;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Open");
            if (Input.GetKeyDown(KeyCode.E))
            {
                _door.SwitchDoorState();
            }
        }
    }
}
