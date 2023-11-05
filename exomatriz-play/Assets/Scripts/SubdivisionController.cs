using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SubdivisionController : MonoBehaviour, IPointerClickHandler
{
    public GameObject subdivisionPrefab; // The prefab for the subdivided cells
    private bool isSubdivided = false;   // Keeps track of whether the rectangle is subdivided
    public RectTransform ParentRectangle;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isSubdivided)
        {
            // Subdivide the rectangle
            Subdivide();
            isSubdivided = true;
        }
        else
        {
            // If already subdivided, further subdividing the cells
            SubdivideCells();
        }
    }

    void Subdivide()
    {
        // Create two child rectangles
        GameObject subdivision1 = Instantiate(subdivisionPrefab, transform);
        GameObject subdivision2 = Instantiate(subdivisionPrefab, transform);

        // Position the subdivisions as desired (adjust these positions as needed)
        subdivision1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-50, 0);
        subdivision2.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, 0);

        // Update the size of the current rectangle
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, rectTransform.sizeDelta.y);
    }

    void SubdivideCells()
    {
        // Instantiate the subdivision cell prefab.
        GameObject newCell = Instantiate(subdivisionPrefab, ParentRectangle);
        
        // Get the RectTransform of the new cell.
        RectTransform cellRect = newCell.GetComponent<RectTransform>();

        // Set the horizontal size of the new cell to half of the parent rectangle's size.
        float parentWidth = ParentRectangle.rect.width;
        cellRect.sizeDelta = new Vector2(parentWidth * 0.5f, cellRect.sizeDelta.y);

        // Position the new cell inside the parent rectangle.
        cellRect.anchoredPosition = new Vector2(0.0f, 0.0f); // Centered position, adjust as needed.
    }
}