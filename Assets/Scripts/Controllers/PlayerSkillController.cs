using UnityEngine;

public class PlayerSkillContorller : MonoBehaviour
{
    public AbstractSkill[] skills;

    [HideInInspector]
    public bool[] skillOnCooldown;      // 쿨타임 상태 여부
    [HideInInspector]
    public float[] skillCooldownTimers; // 쿨타임 타이머
    [HideInInspector]
    public bool[] skillActive;          // 스킬 사용 중 여부
    [HideInInspector]
    public float[] skillActiveTimers;   // 스킬 지속 시간

    private void Start()
    {
        skillOnCooldown = new bool[skills.Length];
        skillCooldownTimers = new float[skills.Length];
        skillActive = new bool[skills.Length];
        skillActiveTimers = new float[skills.Length];
    }

    private void Update()
    {
        // 모든 스킬을 체크하여
        for (int i = 0; i < skills.Length; i++)
        {
            // 스킬이 쿨타임 중일 경우
            if (skillOnCooldown[i])
            {
                // 쿨타임 남은 시간을 조정하고
                skillCooldownTimers[i] -= Time.deltaTime;
                // 시간이 다 됐으면 쿨타임 상태 해제
                if (skillCooldownTimers[i] <= 0)
                {
                    skillOnCooldown[i] = false;
                }
            }
            // 스킬이 이미 사용 중일 경우
            if (skillActive[i])
            {
                // 지속 시간을 조정하고
                skillActiveTimers[i] -= Time.deltaTime;
                // 시간이 다 됐으면
                if (skillActiveTimers[i] <= 0)
                {
                    // 스킬 종료
                    skills[i].Deactivate(gameObject);
                    // 스킬 사용 중 표시와 쿨타임 상태 전환
                    skillActive[i] = false;
                    skillOnCooldown[i] = true;
                    skillCooldownTimers[i] = skills[i].cooldownTime;
                }
            }
        }
    }

    // 스킬 사용
    public void UseSkill(int skillIndex)
    {
        // 쿨타임 여부와 이미 스킬 사용 중인지 체크
        if (!skillOnCooldown[skillIndex] && !skillActive[skillIndex])
        {
            // 스킬 사용
            skills[skillIndex].Activate(gameObject);
            // 스킬 사용 중 표시
            skillActive[skillIndex] = true;
            // 스킬 사용 시간 설정
            skillActiveTimers[skillIndex] = skills[skillIndex].activeTime;
        }
    }

    // Q, W, E, R키를 눌러 인풋 시스템에서 호출되는 메서드들
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

    public void OnRskill()
    {
        UseSkill(3);
    }
}
