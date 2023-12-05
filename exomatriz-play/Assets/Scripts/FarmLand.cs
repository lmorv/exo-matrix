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
      // Vector2 currentPosition = new Vector2(_rectTransform.position.x, _rectTransform.position.y);
      
      Vector2 localFarmlandPosition = this.transform.InverseTransformPoint(new Vector3(_rectTransform.position.x, _rectTransform.position.y,0));

      // Calculate the bounds based on the RectTransform's size
      float minX = localFarmlandPosition.x - _rectTransform.rect.width / 2;
      float maxX = localFarmlandPosition.x + _rectTransform.rect.width / 2;
      float minY = localFarmlandPosition.y - _rectTransform.rect.height / 2;
      float maxY = localFarmlandPosition.y + _rectTransform.rect.height / 2;

      // Check if the given point is within the bounds
     Vector2 localPoint = this.transform.InverseTransformPoint(point);
     
     return localPoint.x >= minX && localPoint.x <= maxX && localPoint.y >= minY && localPoint.y <= maxY;
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
         if (parcel.IsWithinBounds(position, this.transform))
         {
            return parcel;
         }
      }

      return null;
   }

   public void SubDivideParcelAtPosition(Vector2 position)
   {
      Debug.Log(position);
      Vector3 localPoint = this.transform.InverseTransformPoint(new Vector3(position.x, position.y,0));
      Debug.Log(localPoint);
      
      ParcelController parcel = GetParcelFromLocalPos(new Vector2(localPoint.x, localPoint.y));
      Debug.Log(parcel);
      
      if (parcel == null) return;
      
      SubdivisionData data = parcel.GetSubdivisionData(this.transform);
      
      parcel.SetPosition(data.parcelAPosition);
      parcel.SetHeightWidth(data.parcelsWidthHeight);
      
      ParcelController prettyNewParcel = Instantiate(parcelPrefab, this.transform);
      prettyNewParcel.SetPosition(data.parcelBPosition);
      prettyNewParcel.SetHeightWidth(data.parcelsWidthHeight);
      parcels.Add(prettyNewParcel);
   }
   
   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green; // Set the gizmo color
      
      // Store the current Gizmos matrix
      Matrix4x4 oldMatrix = Gizmos.matrix;
      
      // Set the Gizmos matrix to the GameObject's position and rotation
      Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
      
      // Draw a rectangle gizmo using the x and y components of the Vector2 heightWidth property
      Gizmos.DrawWireCube(Vector3.zero, new Vector3(heightWidth.x, heightWidth.y, 0));
      
      // Restore the previous Gizmos matrix
      Gizmos.matrix = oldMatrix;
   }
}
