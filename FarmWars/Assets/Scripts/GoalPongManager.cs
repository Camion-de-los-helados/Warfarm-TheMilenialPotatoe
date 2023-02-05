using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoalPongManager : MonoBehaviour
{
    [SerializeField]
    int PlayerID0;

    [SerializeField]
    int PlayerID1;

    [SerializeField]
    Win win;

    public void EndGame(int PlayerIDWin)
    {
        win.FinishGame (PlayerIDWin);
        Debug.Log("HA GANADO EL PLAYER = " + PlayerIDWin);
    }
}
