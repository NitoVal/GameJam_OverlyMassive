using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Audio;

    private void Awake()
    {
        if (Audio == null)
            Audio = this;
        else
            Destroy(gameObject);
    }

    //[SerializeField] AudioClip[] soundEffects;
    [SerializeField] Sound[] sounds;

    private List<AudioSource> audioSources = new List<AudioSource>();
    
    public void PlaySound(string soundName)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.nomClip == soundName)
            {
                PlaySounds(sound.audioClip);
            }
        }
    }

    public void PlaySounds(AudioClip soundClip)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
                return;
            }
        }
        AudioSource source = CreateNewAudioSource();
        source.clip = soundClip;
        source.Play();
    }

    private AudioSource CreateNewAudioSource()
    {
        GameObject GO = new GameObject();
        GO.name = "AudioSource";
        GO.transform.parent = transform;
        
        AudioSource source = GO.AddComponent<AudioSource>();
        audioSources.Add(source);

        return source;
    }
}

[System.Serializable]
public struct Sound
{
    public AudioClip audioClip;
    public string nomClip;
}
