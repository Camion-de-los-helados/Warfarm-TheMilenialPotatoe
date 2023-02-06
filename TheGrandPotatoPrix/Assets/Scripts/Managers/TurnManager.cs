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
    public Sprite RedSprite;
    public Sprite BlueSprite;

    public bool PotatoMoved = false;

    public void NextTurn()
    {
        if (PotatoMoved)
        {
            PotatoMoved = false;
            if (GameManager.m_gameManager.PotatoPosition.x == 0 || GameManager.m_gameManager.PotatoPosition.x == 8)
            {
                GameManager.m_gameManager.Win();
            }
            else
            {
                GridManager.Instance.DeActivateTilesObject();

                int minigame = Random.Range(2, 6);
                //TODO: Show canvas of loading minigame
                GameManager.m_gameManager.LoadScene(minigame);
                
            }
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

            GridManager.Instance.PuttinPotato();
        }
        else
        {
            GridManager.Instance.PuttinTrap();
            if (ActualPlayer.ID == 0)
            {
                ActualPlayer = GameManager.m_gameManager.PlayerTwo;
            }
            else
            {
                ActualPlayer = GameManager.m_gameManager.PlayerOne;
            }

            //Debug.Log(ActualPlayer.ID);


            CardManager.Instance.DrawCard(ActualPlayer);

            PotatoMoved = false;

            BothPlayersPlayed = true;

            LeftTopImage.SetActive(true);
            LeftTopImage.GetComponentInChildren<Button>().gameObject.SetActive(false);
            GridManager.Instance.DeactivateTiles();
        }

        TextP.text = "P" + (ActualPlayer.ID + 1);

        if (ActualPlayer.ID == 0)
            sR.sprite = BlueSprite;
        else if (ActualPlayer.ID == 1)
            sR.sprite = RedSprite;

    }

  

    private void Start()
    {

        //GridManager.Instance.GetTileAtPosition(GameManager.m_gameManager.PotatoPosition).Patata.enabled = true;
        ActualPlayer = GameManager.m_gameManager.GetPlayer(GameManager.m_gameManager.LastMiniGameWinner.ID == 1 ? 0 : 1);

        CardManager.Instance.DrawCard(GameManager.m_gameManager.LastMiniGameWinner);
        CardManager.Instance.DrawCard(ActualPlayer);
        CardManager.Instance.DrawCard(ActualPlayer);

        //GameManager.m_gameManager.UpdatePatatoPos(GameManager.m_gameManager.PotatoPosition.x, GameManager.m_gameManager.PotatoPosition.y);


        Vector2Int PotatoPosition = new Vector2Int(GameManager.m_gameManager.PotatoPosition.x, GameManager.m_gameManager.PotatoPosition.y);

        GridManager.Instance.TilesDictionary.TryGetValue(PotatoPosition, out Tile tile2);
        tile2.Patata.enabled = true;






        CardManager.Instance.LoadSceneVariables(true, ActualPlayer);
        GridManager.Instance.ActivateTilesObject();
        GridManager.Instance.DeactivateTiles();
        CardManager.Instance.ActivateCards();
        TextP.text = "P" + (ActualPlayer.ID + 1);
    }


}