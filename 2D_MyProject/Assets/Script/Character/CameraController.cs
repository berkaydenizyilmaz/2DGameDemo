using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform characterTransform;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private void Start()
    {
        // Kameranýn baþlangýç pozisyonuna ayarlar
        Vector3 startingPosition = new Vector3(minX, minY, transform.position.z);
        transform.position = startingPosition;
    }

    void Update()
    {
        // Kameranýn karakteri takip etmesini saðlar
        Vector3 newPosition = new Vector3(characterTransform.position.x, characterTransform.position.y, transform.position.z);
        transform.position = newPosition;

        // Kameranýn level dýþýna çýkmasýný engeller
        if (transform.position.x <= minX)
        {
            Vector3 clampedPosition = new Vector3(minX, transform.position.y, transform.position.z);
            transform.position = clampedPosition;
        }
        else if (transform.position.x >= maxX)
        {
            Vector3 clampedPosition = new Vector3(maxX, transform.position.y, transform.position.z);
            transform.position = clampedPosition;
        }

        if (transform.position.y <= minY)
        {
            Vector3 clampedPosition = new Vector3(transform.position.x, minY, transform.position.z);
            transform.position = clampedPosition;
        }
        else if (transform.position.y >= maxY)
        {
            Vector3 clampedPosition = new Vector3(transform.position.x, maxY, transform.position.z);
            transform.position = clampedPosition;
        }
    }
}