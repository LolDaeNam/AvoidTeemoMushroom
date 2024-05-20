using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom : MonoBehaviour
{
    float size = 1.0f;
    int score = 0;

    // 크기와 점수를 배열로 저장
    float[] sizes = { 2.0f, 1.0f, 5.0f };
    int[] scores = { 10, 20, 30 };

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-4.95f, 4.95f);
        float y = (5.5f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 4);
        // 배열 인덱스는 0부터 시작하므로 type 값에서 1을 뺀다.
        int index = type - 1;

        // 배열에서 크기와 점수를 가져온다.
        size = sizes[index];
        score = scores[index];

        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.totalScore += score;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.GameOver();
            SceneManager.LoadScene(2);
        }
    }
}
