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
        flecha=Instantiate(prefabFlecha,transform.position,transform.rotation,transform);
        flecha.transform.forward=-transform.forward;
        canShot=true;
        
    }


    public void Soltar(){
        print("Cuerda soltada");
        rend.material = canTake;
        if (canShot)
        {
            Disparar();
            canShot=false;
        }
        

    } 

    public void Disparar(){
        FlechaIP miFlecha=flecha.GetComponent<FlechaIP>();
        miFlecha.Disparar(agarrador.distancia);
        
    }

}
