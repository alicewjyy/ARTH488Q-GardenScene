using UnityEngine;

public class Bird : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanInteract()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        if (!CanInteract()) return;

        Debug.Log("E was pressed");
    }
}
