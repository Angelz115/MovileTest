using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * force);
    }

    
}