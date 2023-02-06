using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : View
{
    [SerializeField] private Button BackButton;
    [SerializeField] private Slider SoundEffects;
    [SerializeField] private Slider Music;

    public override void Initialize()
    {
        BackButton.onClick.AddListener(() => UIManager.ShowLast());
    }
}
