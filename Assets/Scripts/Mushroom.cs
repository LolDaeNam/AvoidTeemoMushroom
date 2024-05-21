using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb2D;

    float size = 1.0f;
    public int score = 0;
    int damage = 0;
    Color color = Color.white;

    // 크기, 점수, 색상, 떨어지는 속도를 배열로 저장
    float[] sizes = { 2.0f, 1.0f, 4.5f, 3.0f, 3.0f };
    int[] scores = { 10, 20, 30, 40, 50 };
    Color[] colors = { Color.white, Color.white, Color.white, Color.red, Color.blue };
    float[] Speeds = { 3.0f, 8.0f, 0.5f, 3.0f, 5.0f };
    // 5번 버섯 y 위치 0으로 설정
    float[] yPosition = { 5.5f, 5.5f, 5.5f, 5.5f, 0f };

    int[] damages = { 15, 20, 30, 30, 30};

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-4.7f, 4.7f);

        transform.position = new Vector3(x, 5.5f, 0);

        int type = Random.Range(1, 6);
        // 배열 인덱스는 0부터 시작하므로 type 값에서 1을 뺀다.
        int index = type - 1;

        // 배열에서 크기, 점수, 색상을 가져온다.
        size = sizes[index];
        score = scores[index];
        color = colors[index];
        damage = damages[index];
        float Speed = Speeds[index];
        // 5번 버섯은 y 위치를 배열에서 가져온다.
        float y = yPosition[index];

        transform.localScale = new Vector3(size, size, 0);

        // 색상을 적용
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // 인스턴스화된 머티리얼을 사용하여 색상 설정
            renderer.material.color = color;
        }

        // 떨어지는 속도를 적용
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -Speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            SetBoom();

            GameManager.Instance.totalScore += score;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            SetBoom();

            PlayerHealthSystem healthSystem = collision.gameObject.GetComponentInChildren<PlayerHealthSystem>();

            if(GameManager.Instance.isActiveSckill == true)
            {
                score *= 2;
                GameManager.Instance.totalScore += score;
            }
            else if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);
            }

            if (healthSystem.isDead == true) GameManager.Instance.GameOver();
        }
    }

    public void DestroyMushroom()
    {
        Destroy(gameObject);
    }

    private void SetBoom()
    {
        rb2D.gravityScale = 0;
        rb2D.velocity = Vector2.zero;
        anim.SetBool("isBoom", true);
    }
}
