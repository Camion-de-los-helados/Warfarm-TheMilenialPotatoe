using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoBombCard : Card
{
    public PotatoBombCard()
    {

    }

    private void Awake()
    {
        Type = CARD_TYPES.BOMB;
    }

    public override void DoAction()
    {
        if (IsEnable)
        {
            GameObject.FindObjectOfType<LeftTopImage>().CardInTopLeft = this;
            GameObject.FindObjectOfType<LeftTopImage>().ShowCard();
        }

    }
}
