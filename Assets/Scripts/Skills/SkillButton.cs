using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int skillIndex;                          // 스킬 배열에 사용할 인덱스
    public PlayerSkillContorller skillContorller;   // 스킬 컨트롤러
    public Image cooldownOverlay;                   // 쿨타임 오버레이
    public Image activeOverlay;                     // 스킬 지속 시간 오버레이



    private void Update()
    {
        // 스킬 지속 시간 시각적 효과 출력
        if (skillContorller.skillActive[skillIndex])
        {
            activeOverlay.fillAmount = skillContorller.skillActiveTimers[skillIndex] / skillContorller.skills[skillIndex].activeTime;
        }
        else
        {
            activeOverlay.fillAmount = 0;
        }
        // 쿨타임 시각적 효과 출력
        if (skillContorller.skillOnCooldown[skillIndex])
        {
            cooldownOverlay.fillAmount = skillContorller.skillCooldownTimers[skillIndex] / skillContorller.skills[skillIndex].cooldownTime;
        }
        else
        {
            cooldownOverlay.fillAmount = 0;
        }
    }
}