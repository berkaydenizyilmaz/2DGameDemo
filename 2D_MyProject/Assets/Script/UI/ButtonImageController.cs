using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image associatedImage;

    // Fare butonun �zerine gelince
    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateImagesVisibility(true);
    }

    // Fare butondan ��k�nca
    public void OnPointerExit(PointerEventData eventData)
    {
        UpdateImagesVisibility(false);
    }

    // Belirtilen resmin g�r�n�rl���n� ayarlar
    private void UpdateImagesVisibility(bool isVisible)
    {
        associatedImage.gameObject.SetActive(isVisible);
    }
}
