using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex_Effect_Background : MonoBehaviour
{
    private float movementX;

    private float movementY;

    private MeshRenderer meshRenderer;

    public float animationSpeed;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //movementX = Input.GetAxis("Horizontal");
        movementX = 1;

        //movementY = Input.GetAxis("Vertical");
        movementY = 1;

        meshRenderer.material.mainTextureOffset += new Vector2(movementX * animationSpeed * Time.deltaTime, movementY * animationSpeed * Time.deltaTime);
    }
}
