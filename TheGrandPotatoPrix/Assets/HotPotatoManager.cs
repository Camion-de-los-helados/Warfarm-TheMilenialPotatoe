using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPotatoManager : MonoBehaviour
{
    [SerializeField] public int CurrentPlayerID;
    public bool HasTurnFinished = false;
    [SerializeField] public float Timer = 0.0f;
    [SerializeField] public float MaxTime = 300.0f;
    [SerializeField] public float PenalisationTime = 20.0f;
    [SerializeField] public Sprite[] spritesPatato;
    [SerializeField] public SpriteRenderer ActualSprite;
    [SerializeField] public Sprite[] BackGrounds;
    [SerializeField] public SpriteRenderer BackgroundGame;

    public float animationTime = 1.0f;
    public float auxTimer = 0.0f;
    private void Awake()
    {
        PlayerSelected();
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        float range = MaxTime / 6;
        if (Timer < range)
        {
            ActualSprite.sprite = spritesPatato[0];
        }
        else if (Timer > range && Timer < range * 2)
        {
            ActualSprite.sprite = spritesPatato[1];
        }
        else if (Timer > range * 2 && Timer < range * 3)
        {
            ActualSprite.sprite = spritesPatato[2];
        }
        else if (Timer > range * 3 && Timer < range * 4)
        {
            ActualSprite.sprite = spritesPatato[3];
        }
        else if (Timer > range * 4 && Timer < range * 5)
        {
            ActualSprite.sprite = spritesPatato[4];
        }
        else if (Timer > range * 5)
        {
            ActualSprite.sprite = spritesPatato[5];
        }


        if (Timer > MaxTime)
        {
            auxTimer += Time.deltaTime;
            float rangeAnimation = animationTime / 5;
            if (auxTimer < rangeAnimation)
            {
                ActualSprite.sprite = spritesPatato[6];
            }
            else if (auxTimer > rangeAnimation && auxTimer < rangeAnimation * 2)
            {
                ActualSprite.sprite = spritesPatato[7];
            }
            else if (auxTimer > rangeAnimation * 2 && auxTimer < rangeAnimation * 3)
            {
                ActualSprite.sprite = spritesPatato[8];
            }
            else if (auxTimer > rangeAnimation * 3 && auxTimer < rangeAnimation * 4)
            {
                ActualSprite.sprite = spritesPatato[9];
            }
            else if (auxTimer > animationTime * 4 && auxTimer < rangeAnimation * 5)
            {
                ActualSprite.sprite = spritesPatato[10];
            }
            else if (auxTimer > animationTime * 5)
            {

                int winPlayer;
                if (CurrentPlayerID == 0)
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
    }

    public void PlayerSelected()
    {
        //CurrentPlayer = 0;
        BackgroundGame.sprite = BackGrounds[CurrentPlayerID];
    }

    public int GetCurrentPlayer()
    {
        return CurrentPlayerID;
    }

    public bool GetHasTurnFinished()
    {
        return HasTurnFinished;
    }

    public void FinishedTurn()
    {
        //HasTurnFinished = true;
        if (CurrentPlayerID == 0)
        {
            CurrentPlayerID = 1;
            BackgroundGame.sprite = BackGrounds[CurrentPlayerID];
        }
        else
        {
            CurrentPlayerID = 0;
            BackgroundGame.sprite = BackGrounds[CurrentPlayerID];
        }
    }

    public void StartTurn()
    {
        HasTurnFinished = false;
    }

    public void AddTime()
    {
        Debug.Log("ADD TIME");
        Timer += PenalisationTime;
    }
}
