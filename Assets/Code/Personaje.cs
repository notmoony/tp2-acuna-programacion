using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Jugador : MonoBehaviour
{
    public MovedorEnGrilla movedor;
    public GameObject canva;
    
    public float velocidad = 5;

    void Start()
    {
        canva.SetActive(false);
    }

    public void OnMove(InputValue input)
    {
        var direccion = input.Get<Vector2>();
        movedor.Mover(direccion, velocidad);
    }

    private void OnDestroy()
    {
        canva.SetActive(true);
    }

}
