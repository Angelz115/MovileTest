using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    public Vector2 target;
    public Rigidbody2D rb;
    public float force;
    public float timer;
    public float desTime = 4;
    public int Value;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direcction = target - new Vector2(transform.position.x, transform.position.y);
        rb.AddForce(direcction * force);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= desTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
