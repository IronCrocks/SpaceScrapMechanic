using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    public float distance = 0.2f;
    public float delay = 0.5f;
    public float speed = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPrefab), 0, delay);
    }

    void SpawnPrefab()
    {
        // Создаем новый объект
        GameObject newObject = Instantiate(prefab);

        // Вычисляем позицию нового объекта
        Vector3 newPosition = transform.position + transform.up * distance;
        newPosition.z -= 6;
        // Изменяем позицию нового объекта
        newObject.transform.position = newPosition;
        newObject.transform.rotation = transform.rotation;


        var rb = newObject.GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        rb.velocity = (Vector2)newObject.transform.up.normalized * speed;

        var script = newObject.GetComponent<Projectile>();
        script.firing_ship = player;
    }
}