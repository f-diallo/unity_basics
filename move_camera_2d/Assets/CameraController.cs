using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float zoomSpeed = 2f;
    public float minZoom = 2f;
    public float maxZoom = 15f;
    public float panBorderThickness = 30f;
    public Vector2 panLimit;

    private void Update()
    {
        Vector3 pos = transform.position;
        Camera cam = Camera.current;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            pos.x = 0;
            pos.y = 0;
        }

        if (Input.GetKey(KeyCode.N))
        {
            //cam.orthographicSize += panSpeed * Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minZoom, zoomSpeed * Time.deltaTime);

        }
        
        if (Input.GetKey(KeyCode.M))
        {
            //cam.orthographicSize -= panSpeed * Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxZoom, zoomSpeed * Time.deltaTime);
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
          
        transform.position = pos;
    }
}
