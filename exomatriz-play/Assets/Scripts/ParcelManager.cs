// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.InputSystem;
//
// // [RequireComponent(typeof(Rigidbody))]
// public class ParcelManager : MonoBehaviour
// {
//    [SerializeField] private InputAction mouseClickAction;
//    [SerializeField] private ParcelController parcelPrefab;
//    [SerializeField] private Transform parcelParent;
//    [SerializeField] private Vector2 heightWidth;
//    
//    private Camera mainCamera;
//    
//    private List<ParcelController> parcels = new List<ParcelController>();
//    
//    private int groundLayer;
//    
//    private void Awake() {
//       mainCamera = Camera.main;
//       groundLayer = LayerMask.NameToLayer("ground");
//    }
//    
//    // OnEnable instantiates the first parcel
//    private void OnEnable() {
//       mouseClickAction.Enable();
//       mouseClickAction.performed += OnClicked;
//
//       ParcelController parcel = Instantiate(parcelPrefab, parcelParent);  // the initial parcel to subdivide
//       parcel.SetPosition(new Vector3(0, 0 ,0));
//       parcel.SetHeightWidth(heightWidth);
//       parcels.Add(parcel);
//    }
//
//    private void OnDisable() {
//       mouseClickAction.performed -= OnClicked;
//       mouseClickAction.Disable();
//    }
//    
//    private void OnClicked(InputAction.CallbackContext context) {
//       Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
//       //if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider && hit.collider.GetComponent<CanvasRenderer>() != null){
//       if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider && hit.collider.gameObject.layer.CompareTo(groundLayer) == 0) {
//          ParcelController parcel = GetHitParcel(new Vector2(hit.point.x, hit.point.y));
//          if (parcel)
//          {
//             SubDivideParcel(parcel); 
//          }
//       }
//    }
//
//    private ParcelController GetHitParcel(Vector2 position)
//    {
//       foreach (ParcelController parcel in parcels){
//          if (parcel.IsWithinBounds(position, ))
//          {
//             return parcel;
//          }
//       }
//
//       return null;
//    }
//
//    private void SubDivideParcel(ParcelController parcel)
//    {
//       SubdivisionData data = parcel.GetSubdivisionData();
//       
//       parcel.SetPosition(data.parcelAPosition);
//       parcel.SetHeightWidth(data.parcelsWidthHeight);
//       
//       ParcelController prettyNewParcel = Instantiate(parcelPrefab, parcelParent);
//       prettyNewParcel.SetPosition(data.parcelBPosition);
//       prettyNewParcel.SetHeightWidth(data.parcelsWidthHeight);
//       parcels.Add(prettyNewParcel);
//    }
// }
