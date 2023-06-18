using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    public Vector2 target;
    public Rigidbody2D rb;
    public float force;
    public float speedModifier = 1;
    
    public int Value;
    public int identity;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcction = target - new Vector2(transform.position.x, transform.position.y);
        rb.AddForce(direcction * force * speedModifier);
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gm = collision.gameObject;
        
        if (gm.CompareTag("Proyectile") && identity == 1)
        {
            player.GetComponent<PlayerPoints>().enemyHits++;
        }
        
        Destroy(gameObject);
    }
}
