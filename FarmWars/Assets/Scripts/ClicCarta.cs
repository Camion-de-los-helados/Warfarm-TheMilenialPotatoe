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
    private Image newImage;
    // Start is called before the first frame update
    void Start()
    {
        newImage = gameObject.GetComponent<Image>();
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
        colorImagen.SetActive(true);

        // El alpha esta bugged en este Unity y por eso hay que setearlo manual.
        imagen.color = new Color(newColor.r, newColor.g, newColor.b, 1f);

        imagen.sprite = newImage.sprite;
        
    }

    public void DisminuirCarta()
    {
        panelGrande.SetActive(false);
        colorImagen.SetActive(false);
    }
}
