using UnityEngine;

public class Rskill : AbstractSkill
{
    [HideInInspector]
    public GameObject currentObject;
    public GameObject rskillMotion;

    public override void Activate(GameObject player)
    {
        GameManager.Instance.isActiveRskill = true;
        currentObject = Instantiate(rskillMotion, new Vector3(0, 15, 0), Quaternion.identity);
    }

    public override void Deactivate(GameObject player)
    {
        GameManager.Instance.isActiveRskill = false;
        Destroy(currentObject);
    }
}
