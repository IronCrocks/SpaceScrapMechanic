using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject projectile;
    public float distance = 0.2f;
    public float fireRate = 0.5f;
    public float speed = 12f;

    private float delay = 1;
    private AudioSource shotAudioSource;

    void Start()
    {
        shotAudioSource = gameObject.GetComponent<AudioSource>();
        InvokeRepeating(nameof(SpawnProjectile), 2, delay - fireRate);
    }

    void SpawnProjectile()
    {
        // Создаем новый объект
        GameObject newObject = Instantiate(projectile);

        if (shotAudioSource != null)
        {
            shotAudioSource.Play();
        }

        // Вычисляем позицию нового объекта
        Vector3 newPosition = transform.position + transform.up * distance;
        newPosition.z -= 6;
        // Изменяем позицию нового объекта
        newObject.transform.SetPositionAndRotation(newPosition, transform.rotation);

        var rb = newObject.GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        rb.velocity = (Vector2)newObject.transform.up.normalized * speed;

        var script = newObject.GetComponent<Projectile>();
    }

    public void RestartShooting(float deltaFireRate)
    {
        fireRate += deltaFireRate;
        CancelInvoke(nameof(SpawnProjectile));
        InvokeRepeating(nameof(SpawnProjectile),0, delay - fireRate);
    }
}