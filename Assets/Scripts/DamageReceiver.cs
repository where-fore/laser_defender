using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]
    private float health = 1f;

    private string myTag = "";

    private string playerTag = "Player";
    private string enemyTag = "Enemy";
    void Start()
    {
        myTag = gameObject.tag;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) {return;}

        if (myTag == playerTag)
        {
            if (damageDealer.GetDestroyPlayerBool())
            {
                HandlePlayerHit(damageDealer);
                
                damageDealer.Impact();
            }
        }

        else if (myTag == enemyTag)
        {
            if (damageDealer.GetDestroyEnemiesBool())
            {
                HandleEnemyHit(damageDealer);

                damageDealer.Impact();
            }
        }
    }


    private void HandlePlayerHit(DamageDealer damageDealer)
    {
        DealPlayerDamage(damageDealer.GetDamageValue());
    }
    
    private void HandleEnemyHit(DamageDealer damageDealer)
    {
        DealEnemyDamage(damageDealer.GetDamageValue());
    }


    private void DealPlayerDamage(float damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            GetComponent<PlayerBehaviour>().Kill();
        }

    }

    private void DealEnemyDamage(float damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            GetComponent<EnemyBehaviour>().Kill();
        }
    }


}
