using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICard
{
    void DoAction();
    CARD_TYPES Type { get; }
}

public abstract class Card : MonoBehaviour, ICard
{
    [SerializeField]
    private Image CardImage;

    public abstract void DoAction();
    public  CARD_TYPES Type { get; set; }



    //[SerializeField]
    //private GameObject BigPanel;


    //[SerializeField]
    //private Image TopZoomImage;
    //[SerializeField]
    //private Image NewImage;


    void OnMouseOver()
    {
        ZoomCard();
    }

    void OnMouseExit()
    {
        ZoomOutCard();
    }


    void OnMouseDown()
    {
        DoAction();
    }


    public void ZoomCard()
    {
        //BigPanel.SetActive(true);
        //TopZoomImage.sprite = NewImage.sprite;
    }

    public void ZoomOutCard()
    {
        //BigPanel.SetActive(false);
    }

}
