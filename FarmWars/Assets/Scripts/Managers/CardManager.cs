using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    [SerializeField]
    private Dictionary<CARD_TYPES, int> CardDeck = new Dictionary<CARD_TYPES, int>();


    private GameObject TopImage;
    private GameObject LeftImage;
    private GameObject RightImage;
    private GameObject MiddleImage;

    private GameObject PotatoBombPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            InitCardDeck();
        }
    }

    void InitCardDeck()
    {
        CardDeck.Add(CARD_TYPES.BOMB, Const.MAX_BOMBCARD_TYPE);
    }


    public void DrawCard(Player player)
    {
        List<CARD_TYPES> TotalCards = CreateCardTypeList();

        CARD_TYPES type = TotalCards[Random.Range(0, TotalCards.Count)];

        player.AddCardToPlayer(DrawCardOfSpecificType(type));

        //return DrawCardOfSpecificType(type);
    }

    private List<CARD_TYPES> CreateCardTypeList()
    {
        List<CARD_TYPES> TotalCards = new List<CARD_TYPES>();

        List<CARD_TYPES> TotalTypes = CardDeck.Keys.ToList();

        for (int i = 0; i < TotalTypes.Count; i++)
        {
            CardDeck.TryGetValue(TotalTypes[i], out int NumberOfCards);
            int nCards = NumberOfCards--;

            CardDeck[TotalTypes[i]]= nCards;

            for (int j = 0; j < NumberOfCards; j++)
            {
                TotalCards.Add(TotalTypes[i]);
            }

        }
        return TotalCards;
    }

    internal void LoadSceneVariables(GameObject cardCanvas, Player localPlayer)
    {
        TopImage = GameObject.Find("TopImage");
        MiddleImage = GameObject.Find("MiddleImage");
        RightImage = GameObject.Find("RightImage");
        LeftImage = GameObject.Find("LeftImage");
        GameObject prefabtoinstantiate = null;
        GameObject[] UIDownCards = { LeftImage, MiddleImage, RightImage };


        for (int i = 0; i < localPlayer.m_playerCards.Length; i++)
        {
            if (localPlayer.m_playerCards[i] == null)
            {
                break;
            }
            else
            {

                switch (localPlayer.m_playerCards[i].Type)
                {
                    case CARD_TYPES.BOMB:
                        prefabtoinstantiate = PotatoBombPrefab;
                        break;
                    default:
                        break;
                }

                if (prefabtoinstantiate != null)
                {
                    GameObject go=Instantiate(prefabtoinstantiate, UIDownCards[i].transform);
                    go.name = "Card "+UIDownCards[i].name;
                }
            }
        }
    }

    public Card DrawCardOfSpecificType(CARD_TYPES type)
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