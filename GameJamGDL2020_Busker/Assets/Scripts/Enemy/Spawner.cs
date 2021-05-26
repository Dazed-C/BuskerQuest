using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject passenger;
    private float timer;
    public Transform t1;
    public Transform t2;

    public int caseSwitch;

    void Start()
    {
        // link to point counter instead for the switch 
        caseSwitch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        var currentScore = FindObjectOfType<GameSession>().GetScore();
        switch (caseSwitch)
        {
            case 1:
                if (timer >= 5)
                {
                    SpawnPassenger();

                }
                if (currentScore >= 5000)
                {
                    caseSwitch++;
                }
                break;

            case 2:
                if (timer >= 3)
                {
                    SpawnPassenger();

                }
                if (currentScore >= 10000)
                {
                    caseSwitch++;
                }
                break;

            case 3:
                if (timer >= 1)
                {
                    SpawnPassenger();

                }
                break;

            default:
                break;

        }


    }

    void SpawnPassenger()
    {
        timer = 0;
        float yRandom = Random.Range(t1.transform.position.y, t2.transform.position.y);
        Instantiate(passenger, new Vector3(t1.position.x + Random.Range(1f, 10f), yRandom), Quaternion.Euler(0, 0, 0));
    }

}
