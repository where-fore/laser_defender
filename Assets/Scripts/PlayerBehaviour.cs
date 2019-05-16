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

    float xMin = 0f;
    float xMax = 0f;
    float yMin = 0f;
    float yMax = 0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateMoveBoundaries();
    }

    private void CreateMoveBoundaries()
    {
        Camera mainGameCamera = Camera.main;
        xMin = mainGameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = mainGameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = mainGameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = mainGameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }   

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * shipXspeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * shipYspeed;

        var newXPos = Mathf.Clamp((transform.position.x + deltaX), xMin, xMax);
        var newYPos = Mathf.Clamp((transform.position.y + deltaY), yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
}
