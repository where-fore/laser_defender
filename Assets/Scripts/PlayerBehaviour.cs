using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    [SerializeField]
    float shipXspeed = 10f;
    [SerializeField]
    float shipYspeed = 10f;

    [SerializeField]
    GameObject laserPrefab = null;
    [SerializeField]
    private float laserSpeed = 15f;

    float xMin = 0f;
    float xMinPadding = 2f;
    float xMax = 0f;
    float xMaxPadding = 2f;
    float yMin = 0f;
    float yMinPadding = 1f;
    float yMax = 0f;
    float yMaxPadding = 1f;

    void Start()
    {
        CreateMoveBoundaries();
    }

    void Update()
    {
        MovePlayer();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        Vector3 spawnOffset = new Vector3(0,0,0);
        Vector2 spawnPosition = transform.position + spawnOffset;

        GameObject laser = Instantiate(laserPrefab, spawnPosition, Quaternion.identity);

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
    }

    private void MovePlayer()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * shipXspeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * shipYspeed;

        var newXPos = Mathf.Clamp((transform.position.x + deltaX), xMin, xMax);
        var newYPos = Mathf.Clamp((transform.position.y + deltaY), yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
    
    private void CreateMoveBoundaries()
    {
        Camera mainGameCamera = Camera.main;
        xMin = mainGameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMin = xMin + xMinPadding;

        xMax = mainGameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        xMax = xMax - xMaxPadding;

        yMin = mainGameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMin = yMin + yMinPadding;

        yMax = mainGameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        yMax = yMax - yMaxPadding;

    }   
}
