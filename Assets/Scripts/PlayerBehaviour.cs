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

    [Header("Weapon")]
    [SerializeField]
    GameObject laserPrefab = null;
    [SerializeField]
    Vector3 weaponProjetileOffset = new Vector3(0, 0, 0);
    [SerializeField]
    private float laserSpeed = 15f;
    [SerializeField]
    private float delayBetweenShots = 0.05f;
    Coroutine firingCoroutine = null;
    private bool firing = false;

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
        if (Input.GetButtonDown("Fire1") && !firing)
        {
            firing = true;
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            firing = false;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            Fire(laserPrefab);
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }

    private void Fire(GameObject weapon)
    {
        Vector2 spawnPosition = transform.position + weaponProjetileOffset;

        GameObject laser = Instantiate(weapon, spawnPosition, Quaternion.identity);

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
    }

    public void Kill()
    {
        Destroy(gameObject);
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
