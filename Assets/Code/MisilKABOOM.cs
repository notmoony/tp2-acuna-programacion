using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class MisilKABOOM : MonoBehaviour
{
    public GameObject MisilPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Instantiate(MisilPrefab, transform.position, Quaternion.identity);
        }
    }
}