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

    public GameObject PotatoBombPrefab = null;
    public GameObject PotatoJumpinPrefab = null;

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
        CardDeck.Add(CARD_TYPES.JUMPIN, Const.MAX_JUMPINCARD_TYPE);
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

            for (int j = 0; j < NumberOfCards; j++)
            {
                TotalCards.Add(TotalTypes[i]);
                int nCards = NumberOfCards - 1;
                CardDeck[TotalTypes[i]] = nCards;
            }

        }
        return TotalCards;
    }

    internal void LoadSceneVariables(GameObject cardCanvas, Player localPlayer)
    {

        DrawCard(localPlayer);

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
                    case CARD_TYPES.JUMPIN:
                        prefabtoinstantiate = PotatoJumpinPrefab;
                        break;

                    default:
                        break;
                }

                if (prefabtoinstantiate != null)
                {
                    GameObject go = Instantiate(prefabtoinstantiate);
                    go.transform.position = UIDownCards[i].transform.position;
                    go.transform.rotation = UIDownCards[i].transform.rotation;

                    go.GetComponent<RectTransform>().sizeDelta = new Vector2(UIDownCards[i].GetComponent<RectTransform>().rect.width,
                        UIDownCards[i].GetComponent<RectTransform>().rect.height);

                    go.transform.SetParent(UIDownCards[i].transform.parent);

                    go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                    go.name = "Card " + UIDownCards[i].name;
                }
            }
        }
    }

    public Card DrawCardOfSpecificType(CARD_TYPES type)
    {
        switch (type)
        {
            case CARD_TYPES.BOMB:
                GameObject go = new GameObject();
                PotatoBombCard pBt = go.AddComponent<PotatoBombCard>();
                return pBt;

            case CARD_TYPES.JUMPIN:
                GameObject g = new GameObject();
                PotatoJumpinCard pB = g.AddComponent<PotatoJumpinCard>();
                return pB;

            default:
                return null;

        }
    }

}

public enum CARD_TYPES
{
    BOMB, JUMPIN
}