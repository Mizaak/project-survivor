using TMPro;
using UnityEngine;

public class PlaceholderEnemyController : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private Transform placeholderEnemyGraphics;

    [Header("PLACEHOLDER ENEMY STATISTICS")]
    [SerializeField] private float moveSpeed = 10f;

    private Transform playerTransform;
    private bool isTurnedRight = true;

    private void OnEnable()
    {
        Invoke(nameof(Die), 5f);
    }

    private void Start()
    {
        playerTransform = PlayerController.instance.transform;
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        transform.position -= (Vector3)direction * moveSpeed * Time.deltaTime;

        ManagePlaceholderEnemyGraphicRotation();
    }

    private void ManagePlaceholderEnemyGraphicRotation()
    {
        if (!isTurnedRight && transform.position.x < playerTransform.position.x)
        {
            placeholderEnemyGraphics.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
        else if (isTurnedRight && transform.position.x > playerTransform.position.x)
        {
            placeholderEnemyGraphics.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
    }

    private void Die()
    {
        EnemiesPoolManger.instance.placeholderEnemyPool.Release(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
