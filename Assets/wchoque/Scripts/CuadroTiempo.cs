using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuadroTiempo : MonoBehaviour
{
    public TextMeshPro txtTiempo;
    public float duracion;
    public float segundo;
    public bool comenzoJuego;
   public  bool evitarRepeticion;
    // Start is called before the first frame update
    void Start()
    {
        comenzoJuego = false;
        duracion = 120;
        segundo =0;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(comenzoJuego==true && evitarRepeticion==false){
            Debug.Log(comenzoJuego);
              StartCoroutine(tiempoDuracion());
            evitarRepeticion = true;
        }

        if(segundo==duracion && comenzoJuego==true){
            StopAllCoroutines();
            comenzoJuego=false;
            evitarRepeticion = false;
        }
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
