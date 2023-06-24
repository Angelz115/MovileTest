using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * force);
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
    }
}
