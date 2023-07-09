using UnityEngine;

public class PixelDensityCamera : MonoBehaviour
{
    public float pixelsToUnit = 100;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Update()
    {
        _camera.orthographicSize = Screen.height / pixelsToUnit / 2;
    }
}
