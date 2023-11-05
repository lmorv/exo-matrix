using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TDPlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float movementVelocity = 3f;
    [SerializeField] private Transform bulletDirection;
    
    private TDActions controls;
    private bool canShoot = true;
    private Camera main;

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
        main = Camera.main;
       controls.Player.Shoot.performed += _ => PlayerShoot(); // Underscore instead of ctx (context value) cause we are not reading a context value in this case.
    }

    private void PlayerShoot()
    {
        if (canShoot) return;
        
        Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        g.SetActive(true);
        StartCoroutine(CanShoot());

    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(.5f);
        canShoot = true;
    }
    void Update()
    {
        //Rotation
        Vector2 mouseScreenPosition = controls.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        
        //Movement
        Vector3 movement = controls.Player.Movement.ReadValue<Vector2>() * movementVelocity;
        transform.position += movement * Time.deltaTime;
    }
}
