using UnityEngine;


public abstract class Skill : ScriptableObject
{
    [Header("SKILL SHARED PARAMETERS")]
    [SerializeField] protected string skillName;
    [SerializeField] protected int skillLevel;
    [SerializeField] protected float skillBaseCooldown;
    [SerializeField] protected float skillActualCooldown;
    [SerializeField] protected bool learned;
    [Space(10)]
    [SerializeField] protected int skillBaseDamage;
    public int SkillDamage
    {
        get
        {
            float tempDamage = skillBaseDamage + (((float)skillBaseDamage / 100) * (damageAugmentPercPerLvl * (skillLevel - 1)));
            return Mathf.RoundToInt(tempDamage);
        }
    }
    [SerializeField] protected float damageAugmentPercPerLvl;
    [Space(5)]
    [SerializeField] protected float skillBaseRange;
    public float SkillRange { get { return skillBaseRange + ((skillBaseRange / 100) * (rangeAugmentPercPerLvl * (skillLevel - 1))); } }
    [SerializeField] protected float rangeAugmentPercPerLvl;
    [Space(5)]
    [SerializeField] protected float skillBaseRadius;
    public float SkillRadius { get { return skillBaseRadius + ((skillBaseRadius / 100) * (radiusAugmentPercPerLvl * (skillLevel - 1))); } }
    [SerializeField] protected float radiusAugmentPercPerLvl;


    public virtual void Init()
    {
        skillLevel = 1;
        skillActualCooldown = skillBaseCooldown;
    }
    public abstract void ManageCooldown();
    public abstract bool CheckActivationConditions();
    public abstract void ActivateSkill();
}


