using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // префаб врага
    public GameObject player;
    public float spawnRadius = 20f; // радиус, в пределах которого создается враг
    public float spawnInterval = 1f; // интервал создания врагов

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Получаем случайную позицию вокруг персонажа
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)transform.position + randomDirection * spawnRadius;//Random.Range(spawnRadius, spawnRadius + spawnRadius);

        // Создаем врага на случайной позиции
        var enemyType = Random.Range(0, enemyPrefabs.Count - 1);
        var enemy = Instantiate(enemyPrefabs[enemyType], spawnPosition, Quaternion.identity);
        var enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.player = player.transform;
    }
}