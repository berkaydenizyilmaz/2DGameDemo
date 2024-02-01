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

    // Elmaslar� kontrol et ve kap�y� a�
    void CheckDiamonds()
    {
        if (collectedDiamondCount >= totalDiamondCount)
        {
            OpenDoor();
        }
    }

    // Kap�y� a�
    void OpenDoor()
    {
        if (!isDoorOpen)
        {
            GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
            isDoorOpen = true;

            Debug.Log("The door has been opened.");
        }
    }

    // Elmas topland���nda �a�r�l�r
    public void DiamondCollected()
    {
        collectedDiamondCount++;
    }

    // Karakter objeye �arparsa index'teki level'e ge�
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