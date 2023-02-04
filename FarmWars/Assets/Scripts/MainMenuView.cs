using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button Settings;
    [SerializeField] private Button Exit;
    public override void Initialize()
    {
        Settings.onClick.AddListener(() => UIManager.Show<SettingsMenuView>());
        Exit.onClick.AddListener(() => QuitGame());
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
