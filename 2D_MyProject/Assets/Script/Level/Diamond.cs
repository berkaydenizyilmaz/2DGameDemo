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

    // Elmas toplandýðýnda toplanan elmas sayýsýný arttýran fonksiyonu çaðýr elmasý deaktif yap
    public void Collect()
    {
        isCollected = true;
        gameObject.SetActive(false);

        levelTransition.DiamondCollected();

        voiceController.PlaySoundEffect(SFX);
    }

    // Elmas toplandý mý deðiþkenini döndür
    public bool IsCollected()
    {
        return isCollected;
    }
}