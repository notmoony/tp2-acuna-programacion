using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public float velocidad;
    public GameObject enemigo;
    public float Timer;
    public float spawnMax = 10;
    public float spawnMin = 5;
    
    void FixedUpdate()
    {
        enemigo.transform.Translate(Vector2.right * velocidad * Time.deltaTime);

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Timer = Random.Range(spawnMin, spawnMax); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Paredes") 
        {
            transform.position = new Vector4 (transform.position.x, transform.position.y -1, transform.position.z);
            velocidad *= -1;
    
        }

        if(collision.gameObject.name == "nave")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.name == "misil")
        {
            Destroy(gameObject);
        }
        
    }

}
