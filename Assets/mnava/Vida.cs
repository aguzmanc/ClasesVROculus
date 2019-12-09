using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    int vida;
    Text vidaTexto;
    public GameObject textual;
    void Start()
    {
        vida=100;
        vidaTexto=textual.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vida);
        vidaTexto.text="Vida: "+vida;
        if(vida<=0){
           Movimiento movimiento= transform.GetComponent<Movimiento>();
            transform.localRotation=Quaternion.Euler(90, 0, 74.617f);
           movimiento.enabled=false;
           //SceneManager.LoadScene("Final");
              
        }
       

    }
    public void bajarVida(int daño)
    {
        vida-=daño;
    }
}
