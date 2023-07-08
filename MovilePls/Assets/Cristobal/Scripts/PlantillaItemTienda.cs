using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantillaItemTienda : MonoBehaviour
{
    public Image imagen;
    public TextMeshProUGUI textoPrecio;
    public TextMeshProUGUI titulo;
    public Button botonComprar;
    int precio;
    int monedasTotales;

    void Start()
    {
        precio = int.Parse(textoPrecio.text);
        if (precio > monedasTotales)
        {
            botonComprar.interactable = false;
        }
    }
    
    public void Comprar()
    {
        monedasTotales -= precio;
        PlayerPrefs.SetInt("monedasTotales", monedasTotales);
    }
}
