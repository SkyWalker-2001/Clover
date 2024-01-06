using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller: Singleton<Player_Controller>
{
    [SerializeField] private float moveSpeed = 1f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private float startingMoveSpeed;

    public FloatingJoystick floatingJoystick;


    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        startingMoveSpeed = moveSpeed;

    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        StartCoroutine(Player_Speed());

        Move();
    }

    private void PlayerInput()
    {
        movement = new Vector2(floatingJoystick.Horizontal, floatingJoystick.Vertical);
    }

    // Player Speed Courtine

    private IEnumerator Player_Speed()
    {
        moveSpeed += (.1f * Time.fixedDeltaTime);

        yield return new WaitForSeconds(2f);
    }

    private void Move()
    {
        // will use in future

       // if (knockback.GettingKnockedBack || PlayerHealth.Instance.IsDead) { return; }

        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
