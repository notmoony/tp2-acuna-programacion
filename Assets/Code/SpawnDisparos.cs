using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDisparos : MonoBehaviour
{
    public GameObject disparoEnemigo;
    public float Timer;
    public float spawnMax = 10;
    public float spawnMin = 5;

    void Start()
    {
        
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <=0)
        {
            Instantiate(disparoEnemigo, transform.position, Quaternion.identity);
            Timer = Random.Range(spawnMin, spawnMax);
        }
    }
}
