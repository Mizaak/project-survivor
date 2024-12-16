using UnityEngine;

public class SpawnerPlaceholderEnemies : MonoBehaviour
{
    [SerializeField] private float spawnTime = 10f;


    private void OnEnable()
    {
        InvokeRepeating("SpawnPlaceholderEnemy", spawnTime, spawnTime);
    }

    private void SpawnPlaceholderEnemy()
    {
        GameObject newEnemy = EnemiesPoolManger.instance.placeholderEnemyPool.Get();
        newEnemy.transform.position = transform.position;
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnPlaceholderEnemy");
    }

    private void OnDestroy()
    {
        CancelInvoke("SpawnPlaceholderEnemy");
    }
}
