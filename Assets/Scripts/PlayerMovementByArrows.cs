using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementByArrows : MonoBehaviour
{
    public float maxSpeed = 10f; // максимальная скорость персонажа
    public float acceleration = 5f; // ускорение при движении вперед
    public float deceleration = 5f; // замедление при движении назад
    public float rotationSpeed = 100f; // скорость поворота персонажа
    public GameObject onDestroyEffect;
    public int expirienceCount = 0;
    public Slider Slider;

    private float currentSpeed = 0f; // текущая скорость персонажа
    private float currentRotation = 0f; // текущий угол поворота персонажа
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
        currentRotation += horizontalInput * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);

        // Движение персонажа
        if (verticalInput > 0)
        {
            // Ускорение
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            // Замедление
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Перемещение персонажа
        transform.Translate(currentSpeed * Time.deltaTime * Vector3.up);

        CalculateExpCount();
    }

    private void OnTriggerEnter2D(Collider2D collision) //  в чем разница между тригерентер и коллизионЕнтер. разница коолидер и коллизион(сигнатуры?)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Instantiate(onDestroyEffect, transform.position, Quaternion.identity);
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