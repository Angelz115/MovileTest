 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TiendaManager : MonoBehaviour
{
    [SerializeField] List<PlantillaInfoItem> informacionItems;
    [SerializeField] GameObject plantillaObjetoTienda;
    [SerializeField] TextMeshProUGUI textoMonedasTotales;
    

    void Start()
    {
        if (!PlayerPrefs.HasKey("monedasTotales"))
        {
            PlayerPrefs.SetInt("monedasTotales", 1000);
            
        }

        var plantillaItem = plantillaObjetoTienda.GetComponent<PlantillaItemTienda>();

        foreach (var item in informacionItems)
        {
            plantillaItem.imagen.sprite = item.imagen;
            plantillaItem.titulo.text = item.titulo;
            plantillaItem.textoPrecio.text = item.precio.ToString();
            Instantiate(plantillaItem, transform); 
        }
    }


    void Update()
    {
        textoMonedasTotales.text = PlayerPrefs.GetInt("monedasTotales").ToString();
    }
}
