using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1.0f;

    public float minSize = 0.5f;

    public float maxSize = 1.5f;

    public float directionX;

    public float directionY;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D asteroid_RigidBody2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        asteroid_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ChangeSpriteOnStart();

        this.transform.localScale = Vector3.one * this.size;
        asteroid_RigidBody2D.mass = this.size;

        asteroid_RigidBody2D.velocity = new Vector2(directionX, directionY);
    }

    private void ChangeSpriteOnStart()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

    }

}
