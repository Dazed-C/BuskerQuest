using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkill : MonoBehaviour
{

    [SerializeField]
    private Transform UltimateSpawna;

    [SerializeField]
    private GameObject UltimateProjectile;

    private float life = 4.0f, curLife;
    public bool callOptimizer;

    private bool coolDownOn = false;

    public int hitCounter = 0;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //Error found: The Ultimate Script isn't a object just like ProjectileScript

        coolDownOn = false;
        curLife = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && coolDownOn == false)
        {
            callOptimizer = true;
            StartCoroutine(cdTime());

            IEnumerator cdTime()
            {
                FireUltimate();
                yield return new WaitForSecondsRealtime(20);
                coolDownOn = false;
            }

        }
        else
        {
            //

        }
    }
    void FireUltimate()
    {

        coolDownOn = true;
        GameObject firedProjectile = Instantiate(UltimateProjectile, UltimateSpawna.position, UltimateSpawna.rotation);
        //firedProjectile.GetComponent<Rigidbody2D>().velocity = ProjectileSpawna.up * 10f;
        //audioSource.PlayOneShot(audioSource.clip);
        audio.Play();


    }    
}
