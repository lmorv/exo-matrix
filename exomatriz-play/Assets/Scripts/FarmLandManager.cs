using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(Rigidbody))]
public class FarmLandManager : MonoBehaviour
{
   [SerializeField] private InputAction mouseClickAction;
   
   private Camera mainCamera;
   
   private List<FarmLand> farmlands = new List<FarmLand>(); //  declaration of an empty list expecting objects of type FarmLand 
   
   private int groundLayer;
   
   private void Awake() {
      mainCamera = Camera.main;
      groundLayer = LayerMask.NameToLayer("ground");
   }

   private void Start()
   { // fetch farmlands and add them to the list of farmlands
      
      Transform currentTransform = this.transform;
      foreach (Transform child in currentTransform)
      {
         FarmLand FarmLandComponent = child.GetComponent<FarmLand>();
         if (FarmLandComponent != null)
         {
            farmlands.Add(FarmLandComponent);
         }
      }
   }
   
   private void OnEnable() {
      mouseClickAction.Enable();
      mouseClickAction.performed += OnClicked;
      
   }

   private void OnDisable() {
      mouseClickAction.performed -= OnClicked;
      mouseClickAction.Disable();
   }
   
   private void OnClicked(InputAction.CallbackContext context)
   {
      Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
      if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider && hit.collider.gameObject.layer.CompareTo(groundLayer) == 0) {
         FarmLand farmland = GetHitFarmland(new Vector2(hit.point.x, hit.point.y));
         if (farmland)
         {
            Debug.Log(farmland);
            farmland.SubDivideParcelAtPosition(new Vector2(hit.point.x, hit.point.y));
;         }
      }
   }

   private FarmLand GetHitFarmland(Vector2 position)
   {
      foreach (FarmLand farmland in farmlands){
         if (farmland.IsWithinBounds(position))
         {
            return farmland;
         }
      }

      return null;
   }
   


}
