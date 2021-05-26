using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    // only serialized for debug purposes
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    private float _speed = 1.0f;
    private float chanceDropTime;
    private float coffetime;
    public bool isHappy;


    public GameObject coffee;

    public static int scoreValue = 100;
    private int coffeeCount;


    // Start is called before the first frame update
    void Start()
    {
        isHappy = false;
        coffeeCount = 0;
    }



    // Update is called once per frame
    void Update()
    {



        //movement
        transform.position += Vector3.left * _speed * Time.deltaTime;
        //


        //happiness system
        if ((isHappy) && (PlayerController.life <= 4))
        {
            chanceDropTime += Time.deltaTime;
            if (chanceDropTime >= 4f)
            {

                float dropChance = UnityEngine.Random.Range(0, 100);
                chanceDropTime = 0;

                if ((dropChance < 2f) && (coffeeCount <= 3))
                {
                    Instantiate(coffee, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 0));
                    coffeeCount++;
                }
                //coffetime += Time.deltaTime;
                //if (coffetime >= 5f)
                //{

                //    coffetime = 0;
                //    Destroy(coffee);
                //}
            }

        }
        else
        {


            //Sad passenger goes here
        }
        //




        //
    }




    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("I have Collided with");

        if (col.gameObject.tag == "playerMelody")
        {
            Debug.Log(col);
            if (isHappy == false)
            {
                Debug.Log("Adding score");
                Destroy(col.gameObject);

                FindObjectOfType<GameSession>().AddToScore(scoreValue);
                isHappy = true;
                timesHit++;
                if (timesHit >= 1)
                {
                    Debug.Log("Showing next sprite!");
                    ShowNextHitSprite();
                }
                else
                {
                    Debug.Log("else 1");
                    //
                }

            }
            else
            {
                Debug.Log("else 2");
                //
            }


        }
        //collision with ultimate
        if (col.gameObject.tag == "ultimate")
        {
            GameObject.Find("UltimateSpawner").GetComponent<UltimateSkill>().hitCounter++;
            Debug.Log(col);
            if (isHappy == false)
            {
                Debug.Log("Adding score");
                if (GameObject.Find("UltimateSpawner").GetComponent<UltimateSkill>().hitCounter >= 5)
                {
                    GameObject.Find("UltimateSpawner").GetComponent<UltimateSkill>().hitCounter = 0;
                    Destroy(col.gameObject);
                }
                

                FindObjectOfType<GameSession>().AddToScore(scoreValue);
                isHappy = true;
                timesHit++;
                if (timesHit >= 1)
                {
                    Debug.Log("Showing next sprite!");
                    ShowNextHitSprite();
                }
                else
                {
                    Debug.Log("else 1");
                    //
                }

            }
            else
            {
                Debug.Log("else 2");
                //
            }
        }
        if ((col.gameObject.tag == "KillBox") && (isHappy == false))
        {
            Debug.Log("player loses one life!");
            PlayerController.life--;
            if (PlayerController.life <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            else
            {
                Debug.Log("else 3");
                //
            }
            Destroy(this.gameObject);




        }
        if ((col.gameObject.tag == "KillBox") && (isHappy == true))
        {
            Debug.Log("happy and dead!");
            Destroy(this.gameObject);
        }

        else
        {
            Debug.Log("else 4");
            //
        }
        

       

    }

    private void ShowNextHitSprite()
    {
        Debug.Log("next sprite shown!");
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
