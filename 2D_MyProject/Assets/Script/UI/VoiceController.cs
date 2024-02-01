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

    // Yeni sahne yüklendiðinde 
    private void PlayBackgroundMusicOfTheScene(Scene scene, LoadSceneMode mode)
    {
        // Önceki sahnenin müziðini durdur
        StopCurrentBackgroundMusic();

        // Yeni sahnenin müziðini çal
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

    // Þu anda çalýnan arka plan müziðini durdur
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

    // SFX sesini açar
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

    // SFX sesini kapatýr
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

    // Müzik sesini açar
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

    // Müzik sesini kapatýr
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