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
        Debug.Log("Card Picked");
    }
}
