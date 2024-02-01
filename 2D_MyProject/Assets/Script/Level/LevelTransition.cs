using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelTransition : MonoBehaviour
{
    [SerializeField] Sprite doorOpenSprite;
    [SerializeField] Transform diamondParent;
    [SerializeField] AudioClip SFX;

    VoiceController voiceController;

    bool isDoorOpen = false;
    int totalDiamondCount;
    int collectedDiamondCount = 0;

    private void Start()
    {
        voiceController = VoiceController.GetInstance();
        totalDiamondCount = diamondParent.childCount;
    }

    private void Update()
    {
        CheckDiamonds();
    }

    // Elmaslarý kontrol et ve kapýyý aç
    void CheckDiamonds()
    {
        if (collectedDiamondCount >= totalDiamondCount)
        {
            OpenDoor();
        }
    }

    // Kapýyý aç
    void OpenDoor()
    {
        if (!isDoorOpen)
        {
            GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
            isDoorOpen = true;

            Debug.Log("The door has been opened.");
        }
    }

    // Elmas toplandýðýnda çaðrýlýr
    public void DiamondCollected()
    {
        collectedDiamondCount++;
    }

    // Karakter objeye çarparsa index'teki level'e geç
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDoorOpen && collision.gameObject.CompareTag("Player"))
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            voiceController.PlaySoundEffect(SFX);

            if (buildIndex != 2)
            {
                SceneManager.LoadScene(buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}