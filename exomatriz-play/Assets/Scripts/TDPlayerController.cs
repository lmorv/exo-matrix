using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TDPlayerController : MonoBehaviour
{
    // [SerializeField] private GameObject bullet;
    [SerializeField] private float movementVelocity = 3f;
    // [SerializeField] private Transform bulletDirection;
    
    private TDActions controls;
    private Camera mainCam;
    

    private void Awake()
    {
        controls = new TDActions();
    }

    private void OnEnable() {
       controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    void Start()
    {
        mainCam = Camera.main;
       // controls.Player.Shoot.performed += _ => PlayerShoot(); // Underscore instead of ctx (context value) cause we are not reading a context value in this case.
    }

    // private void Interact()
    // {
    
    // }
    
    void Update()
    {
        //Rotation
        Vector2 mouseScreenPosition = controls.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = mainCam.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        
        //Movement
        Vector3 movement = controls.Player.Movement.ReadValue<Vector2>() * movementVelocity;
        transform.position += movement * Time.deltaTime;
        
        // camera follow
        mainCam = Camera.main;
        
    }
}
