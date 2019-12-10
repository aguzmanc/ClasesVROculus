using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{
    public Renderer indicador;
    public Material tocado,noTocado;
    public float tiempo ;
    Text tiempoTexto;
    public GameObject textual;
    // Start is called before the first frame update
    void Start()
    {
         tiempo = 5.0f;
         tiempoTexto=textual.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempo<5)
         tiempoTexto.text=tiempo+"";
         if(tiempo<0)
         {
              SceneManager.LoadScene("Final");
         }
    }
    void OnTriggerStay(Collider other)
    {
        tiempo -= Time.deltaTime;
         indicador.material=tocado;
  
    }
     void OnTriggerExit(Collider other)
    {
         tiempo = 5.0f;
         tiempoTexto.text="Mantener la Mano dentro para reiniciar";
         indicador.material=noTocado;
    }
}
