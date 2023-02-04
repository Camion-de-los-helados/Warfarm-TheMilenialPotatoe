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
    [Header("Sound")]
    [Range(0,100)]
    public float _soundVolume;
    [Range(0, 100)]
    public float _effectsVolume;

    [Header("MiniGames")]
    public GameObject _lastWinner;
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
            m_gameManager = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        m_gridManager = GridManager.Instance;
    }
}
