using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public float valor;
    public puntos puntos;
    List<string> flechas;
    void Start()
    {
        flechas = new List<string>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag=="cuerda" && valor!=null && !flechas.Contains(other.name))
        {
            puntos.AumentarPuntaje(valor);
            flechas.Add(other.name);
        }
    }
}
