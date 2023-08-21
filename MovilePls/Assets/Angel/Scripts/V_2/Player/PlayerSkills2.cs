using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills2 : MonoBehaviour
{
    [Header("Predifined Values")]
    public Transform originPoint;
    public GameObject proyectile;
    public GameObject shield;
    public int maxProyectileCount;
    public int maxShieldCount;
    public int asteroidsHit;
    [Space]
    [Header("Values")]
    public int proyectileCount;
    public int shieldCount;
    public float timer, maxShieldTimer;
    public bool shieldActive;
    public bool tutorial;
    private void Start()
    {
        if (tutorial)
        {
            shieldCount = 3;
            proyectileCount = 6;

        }
        else
        {
            shieldCount = PlayerPrefs.GetInt("totalShields");
            proyectileCount = PlayerPrefs.GetInt("totalProyectiles");
        }
        GameManager2.Instance.proyectileCountUI.text = proyectileCount.ToString();
        GameManager2.Instance.shieldSKCountUI.text = shieldCount.ToString();
        shield.SetActive(false);
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager2.Instance.ProyectileUI();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager2.Instance.ShieldSKUI();
        }
        
        if (shieldActive)
            timer += Time.deltaTime;
        if (timer >= maxShieldTimer)
        {
            shieldActive = false;
            shield.SetActive(false);
            timer = 0;
        }

        
    }
    public int proyectileSK() 
    {
        if (proyectileCount <= 0)
            return proyectileCount;
        
        proyectileCount--;
        Instantiate(proyectile, originPoint.position, transform.rotation);
        return proyectileCount;
        
    }
    public int ShieldSK() 
    {
        if (shieldCount <= 0 || shieldActive)
            return shieldCount;
        
        shieldCount--;
        shield.SetActive(true);
        shieldActive = true;
        return shieldCount;
        
    }
    public int getProyectilesP() 
    {
        return proyectileCount;
    }
    public int getShieldSKP() 
    {
        return shieldCount;
    }
    public int getHittedP() 
    {
        return asteroidsHit; 
    }
}
