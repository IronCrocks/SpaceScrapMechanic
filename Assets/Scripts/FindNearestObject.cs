using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestObject : MonoBehaviour
{
    public float radius = 30f;
    public LayerMask layerMask;

    void Update()
    {
        // Находим все объекты на указанном слое в заданном радиусе
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        // Находим ближайший объект и вычисляем направление на него
        GameObject nearestObject = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            float distance = Vector3.Distance(collider.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestObject = collider.gameObject;
            }
        }

        if (nearestObject != null)
        {
            Vector3 targetPosition = nearestObject.transform.position;
            Vector3 direction = Vector3.Normalize(targetPosition - transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}