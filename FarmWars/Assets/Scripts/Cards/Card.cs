using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface ICard
{
    void DoAction();
    CARD_TYPES Type { get; }

    void SetEnable(bool enable);


}

public abstract class Card : MonoBehaviour, ICard
{
    [SerializeField]
    private Image CardImage;

    public abstract void DoAction();
    public CARD_TYPES Type { get; set; }
    public bool IsInTop { get; set; }
    public bool CanZoomOut { get; private set; }
    public bool IsEnable = true;

    public Card()
    {

    }

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
        if (IsInTop && IsEnable)
            DoAction();
    }


    public void ZoomCard()
    {
        //ZoomOutCard();
        if (!IsInTop && IsEnable)
        {
            TopImageBehaviour TIB = GameObject.FindObjectOfType<TopImageBehaviour>();
            TIB.CardInTop = this;
            TIB.ShowCard();

            CanZoomOut = false;
        }
    }


    public void ZoomOutCard()
    {
        //StartCoroutine(WaitAMinuteBitch());
        if (IsInTop && IsEnable)
        {
            TopImageBehaviour TIB = GameObject.FindObjectOfType<TopImageBehaviour>();
            TIB.HideCard();
        }
    }

    public void SetEnable(bool enable)
    {
        this.IsEnable = enable;
    }

    //IEnumerator WaitAMinuteBitch()
    //{
    //    yield return new WaitForSeconds(0.5f);

    //    TopImageBehaviour TIB = GameObject.FindObjectOfType<TopImageBehaviour>();
    //    TIB.HideCard();
    //    CanZoomOut = true;
    //    IsInTop = false;
    //}


}
