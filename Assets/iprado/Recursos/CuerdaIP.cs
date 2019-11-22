using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaIP : MonoBehaviour
{
    public Renderer rend;

    public Material noTaken;
    public Material canTake;
    public Material taken;


    void Start()
    {
        rend.material = noTaken;
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
        rend.material = taken;
    }


    public void Soltar(){
        rend.material = canTake;
    } 

}
