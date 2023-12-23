using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    private void Awake()
    {
        Application.targetFrameRate = 144;
    }

    public void Spin_Object()
    {
        var body = GetComponent<Rigidbody2D>();
        var impulse = (150 * Mathf.Deg2Rad) * body.inertia;

        body.AddTorque(impulse, ForceMode2D.Impulse);
    }

}
