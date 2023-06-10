using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColl : MonoBehaviour
{
    public int lives;
    public int points;
    public int combo;
    public int maxCombo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        int val = collision.gameObject.GetComponent<Behavior>().Value;
        if (collision.gameObject.tag == "Enemy")
        {
            Damaged(val);
        }
        else
        {
            GainPoints(val);
        }
    }
    void Damaged(int val) 
    {
        lives -= val;
        combo = 0;
    }
    void GainPoints(int val) 
    {
        points += val;
        combo++;
        
    }
}
