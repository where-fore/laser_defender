using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField] float shipXspeed = 10f;
    [SerializeField] float shipYspeed = 10f;


    [Header("Weapon")]

    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] Vector3 weaponProjetileOffset = new Vector3(0, 0, 0);
    [SerializeField] private float laserSpeed = 15f;
    [SerializeField] private float delayBetweenShots = 0.05f;

    [Header("Audio")]
    [SerializeField] private AudioClip startFiringClip = null;
    
    [SerializeField] private float startFiringVolume = 0.2f;
    [SerializeField] private AudioClip stopFiringClip = null;
    [SerializeField] private float stopFiringVolume = 0.2f;
    
    [SerializeField] private AudioClip deathSFX = null;
    [SerializeField] private float deathSFXVolume = 1f;

    float xMin = 0f;
    float xMinPadding = 0.6f;
    float xMax = 0f;
    float xMaxPadding = 0.6f;
    float yMin = 0f;
    float yMinPadding = 1f;
    float yMax = 0f;
    float yMaxPadding = 1f;

    Coroutine firingCoroutine = null;
    private bool firing = false;

    private AudioSource myAudioSource = null;


    void Start()
    {
        CreateMoveBoundaries();
        myAudioSource = GetComponent<AudioSource>();
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
            PlayFiringSFX(true);

            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);

            PlayFiringSFX(false);
            firing = false;
        }
    }

    private void PlayFiringSFX(bool firing)
    {
        if (firing)
        {
            myAudioSource.PlayOneShot(startFiringClip, startFiringVolume);
        }
        
        if (!firing)
        {
            myAudioSource.PlayOneShot(stopFiringClip, stopFiringVolume);
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
        PlayDeathSFX();

        Destroy(gameObject);
    }

    private void PlayDeathSFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, transform.position, deathSFXVolume);
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
