using UnityEngine;
using UnityEngine.Pool;

public class EnemiesPoolManger : MonoBehaviour
{
    public static EnemiesPoolManger instance;

    [Header("ENEMIES PRRFABS")]
    [SerializeField] private GameObject placeholderEnemy;

    [Header("POOLING SETTINGS")]
    [SerializeField] private int defaultPoolSize = 20;
    [SerializeField] private bool collectionCheck = true;

    public ObjectPool<GameObject> placeholderEnemyPool;


    private void Awake()
    {
        if(instance != this)
            instance = this;
    }

    private void Start()
    {
        placeholderEnemyPool = new ObjectPool<GameObject>(
            createFunc: CreatePlaceholderEnemy,
            actionOnGet: OnPlaceholderEnemySpawn,
            actionOnRelease: OnPlaceholderEnemyDespawn,
            actionOnDestroy: OnPlaceholderEnemyDestroyed,
            collectionCheck: collectionCheck,
            defaultCapacity: defaultPoolSize
        );

        PrePopulatePlaceholderEnemyPool();
    }

    private GameObject CreatePlaceholderEnemy()
    {
        GameObject newEnemy = Instantiate(placeholderEnemy);
        newEnemy.SetActive(false);
        //parte dove il nemico riceve la reference alla pool
        return newEnemy;
    }

    private void OnPlaceholderEnemySpawn(GameObject enemy) => enemy.SetActive(true);

    private void OnPlaceholderEnemyDespawn(GameObject enemy) => enemy.SetActive(false);

    private void OnPlaceholderEnemyDestroyed(GameObject enemy) => Destroy(enemy);

    private void PrePopulatePlaceholderEnemyPool()
    {
        for (int i = 0; i < defaultPoolSize; i++)
        {
            GameObject enemy = placeholderEnemyPool.Get();
            placeholderEnemyPool.Release(enemy);
        }
    }
}
