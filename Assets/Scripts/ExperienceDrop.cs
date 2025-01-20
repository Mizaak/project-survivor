using UnityEngine;

public class ExperienceDrop : MonoBehaviour
{
    private int expValue;
    public int ExpValue { get { return expValue; } }

    public void Init(int _expValue) => expValue = _expValue;
    public void Die() => Destroy(gameObject);
}
