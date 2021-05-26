using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizerSongWave : MonoBehaviour
{
    public float life = 4.0f,curlife = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(curlife);
        curlife += Time.deltaTime;
        if (curlife >= life)
        {
            GameObject.Find("UltimateSpawner").GetComponent<UltimateSkill>().callOptimizer = false;
            curlife = 0;
            Destroy(this.gameObject);
            
        }
    }
}
