using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button Play;
    [SerializeField] private Button Settings;
    [SerializeField] private Button Exit;
    
    public override void Initialize()
    {
        Play.onClick.AddListener(() => ChangeScene());
        Settings.onClick.AddListener(() => UIManager.Show<SettingsMenuView>());
        Exit.onClick.AddListener(() => QuitGame());
    }

    private void ChangeScene() 
    {
        SceneManager.LoadScene(1);
    } 

    private void QuitGame() 
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
