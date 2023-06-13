using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoints : MonoBehaviour
{
    public int points = 0;
    public int currentCombo;
    public int maxCombo;
    public TextMeshProUGUI pointsUI;
    public TextMeshProUGUI comboUI;

    private void Start()
    {
        pointsUI.text = points.ToString();
        comboUI.text = "";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject coll = collision.gameObject;

        if (coll.CompareTag("Point"))
        {
            points += coll.GetComponent<Behavior>().Value;
            currentCombo++;
            pointsUI.text = points.ToString();
            comboUI.text = "Combo: " + currentCombo.ToString();
            if (currentCombo >= maxCombo)
            {
                maxCombo = currentCombo;
            }
        }

        if (coll.CompareTag("Enemy"))
        {
            currentCombo = 0;
            comboUI.text = "";
        }
    }

    
}
