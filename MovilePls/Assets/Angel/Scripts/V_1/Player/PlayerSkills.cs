using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSkills : MonoBehaviour
{
    [Header("Game Objects")]

    public GameObject ProyectileGO;
    public GameObject skShield;
    public GameObject thisSkShield;

    [Space]
    [Header("Predened Values")]

    public Transform origin;
    public int proyectileCount;
    public int skillShieldCount;
    public TextMeshProUGUI ProyCountUI;
    public TextMeshProUGUI skShieldCountUI;

    [Space]
    [Header("Shield_SK values")]

    public float timer;
    public float MaxShield;
    public bool shieldActive;
    private void Start()
    {
        ProyCountUI.text = proyectileCount.ToString();
        skShieldCountUI.text = skillShieldCount.ToString();
    }
    private void Update()
    {
        if (shieldActive)
            timer += Time.deltaTime;
            
        
        if (timer >= MaxShield)
        {

            Destroy(thisSkShield);
            timer = 0;
            shieldActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootProyectile();
        }
        
    }
    public void shootProyectile() 
    {
        if (proyectileCount <=0)
            return;

        Instantiate(ProyectileGO, origin.position, transform.rotation);
        proyectileCount--;
        ProyCountUI.text = proyectileCount.ToString();
    }
    public void SkShield() 
    {
        if (skillShieldCount <= 0)
            return;

        if (shieldActive)
            return;

        Vector3 ShieldPosSK = new Vector3(0, 0.5f, 0);
        thisSkShield = Instantiate(skShield,ShieldPosSK,transform.rotation);
        thisSkShield.transform.parent = gameObject.transform;
        
        shieldActive = true;
        skillShieldCount--;
        skShieldCountUI.text = skillShieldCount.ToString();
        
    }
}
