using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaIP : MonoBehaviour
{
    public Renderer rend;

    public Material noTaken;
    public Material canTake;
    public Material taken;

    public GameObject prefabFlecha;
    public GameObject flecha;
    public AgarrarCuerdaIP agarrador;

    public bool flechaEnArco=false;
    bool canShot=false;
    void Start()
    {
        rend.material = noTaken;
        agarrador=GameObject.FindObjectOfType<AgarrarCuerdaIP>();
    }


    void Update()
    {
    }


    public void Tocar(){
        rend.material = canTake;
    }

    public void DejarDeTocar(){
        rend.material = noTaken;
    }       


    public void Agarrar(){
        print("Cuerda agarrada");
        rend.material = taken;
        
        
    }


    public void Soltar(){
        print("Cuerda soltada");
        rend.material = canTake;
        

    } 

    public void Disparar(){
        flecha=Instantiate(prefabFlecha,transform.position,transform.rotation);
        flecha.transform.forward=-transform.forward;
        FlechaIP miFlecha=flecha.GetComponent<FlechaIP>();
        miFlecha.Disparar(agarrador.distancia);
        
    }

}
