using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] AudioClip SFX;

    VoiceController voiceController;
    LevelTransition levelTransition;

    bool isCollected = false;

    private void Start()
    {
        levelTransition = FindObjectOfType<LevelTransition>();
        voiceController = VoiceController.GetInstance();
    }

    // Elmas topland���nda toplanan elmas say�s�n� artt�ran fonksiyonu �a��r elmas� deaktif yap
    public void Collect()
    {
        isCollected = true;
        gameObject.SetActive(false);

        levelTransition.DiamondCollected();

        voiceController.PlaySoundEffect(SFX);
    }

    // Elmas topland� m� de�i�kenini d�nd�r
    public bool IsCollected()
    {
        return isCollected;
    }
}