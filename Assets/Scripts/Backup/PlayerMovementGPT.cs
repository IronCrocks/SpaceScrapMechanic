using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGPT : MonoBehaviour
{
    public float speed = 5f; // Скорость движения персонажа
    public float rotateSpeed = 5f; // Скорость поворота персонажа
    public GameObject onDestroyEffect;

    private Rigidbody2D rb;
    private Vector2 destination; // Координаты точки назначения
    private Vector2 direction; // Координаты точки назначения
    private bool _isMooving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        destination = transform.position; // Начальная точка назначения - текущая позиция персонажа
        direction = (Vector2)transform.right; // Получаем направление движения персонажа

    }

    void FixedUpdate()
    {
        Vector2 direction = destination - (Vector2)transform.position; // Вычисляем направление движения к точке назначения
        var len = direction;
        //if (direction.magnitude > 0.1f) // Если расстояние между текущей позицией и точкой назначения больше, чем 0.1, то двигаемся
        if (_isMooving)
        {
            direction = direction.normalized; // Нормализуем вектор направления, чтобы скорость была постоянной

            rb.velocity = (Vector2)transform.right.normalized * speed; // Применяем вектор движения к Rigidbody2D

            // Постепенно меняем ориентацию персонажа в сторону точки назначения
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float rotation = Mathf.MoveTowardsAngle(transform.eulerAngles.z, angle, rotateSpeed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }
        else // Если расстояние между текущей позицией и точкой назначения меньше или равно 0.1, то стоим на месте
        {
            rb.velocity = Vector2.zero;
        }
        //var offset = (Vector2)transform.position - destination;
        if (len.magnitude < 0.1f)
        {
            _isMooving = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // Если нажата левая кнопка мыши
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Получаем координаты мыши в мировых координатах

            destination = mousePosition; // Устанавливаем новую точку назначения
            _isMooving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //  в чем разница между тригерентер и коллизионЕнтер. разница коолидер и коллизион(сигнатуры?)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Instantiate(onDestroyEffect, transform.position, Quaternion.identity);
            Destroy(transform.gameObject);
        }
    }
}