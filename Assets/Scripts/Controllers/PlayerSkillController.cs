using UnityEngine;

public class PlayerSkillContorller : MonoBehaviour
{
    public AbstractSkill[] skills;

    [HideInInspector]
    public bool[] skillOnCooldown;
    [HideInInspector]
    public float[] skillCooldownTimers;
    [HideInInspector]
    public bool[] skillActive;
    [HideInInspector]
    public float[] skillActiveTimers;

    private void Start()
    {
        skillOnCooldown = new bool[skills.Length];
        skillCooldownTimers = new float[skills.Length];
        skillActive = new bool[skills.Length];
        skillActiveTimers = new float[skills.Length];
    }

    private void Update()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skillOnCooldown[i])
            {
                skillCooldownTimers[i] -= Time.deltaTime;
                if (skillCooldownTimers[i] <= 0)
                {
                    skillOnCooldown[i] = false;
                }
            }

            if (skillActive[i])
            {
                skillActiveTimers[i] -= Time.deltaTime;
                if (skillActiveTimers[i] <= 0)
                {
                    skills[i].Deactivate(gameObject);
                    skillActive[i] = false;
                    skillOnCooldown[i] = true;
                    skillCooldownTimers[i] = skills[i].cooldownTime;
                }
            }
        }
    }

    public void UseSkill(int skillIndex)
    {
        if (!skillActive[skillIndex] && !skillActive[skillIndex])
        {
            skills[skillIndex].Activate(gameObject);
            skillActive[skillIndex] = true;
            skillActiveTimers[skillIndex] = skills[skillIndex].activeTime;
        }
    }

    public void OnQskill()
    {
        UseSkill(0);
    }

    public void OnWskill()
    {
        UseSkill(1);
    }

    public void OnEskill()
    {
        UseSkill(2);
    }
}
