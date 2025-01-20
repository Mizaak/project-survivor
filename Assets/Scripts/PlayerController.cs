using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("REFERENCES")]
    [SerializeField] private Transform playerGraphic;
    private Player player;

    [Header("MOVEMENT SETTINGS")]
    [SerializeField] private float minDistanceToMove = .5f;

    private bool isTurnedRight = true;

    private Vector3 targetPosition;


    private void Awake()
    {
        if (instance != this)
            instance = this;
    }

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;

            float distanceFromPlayer = Vector2.Distance(transform.position, targetPosition);

            if (distanceFromPlayer >= minDistanceToMove)
            {
                Vector2 direction = (transform.position - targetPosition).normalized;
                transform.position -= (Vector3)direction * player.MoveSpeed * Time.deltaTime;
                ManagePlayerGraphicRotation();
            }
        }
    }

    private void ManagePlayerGraphicRotation()
    {
        if (!isTurnedRight && transform.position.x < targetPosition.x)
        {
            playerGraphic.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
        else if (isTurnedRight && transform.position.x > targetPosition.x)
        {
            playerGraphic.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Exp")
        {
            ExperienceDrop expDrop = other.gameObject.GetComponent<ExperienceDrop>();
            player.GainExp(expDrop.ExpValue);
            expDrop.Die();
        }
    }
}

