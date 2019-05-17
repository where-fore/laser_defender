using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    private GameObject weapon = null;
    [SerializeField]
    private float weaponProjectileSpeed = 15f;

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
        Vector3 spawnOffset = new Vector3(0f, -0.8f, 0f);
        Vector2 spawnPosition = transform.position + spawnOffset;

        GameObject laser = Instantiate(weapon, spawnPosition, Quaternion.identity);

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -weaponProjectileSpeed);
    }
    
    public void Kill()
    {
        Destroy(gameObject);
    }
}
