using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int lives;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject coll = collision.gameObject; 
        if (coll.CompareTag("Enemy"))
        {
            lives -= coll.GetComponent<Behavior>().Value;
        }
    }
}
