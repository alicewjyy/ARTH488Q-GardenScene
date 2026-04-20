using UnityEngine;

public class DialogueBarrier : MonoBehaviour
{
    public Collider2D barrierCollider;

    public void DisableBarrier()
    {
        barrierCollider.enabled = false;
    }
}