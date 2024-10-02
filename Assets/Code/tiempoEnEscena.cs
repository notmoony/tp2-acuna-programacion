using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoEnEscena : MonoBehaviour
{
    [SerializeField] private float destroyTime; 

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
