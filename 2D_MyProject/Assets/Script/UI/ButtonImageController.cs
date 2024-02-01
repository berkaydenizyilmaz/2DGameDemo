using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image associatedImage;

    // Fare butonun üzerine gelince
    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateImagesVisibility(true);
    }

    // Fare butondan çýkýnca
    public void OnPointerExit(PointerEventData eventData)
    {
        UpdateImagesVisibility(false);
    }

    // Belirtilen resmin görünürlüðünü ayarlar
    private void UpdateImagesVisibility(bool isVisible)
    {
        associatedImage.gameObject.SetActive(isVisible);
    }
}
