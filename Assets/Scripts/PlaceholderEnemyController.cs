using TMPro;
using UnityEngine;

public class PlaceholderEnemyController : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private Transform placeholderEnemyGraphics;

    private Transform playerTransform;

    private bool isTurnedRight = true;

    private PlaceholderEnemy placeholderEnemy;


    private void Start()
    {
        placeholderEnemy = GetComponent<PlaceholderEnemy>();
    }
    private void Update() => ChasePlayer();

    private void ChasePlayer()
    {
        Vector2 direction = (transform.position - PlayerController.instance.transform.position).normalized;
        transform.position -= (Vector3)direction * placeholderEnemy.MoveSpeed * Time.deltaTime;

        ManagePlaceholderEnemyGraphicRotation();
    }

    private void ManagePlaceholderEnemyGraphicRotation()
    {
        if (!isTurnedRight && transform.position.x < PlayerController.instance.transform.position.x)
        {
            placeholderEnemyGraphics.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
        else if (isTurnedRight && transform.position.x > PlayerController.instance.transform.position.x)
        {
            placeholderEnemyGraphics.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
    }
    private void Die()
    {
        GameObject newExp = Instantiate(placeholderEnemy.ExpDrop);
        newExp.transform.position = transform.position;
        newExp.GetComponent<ExperienceDrop>().Init(placeholderEnemy.ExpDropped);

        EnemiesPoolManger.instance.placeholderEnemyPool.Release(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Die();
        }
    }
}
