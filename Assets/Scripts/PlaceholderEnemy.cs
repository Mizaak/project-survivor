using UnityEngine;

public class PlaceholderEnemy : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private GameObject expDrop;
    public GameObject ExpDrop { get { return expDrop; } }

    [Header("PLACEHOLDER ENEMY STATISTICS")]
    [SerializeField] private float moveSpeed = 10f;
    public float MoveSpeed { get { return moveSpeed; } }
    [Space(5)]
    [SerializeField] private int expDropped = 1;
    public int ExpDropped { get { return expDropped; } }
}
