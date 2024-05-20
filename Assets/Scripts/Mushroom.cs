using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom : MonoBehaviour
{
    float size = 1.0f;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-4.95f, 4.95f);
        float y = (5.5f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 4);

        if (type == 1)
        {
            size = 0.8f;
            score = 10;
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 20;
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 30;
        }

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
