using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;    // Ссылка на главного героя
    public float speed = 5f;    // Скорость движения объекта

    void Update()
    {
        // Проверяем, существует ли ссылка на главного героя
        if (player != null)
        {
            // Вычисляем направление движения объекта к главному герою
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            // Вычисляем угол между направлением вперед объекта и направлением к главному герою
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Создаем кватернион на основе углов Эйлера по оси Z
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle + 90);

            // Поворачиваем объект в направлении главного героя
            transform.rotation = targetRotation;

            // Двигаем объект в направлении главного героя
            transform.position += speed * Time.deltaTime * (Vector3)direction;
        }
    }
}