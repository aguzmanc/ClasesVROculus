using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntaje : MonoBehaviour
{
    public int TIEMPO=30;
    public int PUNTOS_GOLPE=10;
    public int GOLPES_RESTANTES=70;
    public int temporizador;
    public int golpes;

    public int puntos;
    public int golpesEnemigos;
    public int golpesMaquina;
    public int nEnemigos;

    public TextMesh textoTiempo;
    public TextMesh textoPuntos;
    public TextMesh textoCentro;
    public GameObject mensajeFinal;
    
    void Start()
    {
        mensajeFinal.SetActive(false);        
    }


    public void IniciarPartida(){
        mensajeFinal.SetActive(false);      
        temporizador = TIEMPO;
        golpes=GOLPES_RESTANTES;
        puntos=0;
        golpesEnemigos=0;
        golpesMaquina=0;
        nEnemigos=0;
        textoCentro.text = "Golpes Restantes: "+golpes;
        StartCoroutine(Iniciar());
    }
    IEnumerator Iniciar()
    {   
        textoCentro.text = "3";
        yield return new WaitForSeconds(1);
        textoCentro.text = "2";
        yield return new WaitForSeconds(1);
        textoCentro.text = "1";
        yield return new WaitForSeconds(1);
        transform.GetComponent<AudioSource>().Play();
        
        textoCentro.text = "Golpes Restantes: "+"\n"+golpes;
        while(true){
            temporizador--;
            textoTiempo.text = temporizador+"";
            yield return new WaitForSeconds(1);
            if (temporizador<1)
            {
                break;
            }
        }
        yield return new WaitForSeconds(2);
        mensajeFinal.GetComponentInChildren<TextMesh>().text=
        "Puntaje: "+puntos+"\n"+
        "Enemigos en Partida: "+nEnemigos+"\n"+
        "Golpes a Enemigos: "+golpesEnemigos+"\n"+
        "Golpes a la Máquina: "+golpesMaquina+"\n"+
        "Golpes Restantes: "+golpes;
        ;
        mensajeFinal.SetActive(true);        
         AcabarPartida();

    }
    public void GolpeEjecutado(bool golpeAlTopo){
        
        golpes--;
        if (golpeAlTopo)
        {
            puntos+=PUNTOS_GOLPE;            
            golpesEnemigos++;
        }
        else{
            golpesMaquina++;
            puntos--;
        }
        if (golpes<=0)
        {
            temporizador=0;
        }
        textoPuntos.text = puntos+"";
        textoCentro.text = "Golpes Restantes: "+"\n"+golpes;
    }

    void AcabarPartida()
    {
        textoPuntos.text = "0000";
        textoCentro.text = "00000000000000";
        textoTiempo.text = "000";
        StopAllCoroutines();
        transform.GetComponent<AudioSource>().Stop();
    }
    public void AumentarNEnemigos(){
        nEnemigos++;
    }
}
