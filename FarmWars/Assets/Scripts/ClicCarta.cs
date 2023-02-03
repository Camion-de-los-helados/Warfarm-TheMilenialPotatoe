using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClicCarta : MonoBehaviour
{
    public GameObject panelGrande;
    public GameObject colorImagen;
    public Color newColor;
    private Image imagen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        imagen = colorImagen.GetComponentInChildren<Image>();
    }

    public void AumetarCarta()
    {
        panelGrande.SetActive(true);
        imagen.color = newColor;
        //imagen.GetComponent<CanvasRenderer>().SetColor(newColor);
    }

    public void DisminuirCarta()
    {
        panelGrande.SetActive(false);
    }
}
