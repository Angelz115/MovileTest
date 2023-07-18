using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorV2 : MonoBehaviour
{
    [Header("Predefined Values")]
    public Rigidbody2D rb;
    public float force;
    public float speedModifier = 1;
    public GameObject asteroidParticles; 
    [Space]
    [Header("Instanciated VAlues")]
    public GameObject player;
    public Entity Entity;
    public int value;
    //public float maxtimer, timer;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direcction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        //Vector2 direcction = target - new Vector2(transform.position.x, transform.position.y);
        rb.AddForce(direcction * force * speedModifier);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (Entity == Entity.Asteroid)
        {
            if (collision.gameObject.CompareTag("Proyectile"))
            {
                GameManager2.Instance.addPoints(value);
                
            }
            GameManager2.Instance.subtractLives();
            //Instantiate(asteroidParticles, transform.position, transform.rotation);
        }
        else
            GameManager2.Instance.addPoints(value);
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Entity == Entity.Asteroid)
        {
            Instantiate(asteroidParticles,transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }
    
}
