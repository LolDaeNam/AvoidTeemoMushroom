using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private TopDownPlayerController controller;
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

    void Move(Vector2 direction)
    {
        movementDirection = direction;
        if (direction.x > 0) characterRenderer.flipX = false;
        else if (direction.x < 0) characterRenderer.flipX = true;
        
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    void ApplyMovement(Vector2 direction)
    {
        direction *= speed;
        rb.velocity = direction;
    }
}
