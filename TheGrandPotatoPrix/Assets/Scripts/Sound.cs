using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public enum AudioTypes { soundEffect, music }
    public AudioTypes AudioType;
    [HideInInspector] public AudioSource Source;
    public string ClipName;
    public AudioClip AudioClip;
    public bool IsLoop;
    public bool PlayOnAwake;

    [Range(0, 1)]
    public float Volume = 0.0f; 
    
}
