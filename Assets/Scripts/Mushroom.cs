using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom : MonoBehaviour
{
    float size = 1.0f;
    int score;
    int damage = 0;
    Color color = Color.white;

    // 크기, 점수, 색상, 떨어지는 속도를 배열로 저장
    float[] sizes = { 1f, 0.75f, 1.5f, 3f, 1.5f };
    int[] scores = { 1, 2, 3, 4, 5 };
    Color[] colors = { Color.white, Color.white, Color.white, Color.red, Color.blue };
    float[] Speeds = { 3f, 8f, 4f, 0.5f, 5f };
    // 5번 버섯 y 위치 0으로 설정
    float[] yPosition = { 5.5f, 5.5f, 5.5f, 5.5f, 3f };

    int[] damages = { 15, 20, 30, 30, 30};

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-4.7f, 4.7f);

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

        // 배열에서 크기, 점수, 색상을 가져온다.
        size = sizes[index];
        score = scores[index];
        color = colors[index];
        damage = damages[index];
        float Speed = Speeds[index];
        // 5번 버섯은 y 위치를 배열에서 가져온다.
        float y = yPosition[index];
        transform.position = new Vector3(x, y, 0);

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

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (GameManager.Instance.isActiveRskill == true)
            {
                score *= 3;
                GameManager.Instance.totalScore += score;
                Destroy(this.gameObject, 1f);
            }
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.totalScore += score;
           
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            PlayerHealthSystem healthSystem = collision.gameObject.GetComponentInChildren<PlayerHealthSystem>();

            if (GameManager.Instance.isActiveEskill == true)
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
        else if (collision.gameObject.CompareTag("Invincible"))
        {
            Destroy(gameObject);
        }
    }
}
