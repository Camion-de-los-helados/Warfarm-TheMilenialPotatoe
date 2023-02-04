using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixerGroup MusicMixerGroup;
    [SerializeField] private AudioMixerGroup SoundEffectsMixerGroup;

    [SerializeField] private Sound[] Sounds;

    public static float MusicVolume { get; private set; }
    public static float SoundEffectsVolume { get; private set; }

    private void Awake()
    {
        Instance = this;

        foreach (Sound sound in Sounds) 
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.AudioClip;
            sound.Source.loop = sound.IsLoop;
            sound.Source.volume = sound.Volume;

            switch (sound.AudioType)
            {
                case Sound.AudioTypes.soundEffect:
                    sound.Source.outputAudioMixerGroup = SoundEffectsMixerGroup;
                    break;

                case Sound.AudioTypes.music:
                    sound.Source.outputAudioMixerGroup = MusicMixerGroup;
                    break;
            }
            if (sound.PlayOnAwake)
            {
                sound.Source.Play();
            }
        }
    }

    public void Play(string clipname)
    {
        Sound sound = Array.Find(Sounds, dummySound => dummySound.ClipName == clipname);
        if (sound == null)
        {
            Debug.LogError("Sound: "+ clipname +" is missing");
            return;
        }
        sound.Source.Play();
    }

    public void Stop(string clipname)
    {
        Sound sound = Array.Find(Sounds, dummySound => dummySound.ClipName == clipname);
        if (sound == null)
        {
            Debug.LogError("Sound: " + clipname + " is missing");
            return;
        }
        sound.Source.Stop();
    }


    public void OnMusicSliderValueChange(float value)
    {
        MusicVolume = value;
        MusicMixerGroup.audioMixer.SetFloat("MusicVolume", (float)(Math.Log10((double)MusicVolume) * 20));
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        SoundEffectsVolume = value;
        SoundEffectsMixerGroup.audioMixer.SetFloat("SoundEffectsVolume", (float)(Math.Log10((double)SoundEffectsVolume) * 20));
    }
}
