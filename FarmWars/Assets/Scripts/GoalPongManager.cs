using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class GoalPongManager : MonoBehaviour
{

    public Canvas canvas;
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] Image image;
    [SerializeField] Sprite p1Sprite;
    [SerializeField] Sprite p2Sprite;
    [SerializeField] int PlayerID0;
    [SerializeField] int PlayerID1;

    public void EndGame(int PlayerIDWin)
    {
        tmp.text = "PLAYER " + (PlayerIDWin + 1) + " WINS";
        if (PlayerIDWin.Equals(0))
        {
            image.sprite = p1Sprite;
        }
        else
        {
            image.sprite = p2Sprite;
        }
        canvas.GetComponent<Canvas>().enabled = true;
        Debug.Log("HA GANADO EL PLAYER = " + PlayerIDWin);
    }
}
