using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceController : MonoBehaviour
{
    static VoiceController instance;

    [SerializeField] AudioSource[] backgroundMusicSource;
    [SerializeField] AudioSource[] soundEffectSource;

    private void Awake()
    {
        if (ReferenceEquals(instance, null))
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static VoiceController GetInstance()
    {
        return instance;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += PlayBackgroundMusicOfTheScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= PlayBackgroundMusicOfTheScene;
    }

    // Yeni sahne y�klendi�inde 
    private void PlayBackgroundMusicOfTheScene(Scene scene, LoadSceneMode mode)
    {
        // �nceki sahnenin m�zi�ini durdur
        StopCurrentBackgroundMusic();

        // Yeni sahnenin m�zi�ini �al
        int sceneBuildIndex = scene.buildIndex;
        if (sceneBuildIndex < backgroundMusicSource.Length)
        {
            backgroundMusicSource[sceneBuildIndex].Play();
        }
        else
        {
            Debug.LogError("No background music source assigned for scene index " + sceneBuildIndex);
        }
    }

    // �u anda �al�nan arka plan m�zi�ini durdur
    private void StopCurrentBackgroundMusic()
    {
        foreach (var source in backgroundMusicSource)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    // Gelen SFX'i oynat
    public void PlaySoundEffect(AudioClip soundEffectClip)
    {
        foreach (var source in soundEffectSource)
        {
            if (source != null)
            {
                if (soundEffectClip != null)
                {
                    source.PlayOneShot(soundEffectClip);
                }
                else
                {
                    Debug.LogError("Failed to load sound effect clip.");
                }
            }
            else
            {
                Debug.LogError("Sound effect source is null.");
            }
        }
    }

    // SFX sesini a�ar
    public void EnableSound()
    {
        foreach (AudioSource soundAudio in soundEffectSource)
        {
            if (soundAudio != null)
            {
                soundAudio.volume = 1.0f;
            }
            else
            {
                Debug.LogError("Sound effect source is null.");
            }
        }
    }

    // SFX sesini kapat�r
    public void DisableSound()
    {
        foreach (AudioSource soundAudio in soundEffectSource)
        {
            if (soundAudio != null)
            {
                soundAudio.volume = 0.0f;
            }
            else
            {
                Debug.LogError("Sound effect source is null.");
            }
        }
    }

    // M�zik sesini a�ar
    public void EnableMusic()
    {
        foreach (var source in backgroundMusicSource)
        {
            if (source != null)
            {
                source.volume = 1.0f;
            }
            else
            {
                Debug.LogError("Background music source is null.");
            }
        }
    }

    // M�zik sesini kapat�r
    public void DisableMusic()
    {
        foreach (var source in backgroundMusicSource)
        {
            if (source != null)
            {
                source.volume = 0.0f;
            }
            else
            {
                Debug.LogError("Background music source is null.");
            }
        }
    }
}