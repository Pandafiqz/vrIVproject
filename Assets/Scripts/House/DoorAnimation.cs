using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorAnimation : MonoBehaviour
{
    public ObjectInteraction objectInteraction;
    public Animator doorAnimator;
    public GameObject doorCanvas;
    private bool isDoor = false;

    private void Start()
    {
        doorCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("XROrigin"))
        {
            objectInteraction.GetComponent<ObjectInteraction>().objectInteractReference.action.performed += OnDoorInteract;
            doorCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectInteraction.GetComponent<ObjectInteraction>().objectInteractReference.action.performed -= OnDoorInteract;
        doorCanvas.SetActive(false);
    }

    private void OnDoorInteract(InputAction.CallbackContext obj)
    {
        isDoor = !isDoor;
        doorAnimator.SetBool("doorState", isDoor);
    }
}
