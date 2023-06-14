using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementByArrows : MonoBehaviour
{
    public float maxSpeed = 5f; // максимальная скорость персонажа
    public float acceleration = 1f; // ускорение при движении вперед
    public float deceleration = 2f; // замедление при движении назад
    public float rotationSpeed = 80f; // скорость поворота персонажа
    public GameObject onDestroyEffect;
    public GameObject onDestroySound;
    public int expirienceCount = 0;
    public Slider Slider;

    private float _currentSpeed = 0f; // текущая скорость персонажа
    private float _currentRotation = 0f; // текущий угол поворота персонажа
    private int maxExpCount = 10;

    private void Start()
    {
        Slider.maxValue = maxExpCount;

    }

    private void Update()
    {
        // Получаем ввод от игрока
        float horizontalInput = -Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Поворот персонажа
        _currentRotation += horizontalInput * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, _currentRotation);

        // Движение персонажа
        if (verticalInput > 0)
        {
            // Ускорение
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            // Замедление
            _currentSpeed = Mathf.MoveTowards(_currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Перемещение персонажа
        transform.Translate(_currentSpeed * Time.deltaTime * Vector3.up);

        CalculateExpCount();
    }

    private void OnTriggerEnter2D(Collider2D collision) //  в чем разница между тригерентер и коллизионЕнтер. разница коолидер и коллизион(сигнатуры?)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Instantiate(onDestroyEffect, transform.position, Quaternion.identity);
            Instantiate(onDestroySound, transform.position, Quaternion.identity);
            Destroy(transform.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Loot"))
        {
            Destroy(collision.gameObject);
            expirienceCount++;
        }
    }

    private void CalculateExpCount()
    {
        if (expirienceCount >= maxExpCount)
        {
            expirienceCount = 0;
        }

        Slider.value = expirienceCount;
    }
}