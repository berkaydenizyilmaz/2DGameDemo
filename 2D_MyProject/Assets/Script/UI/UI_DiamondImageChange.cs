using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondImageChange : MonoBehaviour
{
    [SerializeField] Sprite fullSprite;
    [SerializeField] GameObject emptySpritePrefab;
    [SerializeField] Transform diamondParent;

    List<Image> diamondImages = new List<Image>();
    int totalDiamondCount;

    void Start()
    {
        totalDiamondCount = diamondParent.childCount;

        for (int i = 0; i < totalDiamondCount; i++)
        {
            GameObject emptyDiamond = Instantiate(emptySpritePrefab, transform);
            diamondImages.Add(emptyDiamond.GetComponent<Image>());
        }
    }

    void Update()
    {
        int collectedDiamondCount = FindObjectOfType<CharacterController>().GetDiamondCount();

        for (int i = 0; i < totalDiamondCount; i++)
        {
            if (i < collectedDiamondCount)
            {
                diamondImages[i].sprite = fullSprite;
            }
        }
    }
}
