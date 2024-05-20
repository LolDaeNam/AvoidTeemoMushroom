using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int skillIndex;
    public PlayerSkillContorller skillContorller;
    public Image cooldownOverlay;

    private void Update()
    {
        if (skillContorller.skillOnCooldown[skillIndex])
        {
            cooldownOverlay.fillAmount = skillContorller.skillCooldownTimers[skillIndex] / skillContorller.skills[skillIndex].cooldownTime;
        }
        else
        {
            cooldownOverlay.fillAmount = 0;
        }
    }

    public void OnButtonClick()
    {
        skillContorller.UseSkill(skillIndex);
    }
}