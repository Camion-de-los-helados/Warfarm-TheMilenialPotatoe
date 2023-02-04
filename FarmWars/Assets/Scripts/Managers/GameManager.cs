using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region References
    public static GameManager m_gameManager { get; private set; }
    private List<AudioSource> m_audioSources;
    #endregion
    
    #region Properties
    [Header("Sound")]
    [Range(0,100)]
    public float _audioVolume;
    #endregion

    #region Methods
    public void LoadScene(int id)
    {
        ClearAudioSources();
        SceneManager.LoadScene(id);
        UpdateVolume();
    }
    private void ClearAudioSources()
    {
        m_audioSources.Clear();
    }
    public void AddAudioSource(AudioSource audio)
    {
        m_audioSources.Add(audio);
    }
    private void UpdateVolume()
    {
        foreach(AudioSource audio in m_audioSources)
        {
            audio.volume = _audioVolume;
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
        m_audioSources = new List<AudioSource>();
    }

    void Update()
    {
        
    }
}
