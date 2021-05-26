using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform ProjectileSpawna;

    [SerializeField]
    private GameObject MusicProjectile;

    private Vector2 lookDirection;
    private float lookAngle;

    private bool cooldownOn = false;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        cooldownOn = false;

    }



    // Update is called once per frame
    void Update()
    {
        // rotate projectileSpawn object to look at mouse on every frame
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);


        // fire projectile on LMB and implement a cooldown to remove spamming
        if (Input.GetMouseButtonDown(0) && cooldownOn == false)
        {
            StartCoroutine(cdTime());


            IEnumerator cdTime()
            {
                FireMusicProjectile();
                yield return new WaitForSecondsRealtime(.75f);
                cooldownOn = false;
            }

        }
        else
        {
            //
        }
    }

    private void FireMusicProjectile()
    {
        cooldownOn = true;
        GameObject firedProjectile = Instantiate(MusicProjectile, ProjectileSpawna.position, ProjectileSpawna.rotation);
        firedProjectile.GetComponent<Rigidbody2D>().velocity = ProjectileSpawna.up * 7f;
        audioSource.PlayOneShot(audioSource.clip);


    }

}
