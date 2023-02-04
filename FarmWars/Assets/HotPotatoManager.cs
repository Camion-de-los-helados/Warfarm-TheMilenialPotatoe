using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotatoManager : MonoBehaviour
{
    private int CurrentPlayer;
    bool HasTurnFinished = false;
    [SerializeField] public float Timer = 0.0f;
    [SerializeField] public float MaxTime = 300.0f;
    [SerializeField] public float PenalisationTime = 20.0f;

    private void Awake()
    {
        PlayerSelected();
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > MaxTime) 
        {
            int winPlayer; 
            if (CurrentPlayer == 0)
            {
                winPlayer = 1;
            }
            else
            {
                winPlayer = 0;
            }
            //GameManager.m_gameManager._lastWinner(winPlayer);
        }
    }

    public void PlayerSelected()
    {
        CurrentPlayer = Random.Range(0, 1);
    }

    public int GetCurrentPlayer()
    {
        return CurrentPlayer;
    }

    public bool GetHasTurnFinished()
    {
        return HasTurnFinished;
    }

    public void FinishedTurn()
    {
        HasTurnFinished = true;
        if (CurrentPlayer == 0)
        {
            CurrentPlayer = 1;
        }
        else 
        {
            CurrentPlayer = 0;
        }
    }

    public void StartTurn() 
    {
        HasTurnFinished = false;
    }

    public void AddTime() 
    {
        Timer += PenalisationTime; 
    }
}
