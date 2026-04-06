using UnityEngine;

public class CameraZoomIntro : MonoBehaviour
{
    public float targetSize = 5f;     
    public float duration = 3f;      
    public Animator flashAnimator;    

    private float startSize;
    private float timer = 0f;
    private Camera cam;
    private bool zoom = false;

    void Start()
    {
        cam = Camera.main;
        startSize = cam.orthographicSize;
    }

    void Update()
    {
        if (!zoom)
        {
            timer += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, timer / duration);

            cam.orthographicSize = Mathf.Lerp(startSize, targetSize, t);

            if (timer >= duration)
            {
                zoom = true;

                if (flashAnimator != null)
                {
                    flashAnimator.SetTrigger("White flash");
                }

            }
        }
    }
}