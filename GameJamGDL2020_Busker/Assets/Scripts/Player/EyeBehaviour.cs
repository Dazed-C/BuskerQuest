using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBehaviour : MonoBehaviour
{
    private Vector2 lookDirection;
    private float lookAngle;
    

    // Update is called once per frame
    void Update()
    {
        // rotate eye object to look at mouse on every frame
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + 45f);
    }
}
