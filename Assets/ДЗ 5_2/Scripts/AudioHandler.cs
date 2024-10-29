using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _musicGroup;
    [SerializeField] private AudioMixerGroup _soundsGroup;
    [SerializeField] private AudioSource _soundsSource;
    [SerializeField] private List<AudioClip> _sounds;

    public const float SoundOff = -80f;
    public const float SoundOn = 0f;

    private const string MusicKey = "MusicVolume";
    private const string SoundsKey = "SoundsVolume";

    private const int OnVolumeSaveKey = 1;
    private const int OffVolumeSaveKey = -1;

    public void Initialize()
    {
        int soundsSaveKey = PlayerPrefs.GetInt(SoundsKey);

        if (soundsSaveKey == 0 || soundsSaveKey == 1)
            OnSound();
        else
            OffSound();
    }

    public void OffSound()
    {
        _musicGroup.audioMixer.SetFloat(MusicKey, SoundOff);
        _soundsGroup.audioMixer.SetFloat(SoundsKey, SoundOff);

        PlayerPrefs.SetInt(SoundsKey, OffVolumeSaveKey);
    }
    
    public void OnSound()
    {
        _musicGroup.audioMixer.SetFloat(MusicKey, SoundOn);
        _soundsGroup.audioMixer.SetFloat(SoundsKey, SoundOn);

        PlayerPrefs.SetInt(SoundsKey, OnVolumeSaveKey);
    }
    
    public void PlaySound(int index)
    {
        _soundsSource.PlayOneShot(_sounds[index]);
    }
}
