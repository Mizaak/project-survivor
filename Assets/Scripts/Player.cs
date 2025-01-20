using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PLAYER STATISTICS")]
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentExp = 0;
    [Space(5)]
    [SerializeField] private int maxHP;
    [SerializeField] private int actualHP;
    [Space(5)]
    [SerializeField] private float moveSpeed = 1f;
    public float MoveSpeed { get { return moveSpeed; } }


    private void Start()
    {
        currentLevel = 1;
        actualHP = maxHP;

        if (actualHP <= 0)
            Debug.LogError("At the start the Player's HP are less or equal to 0");
    }

    public void GainExp(int exp)
    {
        if (exp > 0)
        {
            currentExp += exp;
            if (currentExp >= ExpToLevelUp())
                LevelUp();
        }
        else
            Debug.LogWarning("Experience gained by the Player was negative or zero!");
    }
    private int ExpToLevelUp() => currentLevel * currentLevel * 10;
    private void LevelUp()
    {
        currentLevel++;

        //TO DO
    }
}
