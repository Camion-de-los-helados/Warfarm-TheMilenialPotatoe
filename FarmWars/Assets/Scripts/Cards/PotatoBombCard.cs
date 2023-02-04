using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoBombCard : Card
{

    private void Awake()
    {
        Type = CARD_TYPES.BOMB;
    }

    public override void DoAction()
    {
        Debug.Log("Card Picked");
    }
}
