using UnityEngine;

public class ScaleWidthCamera : MonoBehaviour
{
    public int targetWidth = 640;
    public int pixelsToUnits = 35;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
        _camera.orthographicSize = height / pixelsToUnits / 2;
    }
}
