using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum comprables {escudo,proyectil}

public class PlantillaItemTienda : MonoBehaviour
{
    public Image imagen;
    public TextMeshProUGUI textoPrecio;
    public TextMeshProUGUI titulo;
    public Button botonComprar;
    int precio;
    int monedasTotales;
    public comprables item;
    public int precioEscudo;
    public int precioProyectil;
    

    void Start()
    {
        precio = int.Parse(textoPrecio.text);

        switch (precio)
        {
            case 8:
                item = comprables.escudo;
                break;
            case 4:
                item = comprables.proyectil;
                break;
        }

    }
    
    public void Comprar()
    {
        int moneda_actual = PlayerPrefs.GetInt("monedasTotales");
        precio = int.Parse(textoPrecio.text);

        if (precio >= moneda_actual)
        {
            botonComprar.interactable = false;
        }

        if (item == comprables.proyectil)
        {
            
           int palabra = PlayerPrefs.GetInt("totalProyectiles") + 1;
            PlayerPrefs.SetInt("totalProyectiles", palabra);
        }

        if (item == comprables.escudo)
        {

            int palabra = PlayerPrefs.GetInt("totalShields") + 1;
            PlayerPrefs.SetInt("totalShields", palabra);
        }

        monedasTotales = moneda_actual-precio;
        PlayerPrefs.SetInt("monedasTotales", monedasTotales);
    }
}
