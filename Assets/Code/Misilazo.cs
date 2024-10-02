using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misilazo : MonoBehaviour
{
    public TMPro.TMP_Text TextoMisilazo;
    public float tiempoRestante = 5f; 
    public bool disponible = false;

    void FixedUpdate()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            TextoMisilazo.text = "Misilazo: " + Mathf.CeilToInt(tiempoRestante);
        }
        else
        {
            disponible = true;
            TextoMisilazo.text = "matalos :D";
        }
    }


}
