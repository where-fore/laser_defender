using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField]
    private GameObject weapon = null;
    [SerializeField]
    Vector3 weaponProjetileOffset = new Vector3(0, 0, 0);
    [SerializeField]
    private float weaponProjectileSpeed = 15f;

    [Header("VFX")]
    [SerializeField]
    private GameObject deathVFX = null;
    private float deathVFXDuration = 1f;

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
    }
    
    public void Kill()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, deathVFXDuration);
        Destroy(gameObject);
    }
}
