using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Code taken from https://youtu.be/MPP9GLp44Pc?si=nucm5euas3ogOoSF
public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; //Closest Interactable
    public GameObject interactionIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && interactableInRange != null){
            if (interactableInRange.CanInteract() || IsDialogueActive(interactableInRange))
            {
                interactableInRange?.Interact();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }
    }

    bool IsDialogueActive(IInteractable interactable)
    {
        if (interactable is NPC npc)
        {
            return npc.isDialogueActive;
        }
        return false;
    }

    void Update()
    {
        if (interactableInRange != null &&
            !interactableInRange.CanInteract() &&
            !IsDialogueActive(interactableInRange))
        {
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }      
    }
}
