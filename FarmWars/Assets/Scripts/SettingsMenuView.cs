using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : View
{
    [SerializeField] private Button BackButton;
    public override void Initialize()
    {
        BackButton.onClick.AddListener(() => UIManager.ShowLast());
    }
}
