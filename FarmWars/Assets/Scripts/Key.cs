using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct Key 
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] public KeyCode KeyCode;
    [SerializeField] public bool IsPressed;
}
