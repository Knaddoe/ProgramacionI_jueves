using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruits;
    public float actualTime = 0;
    public float totalTime = 2;
    // Update is called once per frame
    void Update()
    {
        if(actualTime < totalTime)
        {
            actualTime += 1 * Time.deltaTime;
            if(actualTime >= totalTime)
            {
                // realizar el spawn
                Instantiate(fruits[Random.Range(0,fruits.Length)], 
                    transform.position, Quaternion.identity);
                actualTime = Random.Range(0.2f,0.6f);
            }

        }
    }
}
