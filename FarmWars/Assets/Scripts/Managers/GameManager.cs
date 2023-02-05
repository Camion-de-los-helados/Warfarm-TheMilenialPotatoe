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

    public int turn = 0;
    public Vector2Int PotatoPosition;


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
            PlayerOne = new Player(0);
            PlayerTwo = new Player(1);
            PotatoPosition = new Vector2Int(4, 2);

            //m_gridManager = GridManager.Instance;
            GameObject GO = new GameObject();
            GO.name = "CardManager";

            //Instantiate(GO);
            GO.AddComponent(typeof(CardManager));
            m_gameManager = this;

            
            LastMiniGameWinner = PlayerOne;

            CardManager.Instance.PotatoBombPrefab = PotatoBombPrefab;
            CardManager.Instance.PotatoJumpinPrefab = PotatoJumpinPrefab;
            CardManager.Instance.PotatoBlockPrefab = PotatoBlockPrefab;

            //CardManager.Instance.DrawCard(LastMiniGameWinner);

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

    internal void UpdatePatatoPos(int x, int y)
    {
        GridManager.Instance.TilesDictionary.TryGetValue(PotatoPosition, out Tile tile);
        tile.Patata.enabled = false;

        PotatoPosition = new Vector2Int(x, y);

        GridManager.Instance.TilesDictionary.TryGetValue(PotatoPosition, out Tile tile2);
        tile2.Patata.enabled = true;
    }

    internal void Win()
    {
        // actual player winner
        if (LastMiniGameWinner.ID == 0)
        {
            LoadScene(Const.PLAYER1_WIN);
        }
        else
        {
            LoadScene(Const.PLAYER2_WIN);
        }
    }

    public Player GetPlayer(int id)
    {
        if (id == 0)
            return PlayerOne;
        else
            return PlayerTwo;

    }
}

public enum CardInHand
{
    LEFTCARD,
    MIDDLECARD,
    RIGHTCARD
}
