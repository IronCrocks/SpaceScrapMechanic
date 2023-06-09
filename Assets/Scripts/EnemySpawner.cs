using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // префаб врага
    public float spawnRadius = 40f; // радиус, в пределах которого создается враг
    public float spawnInterval = 1f; // интервал создания врагов

    private float timeSinceLastSpawn = 0f; // время с последнего создания врага

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
        var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        var enemyMovement = enemy.GetComponent<EnemyMovement>();
        var player = GameObject.Find("Player");
        enemyMovement.player = player.transform;
    }
}