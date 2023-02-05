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
    public void NextTurn()
    {
        if (BothPlayersPlayed)
        {
            int minigame = Random.Range(2, 5);
            GameManager.m_gameManager.LoadScene(minigame);
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

            CardManager.Instance.DrawCard(ActualPlayer);

            CardManager.Instance.LoadSceneVariables(true, ActualPlayer);
            BothPlayersPlayed = true;

            LeftTopImage.SetActive(true);
            LeftTopImage.GetComponentInChildren<Button>().gameObject.SetActive(false);

        }


    }

    private void Start()
    {
        ActualPlayer = GameManager.m_gameManager.LastMiniGameWinner;
        CardManager.Instance.LoadSceneVariables(true, ActualPlayer);
    }
}
