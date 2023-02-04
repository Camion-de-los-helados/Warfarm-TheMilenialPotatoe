using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class HotPotato : MonoBehaviour
{
    [SerializeField] public GameObject Mmanager;
    [SerializeField] public Key[] AllKeys = new Key[50];
    [SerializeField] public SpriteRenderer[] SpriteRenderer;

    [SerializeField] public int MaxRounds= 5;
    [SerializeField] private int Rounds;
    [SerializeField] public int IdPlayer = 0;
    
    Array allKeyCodes;
    private int ActualRounds; 
    private Key[] ActualKeys;
    private HotPotatoManager HotPotatoManager;
    private int currentPlayer;
    private bool turnFinished = false; 

    void Awake()
    {
        allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
    }

    // Start is called before the first frame update
    void Start()
    {
        HotPotatoManager = Mmanager.GetComponent<HotPotatoManager>();
        currentPlayer = HotPotatoManager.GetCurrentPlayer();
        ActualKeys = new Key[SpriteRenderer.Length];
        Rounds = Random.Range(1, MaxRounds);
        ActualRounds = 0;
        UpdateActualKeys();
    }

    // Update is called once per frame
    void Update()
    {
        turnFinished = HotPotatoManager.GetHasTurnFinished();
        if (IdPlayer == currentPlayer && !turnFinished)
        {
            if (ActualRounds < MaxRounds)
            {
                foreach (KeyCode tempKey in allKeyCodes)
                {
                    //Send event to key down
                    if (Input.GetKeyDown(tempKey))
                    {
                        VerifyPressKey(tempKey);
                    }
                }


                bool allPressed = true;
                for (int i = 0; i < ActualKeys.Length; i++)
                {
                    if (!ActualKeys[i].IsPressed)
                    {
                        allPressed = false;
                        break;
                    }
                }

                if (allPressed)
                {
                    UpdateActualKeys();
                }
            }
            else if (ActualRounds == MaxRounds)
            {
                CleanScreen();
                HotPotatoManager.FinishedTurn();
                currentPlayer = HotPotatoManager.GetCurrentPlayer();
            }
        }
    }


    void UpdateActualKeys() 
    {
        ActualRounds++;
        int randomLength = Random.Range(1, SpriteRenderer.Length);
        for (int i = 0; i < randomLength; i++)
        {
            bool exist = true;
            while (exist)
            {
                exist = false;
                int randomKey = Random.Range(1, AllKeys.Length);
                Key aux = AllKeys[randomKey];
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

        for (int i = 0; i < SpriteRenderer.Length; i++)
        {
            SpriteRenderer[i].sprite = ActualKeys[i].Sprite;
        }
    }


    void VerifyPressKey(KeyCode keycode)
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
                pressCorrectKey = true;
            }
        }

        if (!pressCorrectKey)
        {
            HotPotatoManager.AddTime();
        }
    }

    private void CleanScreen() 
    {
        for (int i = 0; i < ActualKeys.Length; i++)
        {
            ActualKeys[i].Sprite = null;
            ActualKeys[i].KeyCode = KeyCode.None;
            ActualKeys[i].IsPressed = false;
        }
    }
}
