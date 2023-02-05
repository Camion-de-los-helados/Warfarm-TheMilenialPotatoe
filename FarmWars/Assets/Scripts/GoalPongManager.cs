using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalPongManager : MonoBehaviour
{
    
    [SerializeField] int PlayerID0;
    [SerializeField] int PlayerID1;
    public void EndGame(int PlayerIDWin)
    {
       Debug.Log("HA GANADO EL PLAYER = " + PlayerIDWin);
    }
}
