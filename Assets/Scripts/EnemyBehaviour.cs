using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Weapon")]

    [SerializeField] private GameObject weapon = null;
    [SerializeField] Vector3 weaponProjetileOffset = new Vector3(0, 0, 0);
    [SerializeField] private float weaponProjectileSpeed = 15f;


    [Header("VFX")]

    [SerializeField] private GameObject deathVFX = null;
    [SerializeField] private float deathVFXDuration = 1f;


    [Header("SFX")]

    [SerializeField] private AudioClip deathSFX = null;
    [SerializeField] [Range(0,1)] private float deathSFXVolume = 1f;
    [SerializeField] private AudioClip[] fireSFX = null;
    [SerializeField] [Range(0,1)]  private float fireSFXVolume = 1f;


    private float shotCounter = 0f;
    private float minTimeBetweenShots = 0.2f;

    private float maxTimeBetweenShots = 3f;

    void Start()
    {
        SetShotCounter();
    }

    void Update()
    {
        CountDownAndShoot();
    }
    
    private void SetShotCounter()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire(weapon);
            SetShotCounter();
        }
    }

    private void Fire(GameObject weapon)
    {
        Vector2 spawnPosition = transform.position + weaponProjetileOffset;

        GameObject laser = Instantiate(weapon, spawnPosition, Quaternion.identity);

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -weaponProjectileSpeed);

        FireSFX();
    }

    
    public void Kill()
    {
        DeathVFX();

        DeathSFX();

        Destroy(gameObject);
    }
    
    private void FireSFX()
    {
        AudioClip clipToPlay = fireSFX[Random.Range(0, fireSFX.Length)];

        AudioSource.PlayClipAtPoint(clipToPlay, Camera.main.transform.position, fireSFXVolume);
    }

    private void DeathSFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }

    private void DeathVFX()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, deathVFXDuration);
    }
}
