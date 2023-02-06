using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct IntensityColors
{
    [SerializeField]
    public Color FirstIntensity, SecondIntensity, ThirdIntensity, ForthIntensity;
}
public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Renderer;


    [SerializeField] private SpriteRenderer Highlight;

    [SerializeField] private Color PotatoMovementHighlightColor;
    [SerializeField] private Color PuttinTrapHighlightColor;


    public float sizeX;
    public float sizeY;

    public int x;
    public int y;

    [SerializeField]
    private SpriteRenderer TrapJump;

    [SerializeField]
    private SpriteRenderer TrapBlock;

    [SerializeField]
    private SpriteRenderer TrapBomb;

    [SerializeField]
    public SpriteRenderer Patata;

    public bool EnableTile = false;
    private bool bPuttinPotato;


    // Start is called before the first frame update
    public void Init(int x, Color color)
    {
        Patata.enabled = false;
        Highlight.enabled = false;
        Renderer.color = new Color(color.r, color.g, color.b, color.a);

    }
    bool CheckTraps()
    {
        return TrapJump.enabled || TrapBlock.enabled || TrapBomb.enabled || Patata.enabled;
    }
    public Vector2 GetSizeofRenderer()
    {
        sizeX = Renderer.bounds.size.x;
        sizeY = Renderer.bounds.size.y;
        //Debug.Log(sizeX + " " + sizeY);
        return new Vector2(sizeX, sizeY);
    }
    void OnMouseEnter()
    {
        if (EnableTile && !Patata.enabled)
        {
            if (bPuttinPotato)
            {
                Highlight.material.SetColor("_Color", new Color(PotatoMovementHighlightColor.r, PotatoMovementHighlightColor.g, PotatoMovementHighlightColor.b, 1));

            }
            else
            {
                Highlight.material.SetColor("_Color", new Color(PuttinTrapHighlightColor.r, PuttinTrapHighlightColor.g, PuttinTrapHighlightColor.b, 1));

            }
            Highlight.enabled = true;

        }
    }

    public void ChanginHighLightColor(bool PuttinPotato)
    {
        bPuttinPotato = PuttinPotato;
    }

    void OnMouseExit()
    {
        Highlight.enabled = false;
    }

    void OnMouseDown()
    {
        if (!Patata.enabled && CheckTraps() && GameObject.FindObjectOfType<TurnManager>().PotatoMoved)
        {
            //Activate Potate trap

            Debug.Log("TRAP");
            Trap();
        }
        else if (EnableTile && !CheckTraps())
        {
            Highlight.enabled = false;
            EnableTile = false;

            LeftTopImage LTI = GameObject.FindObjectOfType<LeftTopImage>();
            if (LTI != null && LTI.CardInTopLeft != null)
            {

                CARD_TYPES CardType = LTI.CardInTopLeft.Type;
                LTI.enabled = false;

                GameObject.FindObjectOfType<TurnManager>().ActualPlayer.RemoveOneCardFromPlayer(CardType);

                LTI.DownPanel.SetActive(true);
                LTI.GOCardInTopLeft.SetActive(false);
                LTI.gameObject.SetActive(false);

                switch (CardType)
                {
                    case CARD_TYPES.BOMB:
                        TrapBomb.enabled = true;
                        break;

                    case CARD_TYPES.JUMPIN:
                        TrapJump.enabled = true;
                        break;

                    case CARD_TYPES.BLOCK:
                        TrapBlock.enabled = true;
                        break;

                    default:
                        break;
                }

                FindObjectOfType<TurnManager>().NextTurn();
                if (GameObject.FindObjectOfType<TurnManager>().PotatoMoved)
                    CardManager.Instance.LoadSceneVariables(false, GameObject.FindObjectOfType<TurnManager>().ActualPlayer);
                else
                    CardManager.Instance.LoadSceneVariables(true, GameObject.FindObjectOfType<TurnManager>().ActualPlayer);
            }
            else if (!Patata.enabled && !CheckTraps())
            {
                Patata.enabled = true;
                GameManager.m_gameManager.UpdatePatatoPos(x, y);

                if (GameManager.m_gameManager.PotatoPosition.x == 0 || GameManager.m_gameManager.PotatoPosition.x == 8)
                {
                    GameManager.m_gameManager.Win();
                }
                else
                {
                    FindObjectOfType<TurnManager>().NextTurn();
                }

            }

        }


    }
    public void Trap()
    {
        if (TrapJump.enabled)
        {
            TrapJump.enabled = false;
            JumpEffect();
        }
        else if (TrapBomb.enabled)
        {
            TrapBomb.enabled = false;
            BombEffect();
        }
        else if (TrapBlock.enabled)
        {
            TrapBlock.enabled = false;
            GameManager.m_gameManager.UpdatePatatoPos(GameManager.m_gameManager.PotatoPosition.x, GameManager.m_gameManager.PotatoPosition.y);
        }
        else
        {
            FindObjectOfType<TurnManager>().NextTurn();
        }

        //if (!CheckTraps())
        //{
        //    FindObjectOfType<TurnManager>().NextTurn();
        //}


    }
    private void JumpEffect()
    {
        Vector2 lastPosition = GameManager.m_gameManager.PotatoPosition;
        if (lastPosition.x == x)
        {
            if (lastPosition.y != y)
            {
                if (lastPosition.y < y)
                {
                    if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                    {
                        GameManager.m_gameManager.UpdatePatatoPos(x, y + 1);
                    }
                }
                else
                {
                    if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                    {
                        GameManager.m_gameManager.UpdatePatatoPos(x, y - 1);
                    }
                }
            }
        }
        if (lastPosition.y == y)
        {
            if (lastPosition.x < x)
            {
                if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x + 1, y);
                }
            }
            else
            {
                if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x - 1, y);
                }
            }
        }
        if (lastPosition.x != x && lastPosition.y != y)
        {
            if (lastPosition.x < x && lastPosition.y < y)
            {
                if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x + 1, y + 1);
                }
            }
            if (lastPosition.x > x && lastPosition.y > y)
            {
                if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x - 1, y - 1);
                }
            }
            if (lastPosition.x < x && lastPosition.y > y)
            {
                if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x + 1, y - 1);
                }
            }

            if (lastPosition.x > x && lastPosition.y > y)
            {
                if ((x >= 0 && x < 9) && (y >= 0 && y < 5))
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x - 1, y + 1);
                }
            }
        }
    }
    private void BombEffect()
    {
        Vector2 lastPosition = GameManager.m_gameManager.PotatoPosition;
        if (lastPosition.x == x)
        {
            if (lastPosition.y != y)
            {
                if (lastPosition.y < y)
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x, y - 1);
                }
                else
                {
                    GameManager.m_gameManager.UpdatePatatoPos(x, y + 1);
                }
            }
        }
        if (lastPosition.y == y)
        {
            if (lastPosition.x < x)
            {
                GameManager.m_gameManager.UpdatePatatoPos(x - 1, y);
            }
            else
            {
                GameManager.m_gameManager.UpdatePatatoPos(x + 1, y);
            }
        }
        if (lastPosition.x != x && lastPosition.y != y)
        {
            if (lastPosition.x < x && lastPosition.y < y) GameManager.m_gameManager.UpdatePatatoPos(x - 1, y - 1);
            if (lastPosition.x > x && lastPosition.y > y) GameManager.m_gameManager.UpdatePatatoPos(x + 1, y + 1);
            if (lastPosition.x < x && lastPosition.y > y) GameManager.m_gameManager.UpdatePatatoPos(x - 1, y + 1);
            if (lastPosition.x > x && lastPosition.y > y) GameManager.m_gameManager.UpdatePatatoPos(x + 1, y - 1);
        }
    }


}
