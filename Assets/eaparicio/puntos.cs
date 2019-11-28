using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntos : MonoBehaviour
{
    public float numeros;
    TextMesh texto;
    void Start()
    {
        numeros=0;
        texto = transform.GetComponentInChildren<TextMesh>();
        texto.text = numeros+"";
    }
    public void AumentarPuntaje(float puntos){
        numeros+=puntos;
        texto.text = numeros+"";
    }

}
