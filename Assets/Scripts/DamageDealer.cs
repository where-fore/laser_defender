using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private int damage = 100;

    [SerializeField]
    private bool destroyPlayer = false;

    [SerializeField]
    private bool destroyEnemies = false;

    public int GetDamageValue() {return damage;}

    public bool GetDestroyPlayerBool() {return destroyPlayer;}

    public bool GetDestroyEnemiesBool() {return destroyEnemies;}

    public void Impact()
    {
        Destroy(gameObject);
    }

}
