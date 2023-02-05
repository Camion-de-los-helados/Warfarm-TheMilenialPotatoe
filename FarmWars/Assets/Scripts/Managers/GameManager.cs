using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region References
    public static GameManager m_gameManager { get; private set; }

    public GridManager m_gridManager { get; private set; }

    public CardManager CardManager { get; private set; }

    [SerializeField]
    private GameObject PotatoBombPrefab;

    [SerializeField]
    private GameObject PotatoJumpinPrefab;

    [SerializeField]
    private GameObject PotatoBlockPrefab;


    #endregion



    #region Properties
    #region Menu
    [Header("Sound")]
    [Range(0, 100)]
    public float _soundVolume;

    [Range(0, 100)]
    public float _effectsVolume;

    [Header("MiniGames")]
    public GameObject _lastWinner;
    #endregion


    public Player PlayerOne;

    public Player PlayerTwo;

    public Player LastMiniGameWinner;
    #endregion



    #region Methods
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }


    #endregion


    private void Awake()
    {
        if (m_gameManager != null && m_gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            //m_gridManager = GridManager.Instance;
            GameObject GO = new GameObject();
            GO.name = "CardManager";

            //Instantiate(GO);
            GO.AddComponent(typeof(CardManager));
            m_gameManager = this;

            PlayerOne = new Player(0);
            PlayerTwo = new Player(1);
            LastMiniGameWinner = PlayerOne;

            CardManager.Instance.PotatoBombPrefab = PotatoBombPrefab;
            CardManager.Instance.PotatoJumpinPrefab = PotatoJumpinPrefab;
            CardManager.Instance.PotatoBlockPrefab = PotatoBlockPrefab;

            CardManager.Instance.DrawCard(LastMiniGameWinner);
          
        }
    }


    void Start()
    {
        DontDestroyOnLoad(this);

        if (PotatoBombPrefab == null || PotatoJumpinPrefab == null || PotatoBlockPrefab == null)
        {
            Debug.LogError("PREFAB NOT FOUND");
        }

    }


}

public enum CardInHand
{
    LEFTCARD,
    MIDDLECARD,
    RIGHTCARD
}
