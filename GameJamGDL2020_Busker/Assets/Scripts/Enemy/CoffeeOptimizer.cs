using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeOptimizer : MonoBehaviour
{
    private float limit = -5.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Change the limit when we change the position of the exit too...

        if (this.gameObject.transform.position.x <= limit)
        {
            //Debug.Log("Removing...");
            Destroy(this.gameObject);
        }
    }
}
