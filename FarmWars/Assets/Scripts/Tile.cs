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
    [SerializeField]
    private SpriteRenderer TrapJump;

    [SerializeField]
    private SpriteRenderer TrapBlock;

    [SerializeField]
    private SpriteRenderer TrapBomb;

    public bool EnableTile = false;

    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    public void Init(bool isOffset)
    {
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
        if (EnableTile)
            Higlight.SetActive(true);
    }

    void OnMouseExit()
    {
        if (EnableTile)
            Higlight.SetActive(false);
    }

    void OnMouseDown()
    {
        // Put trap
        if (EnableTile)
        {

            LeftTopImage LTI = GameObject.FindObjectOfType<LeftTopImage>();

            CARD_TYPES CardType = LTI.CardInTopLeft.Type;
            LTI.enabled = false;

            GameManager.m_gameManager.LocalPlayer.RemoveOneCardFromPlayer(CardType);
            CardManager.Instance.LoadSceneVariables(false);
            GridManager.Instance.DeactivateTiles();
            CardManager.Instance.DeactivateCards();


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
        }
    }
}
