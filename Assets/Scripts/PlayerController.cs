using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("REFERENCES")]
    [SerializeField] private Transform playerGraphic;

    [Header("PLAYER STATISTICS")]
    [SerializeField] private float moveSpeed = 1f;

    [Header("MOVEMENT SETTINGS")]
    [SerializeField] private float minDistanceToMove = .5f;

    private bool isTurnedRight = true;

    private Vector3 targetPosition;


    private void Awake()
    {
        if(instance != this)
            instance = this;
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
                transform.position -= (Vector3)direction * moveSpeed * Time.deltaTime;
                ManagePlayerGraphicRotation();
            }
        }
    }

    private void ManagePlayerGraphicRotation()
    {
        if(!isTurnedRight && transform.position.x < targetPosition.x)
        {
            playerGraphic.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
        else if(isTurnedRight && transform.position.x > targetPosition.x)
        {
            playerGraphic.transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            isTurnedRight = !isTurnedRight;
        }
    }
}
