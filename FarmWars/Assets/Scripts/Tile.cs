using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color BaseColor, OffsetColor;
    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private GameObject Higlight;
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


    // Start is called before the first frame update
    public void Init(bool isOffset)
    {
        Patata.enabled = false;
        Renderer.color = isOffset ? new Color(OffsetColor.r, OffsetColor.g, OffsetColor.b, OffsetColor.a) : new Color(BaseColor.r, BaseColor.g, BaseColor.b, BaseColor.a);
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
        if (EnableTile && !CheckTraps())
            Higlight.SetActive(true);
    }

    void OnMouseExit()
    {
        if (EnableTile && !CheckTraps())
            Higlight.SetActive(false);
    }

    void OnMouseDown()
    {
        // Put trap
        if (EnableTile && !CheckTraps())
        {

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
            else
            {

                Patata.enabled = true;
                GameManager.m_gameManager.UpdatePatatoPos(x, y);

                if (x == 0 || x == 8)
                {
                    GameManager.m_gameManager.Win();
                }
                else
                {
                    FindObjectOfType<TurnManager>().NextTurn();
                }

            }

        }
        else
        {
            if (EnableTile && CheckTraps())
            {
                Trap();
            }
        }
    }
    private void Trap()
    {
        if (TrapJump.enabled)
        {
            TrapJump.enabled = false;
            JumpEffect();
        }
        if (TrapBomb.enabled)
        {
            TrapBomb.enabled = false;
            BombEffect();
        }
        if (TrapBlock.enabled)
        {
            TrapBlock.enabled = false;
            GameManager.m_gameManager.UpdatePatatoPos(GameManager.m_gameManager.PotatoPosition.x, GameManager.m_gameManager.PotatoPosition.y);
        }

        if (!CheckTraps())
        {
            FindObjectOfType<TurnManager>().NextTurn();
        }
        else
        {
            Trap();
        }

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

    bool CheckTraps()
    {
        return TrapJump.enabled || TrapBlock.enabled || TrapBomb.enabled || Patata.enabled;
    }
}
