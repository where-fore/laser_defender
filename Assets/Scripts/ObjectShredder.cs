using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShredder : MonoBehaviour
{
    private string laserTag = "Laser";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == laserTag)
        {
            Destroy(collision.gameObject);
        }
    }
}
