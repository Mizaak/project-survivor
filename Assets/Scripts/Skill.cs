using UnityEngine;


public abstract class Skill : ScriptableObject
{
    [Header("SKILL SHARED PARAMETERS")]
    [SerializeField] private string skillName;
    public float skillCooldown;
    public float skillActualCooldown;
    public bool learned;


    public virtual void Init() => skillActualCooldown = skillCooldown;
    public abstract void ManageCooldown();
    public abstract bool CheckActivationConditions();
    public abstract void ActivateSkill();
}


