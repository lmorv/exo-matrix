using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(Rigidbody))]
public class FarmLand : MonoBehaviour
{
   [SerializeField] private ParcelController parcelPrefab;
   [SerializeField] private Vector2 heightWidth;
   private RectTransform _rectTransform;
   
   private List<ParcelController> parcels = new List<ParcelController>();
   
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
   
   // OnEnable instantiates the first parcel at a position with defined dimensions.
   private void OnEnable()
   {
      _rectTransform = GetComponent<RectTransform>();
      
      _rectTransform.sizeDelta = heightWidth;
      
      ParcelController parcel = Instantiate(parcelPrefab, this.transform);  // the initial parcel to subdivide with the game object this script is attached to as the parent (a 'farmland').
      parcel.SetPosition(new Vector3(0, 0 ,0));
      parcel.SetHeightWidth(heightWidth);
      parcels.Add(parcel);
   }

   private ParcelController GetParcelFromLocalPos(Vector2 position)
   {
      foreach (ParcelController parcel in parcels){
         if (parcel.IsWithinBounds(position))
         {
            return parcel;
         }
      }

      return null;
   }

   public void SubDivideParcelAtPosition(Vector2 position)
   {
      Vector3 localPoint = this.transform.InverseTransformPoint(new Vector3(position.x, position.y,0)); 
      
      ParcelController parcel = GetParcelFromLocalPos(new Vector2(localPoint.x, localPoint.y));
      
      if (parcel == null) return;
      
      SubdivisionData data = parcel.GetSubdivisionData();
      
      parcel.SetPosition(data.parcelAPosition);
      parcel.SetHeightWidth(data.parcelsWidthHeight);
      
      ParcelController prettyNewParcel = Instantiate(parcelPrefab, this.transform);
      prettyNewParcel.SetPosition(data.parcelBPosition);
      prettyNewParcel.SetHeightWidth(data.parcelsWidthHeight);
      parcels.Add(prettyNewParcel);
   }
}
