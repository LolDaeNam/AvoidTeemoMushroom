using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb2D;

    // 버섯의 속성
    private float size = 1.0f;
    private int score;
    private int damage = 0;
    private Color color = Color.white;

    // 크기, 점수, 색상, 떨어지는 속도 및 초기 y 위치를 저장한 배열
    private readonly float[] sizes = { 1f, 0.75f, 1.5f, 3f, 1.5f };
    private readonly int[] scores = { 1, 2, 3, 4, 5 };
    private readonly Color[] colors = { Color.white, Color.white, Color.white, Color.red, Color.blue };
    private readonly float[] speeds = { 3f, 8f, 4f, 0.5f, 5f };
    private readonly float[] yPositions = { 5.5f, 5.5f, 5.5f, 5.5f, 3f };
    private readonly int[] damages = { 15, 20, 30, 30, 30 };

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        SetMushroomProperties();
    }

    // 버섯의 속성을 설정하는 메서드
    private void SetMushroomProperties()
    {
        float x = Random.Range(-4.7f, 4.7f);

        int index = GetMushroomIndex();
        size = sizes[index];
        score = scores[index];
        color = colors[index];
        damage = damages[index];
        float speed = speeds[index];
        float y = yPositions[index];

        transform.position = new Vector3(x, y, 0);
        transform.localScale = new Vector3(size, size, 0);

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }

        rb2D.velocity = new Vector2(0, -speed);
    }

    // 총 점수를 기준으로 버섯의 인덱스를 계산하는 메서드
    private int GetMushroomIndex()
    {
        int index = 0;
        int target = 0;

        for (int i = 1; i <= 5; i++)
        {
            if (GameManager.Instance.totalScore > target)
            {
                index = Random.Range(0, i);
                target += 50;
            }
        }

        return index;
    }

    // 충돌 처리 메서드
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            HandleWeaponCollision();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            HandleGroundCollision();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision(collision);
        }
        else if (collision.gameObject.CompareTag("Invincible"))
        {
            Destroy(gameObject);
        }
    }

    // 무기와 충돌 처리
    private void HandleWeaponCollision()
    {
        if (GameManager.Instance.isActiveRskill)
        {
            score *= 3;
            GameManager.Instance.totalScore += score;
            Destroy(gameObject, 1f);
        }
    }

    // 땅과 충돌 처리
    private void HandleGroundCollision()
    {
        SetBoom();
        GameManager.Instance.totalScore += score;
    }

    // 플레이어와 충돌 처리
    private void HandlePlayerCollision(Collision2D collision)
    {
        SetBoom();

        PlayerHealthSystem healthSystem = collision.gameObject.GetComponentInChildren<PlayerHealthSystem>();

        if (GameManager.Instance.isActiveEskill)
        {
            score *= 2;
            GameManager.Instance.totalScore += score;
        }
        else if (healthSystem != null)
        {
            healthSystem.TakeDamage(damage);

            if (healthSystem.isDead)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    // 버섯을 파괴하는 메서드
    public void DestroyMushroom()
    {
        Destroy(gameObject);
    }

    // 폭발 효과 설정 메서드
    private void SetBoom()
    {
        rb2D.gravityScale = 0;
        rb2D.velocity = Vector2.zero;
        anim.SetBool("isBoom", true);
    }
}