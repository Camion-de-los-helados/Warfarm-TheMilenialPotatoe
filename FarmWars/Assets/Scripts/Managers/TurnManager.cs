using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    Player ActualPlayer;
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
            int minigame = Random.Range(2, 5);
            GameManager.m_gameManager.LoadScene(minigame);
        }
        else if (BothPlayersPlayed)
        {
            PotatoMoved = true;

            GridManager.Instance.DeactivateTiles();


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

            Debug.Log(ActualPlayer.ID);
            TextP.text = "P" + (ActualPlayer.ID + 1);

            sR.sprite = NewSprite;

            CardManager.Instance.DrawCard(ActualPlayer);

            CardManager.Instance.LoadSceneVariables(true, ActualPlayer);
            BothPlayersPlayed = true;

            LeftTopImage.SetActive(true);
            LeftTopImage.GetComponentInChildren<Button>().gameObject.SetActive(false);
            GridManager.Instance.DeactivateTiles();
        }


    }

    private void Start()
    {
        Debug.Log(GridManager.Instance);
        Debug.Log(GameManager.m_gameManager.PotatoPosition);

        GridManager.Instance.GetTileAtPosition(GameManager.m_gameManager.PotatoPosition).Patata.enabled = true;

        ActualPlayer = GameManager.m_gameManager.LastMiniGameWinner;
        CardManager.Instance.LoadSceneVariables(true, ActualPlayer);
    }


}
