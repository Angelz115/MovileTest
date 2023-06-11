using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSkills : MonoBehaviour
{
    public GameObject Handle;
    public GameObject ProyectileGM;
    public Transform origin;
    public GameObject Shield;
    public int proyectileCount;
    public int invincivilityCount;
    public TextMeshProUGUI ProyCountUI;
    public TextMeshProUGUI InviCountUI;

    public float timer;
    public float MaxInv;
    public bool invActive;
    private void Start()
    {
        ProyCountUI.text = proyectileCount.ToString();
        InviCountUI.text = invincivilityCount.ToString();
    }
    private void Update()
    {
        if (invActive)
        {
            timer += Time.deltaTime;
            Debug.Log("Invencible");
        }
        if (timer >= MaxInv)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            timer = 0;
            invActive = false;
        }
        
    }
    public void Proyectile() 
    {
        if (proyectileCount <=0)
            return;
        //Shield.gameObject.SetActive(false);
        GameObject proyectile = Instantiate(ProyectileGM, origin.position, transform.rotation);
        proyectileCount--;
        ProyCountUI.text = proyectileCount.ToString();
    }
    public void Invincibility() 
    {
        if (invincivilityCount <= 0)
            return;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        invActive = true;
        Debug.Log("Invencible");
        invincivilityCount--;
        InviCountUI.text = invincivilityCount.ToString();
        
    }
}
