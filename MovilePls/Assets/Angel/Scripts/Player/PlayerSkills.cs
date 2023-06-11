using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public GameObject Handle;
    public GameObject ProyectileGM;
    public Transform origin;
    public GameObject Shield;
    
    public void Proyectile() 
    {
        //Shield.gameObject.SetActive(false);
        GameObject proyectile = Instantiate(ProyectileGM, origin.position, transform.rotation);
    }
    public void Invincibility() 
    { 
        
    }
}
