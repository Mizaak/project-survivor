using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    [SerializeField] private Skill[] skillsDatabase;

    private void Start()
    {
        foreach (Skill skill in skillsDatabase)
            skill.Init();
    }

    private void Update()
    {
        foreach (Skill skill in skillsDatabase)
            skill.ManageCooldown();
    }
}
