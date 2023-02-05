using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoJumpinCard : Card
{
    private void Awake()
    {
        Type = CARD_TYPES.JUMPIN;
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
