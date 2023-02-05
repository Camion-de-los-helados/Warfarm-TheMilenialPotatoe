using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }


    private Dictionary<CARD_TYPES, int> CardDeck = new Dictionary<CARD_TYPES, int>();

    private GameObject DownPanel;

    private GameObject LeftImage;
    private GameObject RightImage;
    private GameObject MiddleImage;

    public GameObject PotatoBombPrefab = null;
    public GameObject PotatoJumpinPrefab = null;
    public GameObject PotatoBlockPrefab = null;

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
    private void OnEnable()
    {
        DownPanel = GameObject.Find("DownPanel");
    }
    void InitCardDeck()
    {
        CardDeck.Add(CARD_TYPES.BOMB, Const.MAX_BOMBCARD_TYPE);
        CardDeck.Add(CARD_TYPES.JUMPIN, Const.MAX_JUMPINCARD_TYPE);
        CardDeck.Add(CARD_TYPES.BLOCK, Const.MAX_BLOCKCARD_TYPE);
    }


    public void DrawCard(Player player)
    {
        List<CARD_TYPES> TotalCards = CreateCardTypeList();
        TotalCards = RandomizeDeck(TotalCards);
        Debug.Log(TotalCards.Count);
        Debug.Log(CardDeck.Count);
        CARD_TYPES type = TotalCards[Random.Range(0, TotalCards.Count)];

        //Debug.Log(type);
        for (int i = 0; i < TotalCards.Count; i++)
        {
            if (TotalCards[i] == type)
            {
                TotalCards.RemoveAt(i);
                break;
            }
        }
        player.AddCardToPlayer(DrawCardOfSpecificType(type));

        //return DrawCardOfSpecificType(type);
    }
    private List<CARD_TYPES> RandomizeDeck(List<CARD_TYPES> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CARD_TYPES temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }

        return deck;
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
                //int nCards = NumberOfCards - 1;
                //CardDeck[TotalTypes[i]] = nCards;
            }

        }
        return TotalCards;
    }
    public void DeactivateCards()
    {
        PotatoBombCard[] potatosbombs = GameObject.FindObjectsOfType<PotatoBombCard>();
        PotatoJumpinCard[] potatosJumpin = GameObject.FindObjectsOfType<PotatoJumpinCard>();
        PotatoBlockCard[] potatosBlock = GameObject.FindObjectsOfType<PotatoBlockCard>();

        foreach (PotatoBombCard c in potatosbombs)
        {
            c.IsEnable = false;
        }

        foreach (PotatoJumpinCard c in potatosJumpin)
        {
            c.IsEnable = false;
        }

        foreach (PotatoBlockCard c in potatosBlock)
        {
            c.IsEnable = false;
        }
    }

    public void ActivateCards()
    {

        PotatoBombCard[] potatosbombs = GameObject.FindObjectsOfType<PotatoBombCard>();
        PotatoJumpinCard[] potatosJumpin = GameObject.FindObjectsOfType<PotatoJumpinCard>();
        PotatoBlockCard[] potatosBlock = GameObject.FindObjectsOfType<PotatoBlockCard>();

        foreach (PotatoBombCard c in potatosbombs)
        {
            c.IsEnable = true;
        }

        foreach (PotatoJumpinCard c in potatosJumpin)
        {
            c.IsEnable = true;
        }

        foreach (PotatoBlockCard c in potatosBlock)
        {
            c.IsEnable = true;
        }
    }

    internal void LoadSceneVariables(bool cardEnable, Player player)
    {
        DownPanel = GameObject.Find("DownPanel");
        DownPanel.SetActive(true);

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }

        //TopImage = GameObject.Find("TopImage");
        MiddleImage = GameObject.Find("MiddleImage");
        RightImage = GameObject.Find("RightImage");
        LeftImage = GameObject.Find("LeftImage");
        GameObject prefabtoinstantiate = null;
        GameObject[] UIDownCards = { LeftImage, MiddleImage, RightImage };

        player.ReorderCardsInHand();

        for (int i = 0; i < player.m_playerCards.Length; i++)
        {
            if (player.m_playerCards[i] == null)
            {
                break;
            }
            else
            {
                switch (player.m_playerCards[i].Type)
                {
                    case CARD_TYPES.BOMB:
                        prefabtoinstantiate = PotatoBombPrefab;
                        break;
                    case CARD_TYPES.BLOCK:
                        prefabtoinstantiate = PotatoBlockPrefab;
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
                    go.GetComponent<Card>().IsEnable = cardEnable;
                    go.transform.position = UIDownCards[i].transform.position;
                    go.transform.rotation = UIDownCards[i].transform.rotation;

                    go.GetComponent<RectTransform>().sizeDelta = new Vector2(UIDownCards[i].GetComponent<RectTransform>().rect.width,
                        UIDownCards[i].GetComponent<RectTransform>().rect.height);

                    go.transform.SetParent(UIDownCards[i].transform.parent);

                    go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);


                    go.tag = "Card";
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

            case CARD_TYPES.BLOCK:
                GameObject gb = new GameObject();
                PotatoBlockCard pBb = gb.AddComponent<PotatoBlockCard>();
                return pBb;

            default:
                return null;

        }
    }

}

public enum CARD_TYPES
{
    BOMB, JUMPIN, BLOCK
}