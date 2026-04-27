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

    public Transform target;

    private Vector3 startPos;

    void Start()
    {
        cam = Camera.main;
        startSize = cam.orthographicSize;
        startPos = cam.transform.position;
    }

    void Update()
    {
        if (!zoom)
        {
            timer += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, timer / duration);

            cam.orthographicSize = Mathf.Lerp(startSize, targetSize, t);

            Vector3 targetPos = new Vector3(target.position.x, target.position.y, startPos.z);

            cam.transform.position = Vector3.Lerp(startPos, targetPos, t);

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