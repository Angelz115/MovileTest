 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MenuTienda" , menuName = "Plantillas/InfoItemTienda")]
public class PlantillaInfoItem : ScriptableObject
{
    public string titulo;
    public Sprite imagen;
    public int precio;

}
