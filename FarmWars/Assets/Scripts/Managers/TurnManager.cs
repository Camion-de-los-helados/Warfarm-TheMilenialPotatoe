using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Player ActualPlayer;
    public bool BothPlayersPlayed = false;

    public GameObject LeftTopImage;
    public TMP_Text TextP;
    public SpriteRenderer sR;
    public Sprite NewSprite;

    public bool PotatoMoved = false;

    public void NextTurn()
    {
        if (PotatoMoved)
        {
            GridManager.Instance.DeActivateTilesObject();

            int minigame = Random.Range(2, 5);

            GameManager.m_gameManager.LoadScene(Const.HOT_POTATO_SCENE_ID);
        }
        else if (BothPlayersPlayed)
        {
            PotatoMoved = true;

            GridManager.Instance.DeactivateTiles();
            CardManager.Instance.DeactivateCards();

            Vector2Int PPosition = GameManager.m_gameManager.PotatoPosition;

            GridManager.Instance.EnableSpecificTile(PPosition.x + 1, PPosition.y + 1);
            GridManager.Instance.EnableSpecificTile(PPosition.x - 1, PPosition.y - 1);
            GridManager.Instance.EnableSpecificTile(PPosition.x + 1, PPosition.y - 1);
            GridManager.Instance.EnableSpecificTile(PPosition.x - 1, PPosition.y + 1);
            GridManager.Instance.EnableSpecificTile(PPosition.x, PPosition.y + 1);
            GridManager.Instance.EnableSpecificTile(PPosition.x, PPosition.y - 1);
            GridManager.Instance.EnableSpecificTile(PPosition.x + 1, PPosition.y);
            GridManager.Instance.EnableSpecificTile(PPosition.x - 1, PPosition.y);

        }
        else
        {
            if (ActualPlayer.ID == 0)
            {
                ActualPlayer = GameManager.m_gameManager.PlayerTwo;
            }
            else
            {
                ActualPlayer = GameManager.m_gameManager.PlayerOne;
            }

            //Debug.Log(ActualPlayer.ID);
            TextP.text = "P" + (ActualPlayer.ID + 1);

            sR.sprite = NewSprite;

            CardManager.Instance.DrawCard(ActualPlayer);
            CardManager.Instance.DrawCard(ActualPlayer);


            BothPlayersPlayed = true;

            LeftTopImage.SetActive(true);
            LeftTopImage.GetComponentInChildren<Button>().gameObject.SetActive(false);
            GridManager.Instance.DeactivateTiles();
        }


    }

    private void Start()
    {

        //GridManager.Instance.GetTileAtPosition(GameManager.m_gameManager.PotatoPosition).Patata.enabled = true;
        ActualPlayer = GameManager.m_gameManager.LastMiniGameWinner;
        CardManager.Instance.DrawCard(ActualPlayer);

        GameManager.m_gameManager.UpdatePatatoPos(GameManager.m_gameManager.PotatoPosition.x, GameManager.m_gameManager.PotatoPosition.y);

        CardManager.Instance.LoadSceneVariables(true, ActualPlayer);
        GridManager.Instance.ActivateTilesObject();
        GridManager.Instance.DeactivateTiles();
        CardManager.Instance.ActivateCards();
        TextP.text = "P" + (ActualPlayer.ID + 1);
    }


}
