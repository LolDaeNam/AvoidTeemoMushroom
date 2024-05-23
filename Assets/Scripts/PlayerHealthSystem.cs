using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    PlayerAnimationController playerAnimation;  // 플레이어 애니메이션

    public int maxHp = 100;             // 최대 HP
    public float currentHp;             // 현재 HP
    public float damageReduction = 1.0f;// 데미지 비율(기본 100%)

    public Slider hpSlider;             // HP바 UI
    public Text hpText;                 // HP 텍스트 UI
    
    public bool isDead = false;         // 사망 여부

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimationController>();
        currentHp = maxHp;
    }

    private void Update()
    {
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString();
    }

    // 피격 데미지 적용
    public void TakeDamage(float damage)
    {
        // 데미지 감소를 적용하여 현재 HP에 반영
        currentHp -= damage * damageReduction;
        // HP가 0 아래로 내려가지 않게 조정
        if (currentHp < 0) currentHp = 0;
        // HP UI 업데이트
        UpdateHpUI();
        // 피격 시 애니메이션 출력
        playerAnimation.OnHitAnim();
        playerAnimation.Invoke("OutHitAnim", 0.1f);
        // HP가 0이 될 시 사망
        if (currentHp == 0)
        {
            Die();
        }
    }

    // 체력 회복
    public void RecoverHp(int recoverAmount)
    {
        float hp = currentHp;
        hp += recoverAmount;
        // 체력이 100이 넘지 않게
        hp = Mathf.Clamp(hp, 1, 100);
        currentHp = hp;
        // UI 업데이트
        UpdateHpUI();
    }

    // UI 업데이트
    void UpdateHpUI()
    {
        if (hpSlider != null) hpSlider.value = currentHp;
    }

    // 사망
    public void Die()
    {
        isDead = true;
    }
}
