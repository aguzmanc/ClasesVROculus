using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    
    public CuadroTiempo tiempo;
    public TextMeshPro txtPuntuacion;
    public int puntos;
    public bool ganaste;
    public int mayorPuntaje;
    // Start is called before the first frame update
    void Start()
    {
        puntos=0;
        mayorPuntaje=200;
        txtPuntuacion.text = puntos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempo.comenzoJuego){
            if(puntos>=mayorPuntaje){
                ganaste=true;
           
            }

            txtPuntuacion.text = puntos.ToString();
        }
       
        
    }
}
