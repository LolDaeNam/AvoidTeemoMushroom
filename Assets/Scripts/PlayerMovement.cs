using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private TopDownPlayerController controller;
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer characterRenderer;

    // 이동 - 이동 방향
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

    void Move(Vector2 direction)
    {
        movementDirection = direction;
        if (direction.x > 0) characterRenderer.flipX = false;
        else if (direction.x < 0) characterRenderer.flipX = true;
        
    }

    // 물리적인 이동
    private void FixedUpdate()
    {
        // 실제 이동 함수
        ApplyMovement(movementDirection);
    }

    void ApplyMovement(Vector2 direction)
    {
        direction *= speed;
        rb.velocity = direction;
    }
}
