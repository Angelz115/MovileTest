using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int Points = 0;
    public int combo;
    public int maxCombo;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject coll = collision.gameObject;

        if (coll.CompareTag("Point"))
        {
            Points += coll.GetComponent<Behavior>().Value;
            combo++;
            if (combo >= maxCombo)
            {
                maxCombo = combo;
            }
        }

        if (coll.CompareTag("Enemy"))
            combo = 0;

    }

    
}
