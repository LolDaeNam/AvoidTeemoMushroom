using UnityEngine;

public abstract class AbstractSkill : MonoBehaviour
{
    public float cooldownTime;  // 스킬 쿨타임
    public float activeTime;    // 스킬 지속시간

    public abstract void Activate(GameObject player);   // 스킬 사용
    public abstract void Deactivate(GameObject player); // 스킬 사용 종료
}
