using System;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float targetScreenHeight = 1920f;
    public float targetScreenWidth = 1920f;

    private Camera _camera;
    private float _defaultSize;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _defaultSize = _camera.orthographicSize;
    }

    private void Start()
    {
        float targetScreenRatio = targetScreenWidth / targetScreenHeight;
        float currentScreenRatio = Screen.width / (float)Screen.height;

        if (currentScreenRatio < targetScreenRatio)
        {
            var ratio = Math.Round(targetScreenRatio / currentScreenRatio, 2);
            _camera.orthographicSize = _defaultSize * Convert.ToSingle(ratio);
        }
    }
}
