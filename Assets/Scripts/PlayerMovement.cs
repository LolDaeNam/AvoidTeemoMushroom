using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public TopDownPlayerController controller;
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer characterRenderer;

    Vector2 movementDirection = Vector2.zero;

    public float speed = 5f;

    private void Awake()
    {
        controller = GetComponent<TopDownPlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    // 방향 설정
    public void Move(Vector2 direction)
    {
        movementDirection = direction;
        if (direction.x > 0) characterRenderer.flipX = false;
        else if (direction.x < 0) characterRenderer.flipX = true;
        
    }

    // 실직적인 움직임 적용
    void ApplyMovement(Vector2 direction)
    {
        direction *= speed;
        rb.velocity = direction;
    }
}
