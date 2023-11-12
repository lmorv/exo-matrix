using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Image))]
public class ParcelController : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    public void Start()
    {
        
        // Generate random values for the red, green, and blue components of the color
        float randomRed = UnityEngine.Random.value;
        float randomGreen = UnityEngine.Random.value;
        float randomBlue = UnityEngine.Random.value;
    
        // Create a new color using the random values
        Color randomColor = new Color(randomRed, randomGreen, randomBlue);
    
        // Set the Image component color to the random color
        Image image = GetComponent<Image>();
        image.color = randomColor;
    }

    public bool IsWithinBounds(Vector2 point)
    {
        if (_rectTransform == null)
        {
            Debug.LogError("BoundsChecker requires a RectTransform component.");
            return false;
        }

        // Get the current position of the transform
        Vector2 currentPosition = new Vector2(_rectTransform.position.x, _rectTransform.position.y);

        // Calculate the bounds based on the RectTransform's size
        float minX = currentPosition.x - _rectTransform.rect.width / 2;
        float maxX = currentPosition.x + _rectTransform.rect.width / 2;
        float minY = currentPosition.y - _rectTransform.rect.height / 2;
        float maxY = currentPosition.y + _rectTransform.rect.height / 2;

        // Check if the given point is within the bounds
        return point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY;
    }

    public void SetPosition(Vector3 position)
    {
        _rectTransform.anchoredPosition = position;
    }
    
    public void SetHeightWidth(Vector2 dimensions)
    {
        _rectTransform.sizeDelta = dimensions;
    }

    public SubdivisionData GetSubdivisionData()
    {
        SubdivisionData data = new SubdivisionData();
        
        if (_rectTransform.rect.width >= _rectTransform.rect.height)
        {
            data.parcelsWidthHeight = new Vector2( _rectTransform.rect.width / 2, _rectTransform.rect.height);

            float offset = _rectTransform.rect.width / 4;
            
            data.parcelAPosition = new Vector3(_rectTransform.position.x - offset, _rectTransform.position.y, 0);
            data.parcelBPosition = new Vector3(_rectTransform.position.x + offset, _rectTransform.position.y, 0);

            return data;
        }
        else
        {
            data.parcelsWidthHeight = new Vector2(_rectTransform.rect.width, _rectTransform.rect.height / 2);

            float offset = _rectTransform.rect.height / 4;
            
            data.parcelAPosition = new Vector3(_rectTransform.position.x, _rectTransform.position.y - offset, 0);
            data.parcelBPosition = new Vector3(_rectTransform.position.x, _rectTransform.position.y + offset, 0);
            
            return data;
        }
    }
}

public struct SubdivisionData
{
    public Vector2 parcelsWidthHeight;
    
    public Vector3 parcelAPosition;
    public Vector3 parcelBPosition;
}