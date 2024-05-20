using UnityEngine;

public abstract class AbstractSkill : MonoBehaviour
{
    public float cooldownTime;
    public float activeTime;

    public abstract void Activate(GameObject player);
    public abstract void Deactivate(GameObject player);
}
