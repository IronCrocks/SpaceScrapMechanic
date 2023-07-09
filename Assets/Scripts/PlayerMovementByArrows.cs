using UnityEngine;

public class PlayerMovementByArrows : MonoBehaviour
{
    public float maxSpeed = 5f; // максимальная скорость персонажа
    public float acceleration = 1f; // ускорение при движении вперед
    public float deceleration = 2f; // замедление при движении назад
    public float rotationSpeed = 80f; // скорость поворота персонажа
    public ParticleSystem starStream;

    private float _currentSpeed = 0f; // текущая скорость персонажа
    private float _currentRotation = 0f; // текущий угол поворота персонажа

    private void Update()
    {
        // Получаем ввод от игрока
        float horizontalInput = -Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        float deltaRotation = _currentRotation;
        // Поворот персонажа
        _currentRotation += horizontalInput * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, _currentRotation);

        if (_currentRotation != deltaRotation)
        {
            starStream.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
            starStream.Play();
        }

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

        if (_currentSpeed == 0 && starStream.isPlaying)
        {
            starStream.Stop();
            return;
        }
        if (starStream.isStopped)
        {
            starStream.Play();
        }

        var main = starStream.main;
        main.startSpeed = _currentSpeed * 1.5f;

        // Перемещение персонажа
        transform.Translate(_currentSpeed * Time.deltaTime * Vector3.up);
    }
}