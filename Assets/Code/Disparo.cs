using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velocidadDisparo;
    private ContadorEnemigos contadorenemigos;
    

    void Start()
    {
        contadorenemigos = GameObject.FindObjectOfType<ContadorEnemigos>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * velocidadDisparo * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "JueraBicho")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            contadorenemigos.Morido();
                
        }

        if(collision.gameObject.tag == "Paredes")
        {
            Destroy(gameObject);
        }
    }

}