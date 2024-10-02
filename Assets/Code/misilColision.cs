using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class misilColision : MisilKABOOM
{
    [SerializeField] private float radio; 
    
    [SerializeField] private float fuerzaExplosion;

    [SerializeField] private GameObject bichos;

    [SerializeField] private GameObject efectoExplosion;
    private Misilazo TextoMisilazo;
    public float velocidadDisparo;
    public float intervaloMisil = 5f; 
    public float tiempoRestante = 5f; 
    public bool disponible = false;
    private ContadorEnemigos contadorenemigos;
    
    void Start()
    {
        contadorenemigos = GameObject.FindObjectOfType<ContadorEnemigos>();
        TextoMisilazo = GameObject.FindObjectOfType<Misilazo>();
    }
    
    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = (worldMousePosition - transform.position).normalized;

        transform.up = direction;
    
        if (disponible && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector3 direccion = (mousePos - transform.position).normalized;
            Explosion();

            tiempoRestante = intervaloMisil;
            disponible = false;
        }

    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * velocidadDisparo * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion();
        Destroy(collision.gameObject);
    }

    public void Explosion()
    {
        Instantiate(efectoExplosion, transform.position, Quaternion.identity);

        Collider2D[] bichos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in bichos)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerza = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerza);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    public float GettiempoRestante()
    {
        return tiempoRestante;
    }

}
