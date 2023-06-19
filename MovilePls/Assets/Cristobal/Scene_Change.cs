using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public void toMainMenu()
    {
        SceneManager.LoadScene("SelectorNivel");
    }

    public void lvl1()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void lvl2() 
    { 
    
    }
    public void lvl3() 
    { 
    
    }
   
}
