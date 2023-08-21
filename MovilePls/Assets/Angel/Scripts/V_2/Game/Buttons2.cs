using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons2 : MonoBehaviour
{
    
    #region SKILLS
    public void shieldSKillButton() 
    {
        GameManager2.Instance.ShieldSKUI();
    }
    public void proyectileSkillButton() 
    {
        GameManager2.Instance.ProyectileUI();
    }
    #endregion

    #region PAUSE

    public void pauseGame() 
    {
        GameManager2.Instance.paused();
        
    }
    public void resumeGame() 
    {
        GameManager2.Instance.resume();
    }

    #endregion

    #region SCENES
    public void toEndless() 
    {
        SceneManager.LoadScene("Endless");
    }
    public void toShoop() 
    {
        SceneManager.LoadScene("Tienda");
    }
    public void toMainMenu() 
    {
        SceneManager.LoadScene("SelectorNivel");
    }
    public void toTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void toLevel_1() 
    {
        //SceneManager.LoadScene("Tutorial");
    }
    public void toLevel_2()
    {
        //SceneManager.LoadScene("Tutorial");
    }
    public void toLevel_3()
    {
        //SceneManager.LoadScene("Tutorial");
    }
    public void resetLvl_1() 
    {
        GameManager2.Instance.resume();
        //SceneManager.LoadScene("Tutorial");
    }
    public void resetLvl_2()
    {
        GameManager2.Instance.resume();
        //SceneManager.LoadScene("Tutorial");
    }
    public void resetLvl_3()
    {
        GameManager2.Instance.resume();
        //SceneManager.LoadScene("Tutorial");
    }
    public void resetTutorial()
    {
        GameManager2.Instance.resume();
        SceneManager.LoadScene("Tutorial");
    }
    public void resetEndless() 
    {
        GameManager2.Instance.resume();
        SceneManager.LoadScene("Endless");
    }
    #endregion

}
