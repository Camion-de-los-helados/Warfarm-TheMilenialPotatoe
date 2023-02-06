using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuView : View
{
    [SerializeField] private Button Continue;
    [SerializeField] private Button Settings;
    [SerializeField] private Button Exit;

    public override void Initialize()
    {
        //Cotinue.onClick.AddListener(() => ContinueGame());
        Settings.onClick.AddListener(() => UIManager.Show<SettingsMenuView>());
        Exit.onClick.AddListener(() => QuitGame());
    }

    private void ContinueGame()
    {
        //Falta el continue
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
