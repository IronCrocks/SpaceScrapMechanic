using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // префаб врага
    public GameObject player;
    public float spawnRadius = 20f; // радиус, в пределах которого создается враг
    public float enemyWaveInterval = 10f;
    public float defaultSpawnInterval = 1f; // интервал создания врагов

    private float _timer;
    private float _spawnEnemyInterval;
    private int _waveCount;
    private int _enemyCount = 1;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, defaultSpawnInterval);

        _timer = enemyWaveInterval;
        _spawnEnemyInterval = defaultSpawnInterval;
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            // Получаем случайную позицию вокруг персонажа
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)transform.position + randomDirection * spawnRadius;

            int enemyIndex = i < enemyPrefabs.Count ? i : Random.Range(0, enemyPrefabs.Count - 1);

            // Создаем врага на случайной позиции
            var enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPosition, Quaternion.identity);
            var enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.player = player.transform;
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _waveCount++;

            if (_waveCount > 5)
            {
                _enemyCount++;
                _spawnEnemyInterval = defaultSpawnInterval;
            }

            _spawnEnemyInterval -= 0.1f;
            RestartSpawnEnemy();
            _timer = enemyWaveInterval;
        }
    }

    private void RestartSpawnEnemy()
    {
        CancelInvoke(nameof(SpawnEnemy));
        InvokeRepeating(nameof(SpawnEnemy), 0, _spawnEnemyInterval);
    }
}