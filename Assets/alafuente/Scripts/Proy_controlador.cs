using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proy_controlador : MonoBehaviour
{
    // Start is called before the first frame update
    public int puntaje;
    Coroutine corutina;
    public bool detener = false;
    public bool pausar = false;
    Text textoPuntaje;
    Text textoTiempo;

    private int segundos;
    private static Proy_controlador _instance;
    private List<GameObject> animales;
    private int indice;

    void Awake(){
        _instance = this;
    }

    void Start()
    {
        corutina = StartCoroutine(Temporizador());


        puntaje = 0;
        segundos = 10;
        textoPuntaje = GameObject.Find("TextPuntaje").GetComponent<UnityEngine.UI.Text>();
        textoTiempo = GameObject.Find("TextTiempo").GetComponent<UnityEngine.UI.Text>();

        animales = new List<GameObject>();
        animales.Add(GameObject.Find("Oso_esfera"));
        animales.Add(GameObject.Find("Perro_esfera"));
        animales.Add(GameObject.Find("Pato_esfera"));
        animales.Add(GameObject.Find("Tortuga_esfera"));
        animales.Add(GameObject.Find("Rana_esfera"));
        animales.Add(GameObject.Find("Delfin_esfera"));
        animales.Add(GameObject.Find("Tiburon_esfera"));
        animales.Add(GameObject.Find("CaballoDeMar_esfera"));
        animales.Add(GameObject.Find("Foca_esfera"));
        animales.Add(GameObject.Find("Pinguino_esfera"));
        indice = 0;
    }

    public void ActualizarPuntaje (int puntajeAdicional)
    {
        if(puntaje + puntajeAdicional >= 0)
        {
            puntaje = puntaje + puntajeAdicional;
        }
        else
        {
            puntaje = 0;
        }
        textoPuntaje.text = "PUNTAJE : " + puntaje + " Pts";
    }
    void Stop()
    {
        StopCoroutine(corutina);//DESTRUIR!
        if(puntaje == 10)
        {
            textoTiempo.text = "PERFECTO!";
            textoTiempo.color = Color.green;
        }
        if(puntaje >= 7 && puntaje <= 9)
        {
            textoTiempo.text = "BUEN TRABAJO!";
            textoTiempo.color = Color.green;
        }
        if(puntaje >= 4 && puntaje <= 6)
        {
            textoTiempo.text = "PUEDES MEJORAR";
            textoTiempo.color = Color.yellow;
        }
        if(puntaje >= 0 && puntaje <= 3)
        {
            textoTiempo.text = "TIENES QUE MEJORAR";
            textoTiempo.color = Color.red;
        }
    }
    
    
    IEnumerator Temporizador()
    {
        while(true)
        {            
            yield return new WaitWhile //mientras este sea verdadero
            (
                () => { return pausar; }
            );

            
            textoTiempo.text = segundos + " s";
            
            if(segundos == 10)
            {
                animales[indice].transform.position = transform.position;
            }
            
            yield return new WaitForSeconds(1);
            
            if(segundos > 0)
            {
                segundos--;
            }
            else
            {
                if(animales[indice] != null)
                    Destroy (animales[indice]);

                if(indice == animales.Count-1)
                    detener = true;
                else
                    segundos = 10;
                
                indice++;
            }
            
        }
    }
    
    void Update()
    {
        if(detener)
            Stop();

    }

    public static Proy_controlador GetInstance()
    { 
        return _instance;
    }
}
