using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    [SerializeField]
    private Dictionary<CARD_TYPES, int> CardDeck = new Dictionary<CARD_TYPES, int>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            InitCardDeck();
        }
    }

    void InitCardDeck()
    {
        CardDeck.Add(CARD_TYPES.BOMB, Const.MAX_BOMBCARD_TYPE);
    }


    Card DrawCard()
    {
        List<CARD_TYPES> TotalCards = CreateCardTypeList();

        CARD_TYPES type = TotalCards[Random.Range(0, TotalCards.Count)];

        return DrawCardOfSpecificType(type);
    }

    private List<CARD_TYPES> CreateCardTypeList()
    {
        List<CARD_TYPES> TotalCards = new List<CARD_TYPES>();

        List<CARD_TYPES> TotalTypes = CardDeck.Keys.ToList();

        for (int i = 0; i < TotalTypes.Count; i++)
        {
            CardDeck.TryGetValue(TotalTypes[i], out int NumberOfCards);

            for (int j = 0; j < NumberOfCards; j++)
            {
                TotalCards.Add(TotalTypes[i]);
            }

        }
        return TotalCards;
    }

    Card DrawCardOfSpecificType(CARD_TYPES type)
    {
        switch (type)
        {
            case CARD_TYPES.BOMB:
                return new PotatoBombCard();

            default:
                return null;

        }
    }

}

public enum CARD_TYPES
{
    BOMB
}