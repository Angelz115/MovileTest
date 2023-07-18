using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void pauseGame() 
    {
        Time.timeScale = 0;
    }

}
