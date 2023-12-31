using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;

    public float size = 1.0f;

    public float minSize = 1f;

    public float maxSize = 3f;

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

        size = Random.Range(minSize, maxSize);

        this.transform.localScale = Vector3.one * this.size;
        asteroid_RigidBody2D.mass = this.size;

        asteroid_RigidBody2D.velocity = new Vector2(directionX, directionY);
    }

    private void ChangeSpriteOnStart()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

    }

}
