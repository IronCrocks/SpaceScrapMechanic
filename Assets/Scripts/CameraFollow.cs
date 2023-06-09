using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // объект, за которым следует камера
    public float smoothSpeed = 0.125f; // скорость следования камеры

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position; // новая позиция камеры
        desiredPosition.z = transform.position.z;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // плавное следование камеры
        transform.position = desiredPosition; // применяем новую позицию камеры
    }
}