using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public int lives;
    public TextMeshProUGUI LivesUI;
    public bool isDead = false;

    private void Start()
    {
        LivesUI.text = lives.ToString();
    }
    private void Update()
    {
        if (lives >= 0)
        {
            isDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject coll = collision.gameObject; 
        if (coll.CompareTag("Enemy"))
        {
            lives -= coll.GetComponent<Behavior>().Value;
            LivesUI.text = lives.ToString();
        }
    }
}
