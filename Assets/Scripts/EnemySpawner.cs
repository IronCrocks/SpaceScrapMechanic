using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // префаб врага
    public GameObject player;
    public float spawnRadius = 20f; // радиус, в пределах которого создается враг
    public float stepInterval = 10f;
    public float spawnInterval = 1f; // интервал создания врагов

    private float _timer;
    private float _currentInterval;
    private int _stepCount;
    private int _enemyCount = 1;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnInterval);

        _timer = stepInterval;
        _currentInterval = spawnInterval;
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            // Получаем случайную позицию вокруг персонажа
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)transform.position + randomDirection * spawnRadius;

            // Создаем врага на случайной позиции
            //var enemyType = Random.Range(0, enemyPrefabs.Count - 1);
            var enemy = Instantiate(enemyPrefabs[i], spawnPosition, Quaternion.identity);
            var enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.player = player.transform;
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _stepCount++;

            if (_stepCount > 5)
            {
                _enemyCount++;
                _currentInterval = spawnInterval;
            }

            _currentInterval -= 0.1f;
            RestartSpawnEnemy();
            _timer = stepInterval;
        }
    }

    private void RestartSpawnEnemy()
    {
        CancelInvoke(nameof(SpawnEnemy));
        InvokeRepeating(nameof(SpawnEnemy), 0, _currentInterval);
    }
}