using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class HotPotato : MonoBehaviour
{
    [SerializeField] public GameObject Mmanager;
    [SerializeField] public Key[] AllKeys = new Key[40];
    [SerializeField] public SpriteRenderer[] SpritesRendrersPlayerP0;
    [SerializeField] public SpriteRenderer[] SpritesRendrersPlayerP1;
    [SerializeField] public SpriteRenderer[] SpritesOkP0;
    [SerializeField] public SpriteRenderer[] SpritesOkP1;
    [SerializeField] public Sprite OkKey;
    [SerializeField] public Win win;

    [SerializeField] public int MaxRounds = 2;
    [SerializeField] private int Rounds;
    [SerializeField] public int IdPlayer0 = 0;
    [SerializeField] public int IdPlayer1 = 1;

    [SerializeField] public float TimerMiniGame = 0.0f;
    [SerializeField] public float MaxTime = 60.0f;

    bool StartGame = false;

    Array allKeyCodes;
    private int ActualRounds;
    private Key[] ActualKeysP0;
    private Key[] ActualKeysP1;

    private int currentPlayer;
    //private bool turnFinished = false; 

    public float animationTime = 1.0f;
    public float auxTimer = 0.0f;


    [SerializeField] public Sprite[] spritesPatato;
    [SerializeField] public SpriteRenderer ActualSpritePotato;
    [SerializeField] public Sprite[] BackGrounds;
    [SerializeField] public SpriteRenderer BackgroundGame;

    [SerializeField] public GameObject CanvasPressKey;

    void Awake()
    {
        allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = 0;
        BackgroundGame.sprite = BackGrounds[currentPlayer];
        ActualKeysP0 = new Key[4];
        ActualKeysP1 = new Key[4];
        Rounds = 5;
        ActualRounds = 0;
    }

    public void InitializeGame() 
    {
        if (currentPlayer == IdPlayer0)
        {
            UpdateActualKeys(SpritesRendrersPlayerP0, SpritesOkP0, ActualKeysP0, AllKeys);
        }
        else
        {
            UpdateActualKeys(SpritesRendrersPlayerP1, SpritesOkP1, ActualKeysP1, AllKeys);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame == false)
        {
            CleanScreen(SpritesRendrersPlayerP0, SpritesOkP0, ActualKeysP0);
            CleanScreen(SpritesRendrersPlayerP1, SpritesOkP1, ActualKeysP1);
            ActualSpritePotato.sprite = null;

            foreach (KeyCode tempKey in allKeyCodes)
            {
                //Send event to key down
                if (Input.GetKeyDown(tempKey))
                {

                   StartGame = true;
                   InitializeGame();
                }
            }

            CanvasPressKey.SetActive(true);
        }
        else
        {
            CanvasPressKey.SetActive(false);

            TimerMiniGame += Time.deltaTime;

            RenderPotato();

            if (currentPlayer == IdPlayer0)
            {
                Check(SpritesRendrersPlayerP0, SpritesOkP0, ActualKeysP0, AllKeys);
            }
            else if (currentPlayer == IdPlayer1)
            {
                Check(SpritesRendrersPlayerP1, SpritesOkP1, ActualKeysP1, AllKeys);
            }
            else if (currentPlayer == -1)
            {
                Debug.Log("CAMBIAR DE ESCENA!!!!!!!!!!!!!!!!!!!!");
            }
        }
    }


    void Check(SpriteRenderer[] spriteRenderers, SpriteRenderer[] spriteOk, Key[] actualKeys, Key[] allKeys) 
    {
        if (ActualRounds < Rounds)
        {
            foreach (KeyCode tempKey in allKeyCodes)
            {
                //Send event to key down
                if (Input.GetKeyDown(tempKey))
                {
                    VerifyPressKey(tempKey, actualKeys, spriteOk);
                }
            }


            bool allPressed = true;
            for (int i = 0; i < actualKeys.Length; i++)
            {
                if (!actualKeys[i].IsPressed)
                {
                    allPressed = false;
                    break;
                }
            }

            if (allPressed)
            {
                UpdateActualKeys(spriteRenderers, spriteOk, actualKeys, allKeys);
            }
        }
        else if (ActualRounds >= Rounds)
        {
          //  Debug.Log("END TURN = " + currentPlayer);
            CleanScreen(spriteRenderers, spriteOk, actualKeys);
            ActualRounds = 0;
            if (currentPlayer == 0)
            {
                currentPlayer = 1;
                UpdateActualKeys(SpritesRendrersPlayerP1, SpritesOkP1, ActualKeysP1, AllKeys);
            }
            else if (currentPlayer == 1)
            { 
                currentPlayer = 0;
                UpdateActualKeys(SpritesRendrersPlayerP0, SpritesOkP0, ActualKeysP0, AllKeys);
            }
            //FinishedTurn();
            //Debug.Log("START TURN = " + currentPlayer);

        }
    }


    void RenderPotato() 
    {
        float range = MaxTime / 6;
        if (TimerMiniGame < range)
        {
            ActualSpritePotato.sprite = spritesPatato[0];
        }
        else if (TimerMiniGame > range && TimerMiniGame < range * 2)
        {
            ActualSpritePotato.sprite = spritesPatato[1];
        }
        else if (TimerMiniGame > range * 2 && TimerMiniGame < range * 3)
        {
            ActualSpritePotato.sprite = spritesPatato[2];
        }
        else if (TimerMiniGame > range * 3 && TimerMiniGame < range * 4)
        {
            ActualSpritePotato.sprite = spritesPatato[3];
        }
        else if (TimerMiniGame > range * 4 && TimerMiniGame < range * 5)
        {
            ActualSpritePotato.sprite = spritesPatato[4];
        }
        else if (TimerMiniGame > range * 5)
        {
            ActualSpritePotato.sprite = spritesPatato[5];
        }


        if (TimerMiniGame > MaxTime)
        {
            ActualSpritePotato.sprite = spritesPatato[10];
            if (currentPlayer == IdPlayer0)
            {
                CleanScreen(SpritesRendrersPlayerP0, SpritesOkP0, ActualKeysP0);
                win.FinishGame(IdPlayer1);
                //Debug.Log("PERDIO EL PLAYER 0");
                //GameManager.m_gameManager._lastWinner(IdPlayer1);
            }
            else if (currentPlayer == IdPlayer1)
            {
                CleanScreen(SpritesRendrersPlayerP1, SpritesOkP1, ActualKeysP1);
                win.FinishGame(IdPlayer0);
                //Debug.Log("PERDIO EL PLAYER 1");
                //GameManager.m_gameManager._lastWinner(IdPlayer0);
            }
            currentPlayer = -1;
            /*auxTimer += Time.deltaTime;
            float rangeAnimation = animationTime / 5;
            if (auxTimer < rangeAnimation)
            {
                ActualSpritePotato.sprite = spritesPatato[6];
            }
            else if (auxTimer > rangeAnimation && auxTimer < rangeAnimation * 2)
            {
                ActualSpritePotato.sprite = spritesPatato[7];
            }
            else if (auxTimer > rangeAnimation * 2 && auxTimer < rangeAnimation * 3)
            {
                ActualSpritePotato.sprite = spritesPatato[8];
            }
            else if (auxTimer > rangeAnimation * 3 && auxTimer < rangeAnimation * 4)
            {
                ActualSpritePotato.sprite = spritesPatato[9];
            }
            else if (auxTimer > animationTime * 4)
            {
                ActualSpritePotato.sprite = spritesPatato[10];
            }*/
        }
    }


    void UpdateActualKeys(SpriteRenderer[] spriteRenderers, SpriteRenderer[] spriteOk, Key[] ActualKeys, Key[] allKeys)
    {
        ActualRounds++;
        int randomLength = 4;
        for (int i = 0; i < randomLength; i++)
        {
            bool exist = true;
            while (exist)
            {
                exist = false;
                int randomKey = Random.Range(1, allKeys.Length);
                Key aux = allKeys[randomKey];
                for (int j = 0; j < ActualKeys.Length; j++)
                {
                    if (aux.KeyCode == ActualKeys[j].KeyCode)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    ActualKeys[i] = aux;
                }
            }
        }

        for (int i = randomLength; i < ActualKeys.Length; i++)
        {
            ActualKeys[i].Sprite = null;
            ActualKeys[i].KeyCode = KeyCode.None;
        }

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = ActualKeys[i].Sprite;
            spriteOk[i].sprite = null;
        }
    }


    void VerifyPressKey(KeyCode keycode, Key[] ActualKeys, SpriteRenderer[] ActualSpritesOk)
    {
        bool pressCorrectKey = false;
        for (int i = 0; i < ActualKeys.Length; i++)
        {
            if (ActualKeys[i].KeyCode == KeyCode.None)
            {
                ActualKeys[i].IsPressed = true;
            }

            if (ActualKeys[i].KeyCode == keycode)
            {
                ActualKeys[i].IsPressed = true;
                ActualSpritesOk[i].sprite = OkKey;
                pressCorrectKey = true;
            }
        }

        if (!pressCorrectKey)
        {
            TimerMiniGame += 20;
        }
    }

    private void CleanScreen(SpriteRenderer[] spritesRendrers, SpriteRenderer[] spritesOk, Key[] actualKeys)
    {
        for (int i = 0; i < actualKeys.Length; i++)
        {
            actualKeys[i].Sprite = null;
            actualKeys[i].KeyCode = KeyCode.None;
            actualKeys[i].IsPressed = false;
        }

        for (int i = 0; i < spritesRendrers.Length; i++)
        {
            spritesRendrers[i].sprite = actualKeys[i].Sprite;
            spritesOk[i].sprite = null;
        }
    }

    public void FinishedTurn()
    {
        ActualRounds = 0;
        Rounds = 5;
        if (currentPlayer == 0)
        {
            currentPlayer = 1;
            BackgroundGame.sprite = BackGrounds[currentPlayer];
        }
        else
        {
            currentPlayer = 0;
            BackgroundGame.sprite = BackGrounds[currentPlayer];
        }
    }
}
