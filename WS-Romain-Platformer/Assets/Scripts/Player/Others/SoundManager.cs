using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [Tooltip("The audio source used to play SFXs.")] public AudioSource _audioSource;
    [Tooltip("The audio source used to play ambiant sounds.")] public AudioSource _soundSource;
    [Tooltip("The audio source used to play music.")] public AudioSource _musicSource;

    private static SoundManager _instance;

    public static SoundManager Instance
    {  
        get 
        {
            /*if (_instance == null)
            {
                GameObject gameObject = new GameObject("SoundManager");
                _instance = gameObject.AddComponent<SoundManager>();
            }

            return _instance;*/

            if (_instance == null)
                Debug.Log("SoundManager is null");
            return _instance;

        } 
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("Instance destroyed");
        }
        else
        {
            _instance = this;
            Debug.Log("Instance created");
        }
    }

    private void Start()
    {
        _soundSource.loop = true;
    }

    public void PlaySound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    public void PlayMusic(AudioClip music)
    {
        _musicSource.clip = music;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}
