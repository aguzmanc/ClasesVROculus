using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuadroTiempo : MonoBehaviour
{

    public ArradarArma arma;
    public Puntuacion puntuacion;
      public TextMeshPro txtTexto;
    public TextMeshPro txtTiempo;
    public float duracion;
    public float segundo;
    public bool comenzoJuego;
   public  bool evitarRepeticion;
   public bool gano;
    // Start is called before the first frame update
    void Start()
    {
        comenzoJuego = false;
        duracion = 120;
        segundo =0;
        gano = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(comenzoJuego==true && evitarRepeticion==false){
            Debug.Log("metodo cuador entro");
            Debug.Log(comenzoJuego);
             gano = false;
            puntuacion.puntos =0;
            arma.cantidadMuniciones=10;
            arma.GenerarSpriteBalas();
              StartCoroutine(tiempoDuracion());
            evitarRepeticion = true;
           
            txtTexto.text = "?????";
        }

        if(segundo==duracion && comenzoJuego==true){
            StopAllCoroutines();
            comenzoJuego=false;
            evitarRepeticion = false;
            txtTexto.text = "PERDISTE !!!!!";
            puntuacion.puntos = 0;
        }
     /*   if(gano && puntuacion.puntos>puntuacion.){
            StopAllCoroutines();
            comenzoJuego=false;
            evitarRepeticion = false;
            puntuacion.puntos = 0;
            txtTexto.text = "GANASTE !!!!!";
        }*/
    }
    IEnumerator tiempoDuracion(){
        while(segundo<=duracion){
        //    Debug.Log(segundo+"");
            txtTiempo.text = segundo.ToString();
            yield return new WaitForSeconds(1);
            segundo +=1;
        }
    }
}
