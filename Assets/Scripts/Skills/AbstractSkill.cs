using UnityEngine;

public abstract class AbstractSkill : MonoBehaviour
{
    public float cooldownTime;
    public float activeTime;

    public abstract void Activate();
    public abstract void Deactivate();
}
