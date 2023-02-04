using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region References
    public static GameManager m_gameManager { get; private set; }
    public GridManager m_gridManager { get; private set; }
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
    private List<GameObject> m_player1Cards;
    private List<GameObject> m_player2Cards;
    #endregion

    #region Methods
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void AddCardToPlayer(int player, GameObject card)
    {
        if(player == 0)
        {
            m_player1Cards.Add(card);
        }
        else
        {
            m_player2Cards.Add(card);
        }
    }
    public void RemoveCardFromPlayer(int player, GameObject card)
    {
        if (player == 0)
        {
            m_player1Cards.Remove(card);
        }
        else
        {
            m_player2Cards.Remove(card);
        }
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
            m_gameManager = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        m_gridManager = GridManager.Instance;
        m_player1Cards = new List<GameObject>();
        m_player2Cards = new List<GameObject>();
    }
}
