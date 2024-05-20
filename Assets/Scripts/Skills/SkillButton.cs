using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int skillIndex;
    public PlayerSkillContorller skillContorller;
    public Image cooldownOverlay;
    public Image activeOverlay;



    private void Update()
    {
        if (skillContorller.skillActive[skillIndex])
        {
            activeOverlay.fillAmount = skillContorller.skillActiveTimers[skillIndex] / skillContorller.skills[skillIndex].activeTime;
        }
        else
        {
            activeOverlay.fillAmount = 0;
        }

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