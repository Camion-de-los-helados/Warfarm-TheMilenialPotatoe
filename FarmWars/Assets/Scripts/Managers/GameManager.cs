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
    private Player LocalPlayer;
    private Player RemotePlayer;

    public Player LastMiniGameWinner;

    public Scene activeScene;
    #endregion

    #region Methods
    public void LoadScene(int id)
    {
        activeScene = SceneManager.GetSceneAt(id);
        SceneManager.LoadScene(id);
        SceneChanged();
    }

    private void SceneChanged()
    {
        switch (activeScene.name)
        {
            case "TestTilesMap":
                GameObject CardCanvas = GameObject.Find("CardCanvas");
                CardManager.Instance.LoadSceneVariables(CardCanvas, LocalPlayer);
                break;

            default:
                Debug.LogWarning("Scene not found");
                break;
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
        //m_gridManager = GridManager.Instance;

        GameObject GO = new GameObject();
        GO.name = "CardManager";
        //Instantiate(GO);
        GO.AddComponent(typeof(CardManager));

        LocalPlayer = new Player();
        RemotePlayer = new Player();

        CardManager.Instance.DrawCard(LocalPlayer);
        SceneChanged();


    }

}


public enum CardInHand
{
    LEFTCARD, MIDDLECARD, RIGHTCARD
}