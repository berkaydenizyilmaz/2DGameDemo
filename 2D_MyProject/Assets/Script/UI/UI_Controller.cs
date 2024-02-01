using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] float scaleFactor;

    Vector3[] originalScales;
    [SerializeField] Button[] buttonsToScale;

    [SerializeField] Button[] buttonsAudio;
    [SerializeField] Sprite[] normalImage;
    [SerializeField] Sprite[] toggleImage;

    VoiceController voiceController;

    bool isSoundOn = true;
    bool isMusicOn = true;

    void Start()
    {
        originalScales = new Vector3[buttonsToScale.Length];

        for (int i = 0; i < buttonsToScale.Length; i++)
        {
            originalScales[i] = buttonsToScale[i].transform.localScale;
        }

        voiceController = VoiceController.GetInstance();
    }


    // Delay koyarak yeni sahneye geçme fonksiyonunu çaðýrýr
    public void StartGame()
    {
        Invoke("LoadScene", 0.6f);
    }

    // Sahne geçiþini saðlar    
    private void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Oyundan çýk
    public void QuitGame()
    {
        Debug.Log("The game is being exited.");
        Application.Quit();
    }

    // Butonu küçültür
    public void OnButtonPointerDown(int buttonIndex)
    {
        buttonsToScale[buttonIndex].transform.localScale = originalScales[buttonIndex] * scaleFactor;
    }

    // Butonu orijinal boyutuna döndürür
    public void OnButtonPointerUp(int buttonIndex)
    {
        buttonsToScale[buttonIndex].transform.localScale = originalScales[buttonIndex];
    }

    // SFX butonunun ayarlarý
    public void SetSFXButton()
    {
        isSoundOn = !isSoundOn;
        buttonsAudio[0].image.sprite = isSoundOn ? normalImage[0] : toggleImage[0];

        // Ses açýk
        if (isSoundOn)
        {
            voiceController.EnableSound();
        }
        // Ses kapalý
        else
        {
            voiceController.DisableSound();
        }
    }

    // Müzik butonunun ayarlarý
    public void SetMusicButtons()
    {
        isMusicOn = !isMusicOn;
        buttonsAudio[1].image.sprite = isMusicOn ? normalImage[1] : toggleImage[1];

        // Müzik açýk
        if (isMusicOn)
        {
            voiceController.EnableMusic();
        }
        // Müzik kapalý
        else
        {
            voiceController.DisableMusic();
        }
    }
}