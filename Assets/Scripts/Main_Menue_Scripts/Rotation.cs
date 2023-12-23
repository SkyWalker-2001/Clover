using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    //private int random;

    //private void Start()
    //{
    //    random = Random.Range(1, 10);
    //}

    private void FixedUpdate()
    {

        //if (random % 2 == 0)
        //{
            transform.Rotate(new Vector3(0.0f, 0.0f, 1) * rotationSpeed);
        //}

        //else
        //{
        //    transform.Rotate(new Vector3(0.0f, 0.0f, -1) * rotationSpeed);
        //}

    }
}
