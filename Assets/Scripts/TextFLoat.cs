using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 5f;    
    public float floatHeight = 0.5f;  

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = startPos + new Vector3(0, newY, 0);
    }
}