using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using System;
using System.Xml.Schema;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static private float _moveSpeed = 5f;
    public float MoveSpeed = _moveSpeed;

    public static int life = 3;
    public static int maxLife = 5;
    public Text countText;

    


    [SerializeField] float xPadding = 1f;
    [SerializeField] float yPadding = 1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coffee")
        {
            life++;
            if (life >= maxLife)
            {
                life = maxLife;
            }
            Destroy(col.gameObject);

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // On initialisation, set player position to 0, 0, 0 (starting position)
        transform.position = Vector3.zero;
        SetUpMoveBoundaries();
        countText.text = "LIVES: " + life.ToString();

    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding + 0.5f;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding - 1.5f;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }

    

    // Update is called once per frame
    void Update()
    {
        countText.text = "LIVES: " + life.ToString();

        //Debug.Log(life);
        Move();

        
    }

    private void Move()
    {
        // on WASD press/hold move player in respective direction(s)
        // Bind player to screen limits
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);

        
    }


    

}
