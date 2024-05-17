using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    float size = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.95f, 2.8f);
        float y = (6);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 4);

        if (type == 1)
        {
            size = 0.8f;
        }
        else if (type == 2)
        {
            size = 1.0f;
        }
        else if (type == 3)
        {
            size = 1.2f;
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
        }
    }
}
