using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    PlayerAnimationContorller playerAnimation;

    public int maxHp = 100;
    public float currentHp;
    public float damageReduction = 1.0f;

    public Slider hpSlider;
    public Text hpText;
    
    public bool isDead = false;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimationContorller>();
        currentHp = maxHp;
    }

    private void Update()
    {
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString();
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage * damageReduction;

        if (currentHp < 0) currentHp = 0;

        UpdateHpUI();
        playerAnimation.OnAnimHit();
        playerAnimation.Invoke("OutAnimHit", 0.1f);

        if (currentHp == 0)
        {
            Die();
        }
    }

    public void RecoverHp(int recoverAmount)
    {
        float hp = currentHp;
        hp += recoverAmount;
        hp = Mathf.Clamp(hp, 1, 100);
        currentHp = hp;
        UpdateHpUI();
    }

    void UpdateHpUI()
    {
        if (hpSlider != null) hpSlider.value = currentHp;
    }

    public void Die()
    {
        isDead = true;
    }
}
