//Code taken from https://generalistprogrammer.com/tutorials/unity-2d-how-to-make-camera-follow-player

using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xMin = mapBounds.bounds.min.x;
        xMax = mapBounds.bounds.max.x;
        yMin = mapBounds.bounds.min.y;
        yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camX, camY, this.transform.position.z), smoothSpeed);

        this.transform.position = smoothPos;
    }
}
