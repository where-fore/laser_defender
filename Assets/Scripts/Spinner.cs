using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float spinValue = 1f;
    void Update()
    {
       transform.Rotate(new Vector3(0,0, spinValue * Time.deltaTime));
    }
}
