using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller: MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private float startingMoveSpeed;

    public FloatingJoystick floatingJoystick;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startingMoveSpeed = moveSpeed;

    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = new Vector2(floatingJoystick.Horizontal, floatingJoystick.Vertical);
    }

    private void Move()
    {
        // will use in future

       // if (knockback.GettingKnockedBack || PlayerHealth.Instance.IsDead) { return; }

        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
