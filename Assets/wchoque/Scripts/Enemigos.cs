using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public Puntuacion puntuacion;
    public GameObject posiciones;
    float VelocidadEnemigo=5;
    public CuadroTiempo tiempo;
    public GameObject enemigoIns;
    public GameObject enemigoInsQuieto;
    public GameObject enemigo;
    Vector3 scaleDefinido;
    Vector3[] scaleEnemigos;
    // Start is called before the first frame update
    Vector3 scaleNormalEnemigo = new Vector3(1,1,1);
    Vector3 scaleMenosEnemigo = new Vector3(0.9f,0.9f,0.9f);
    Vector3 scaleMenosEnemigo1 = new Vector3(0.8f,0.8f,0.8f);
    Vector3 scaleNormalEnemigo2= new Vector3(0.7f,0.7f,0.7f);
    int valor;
    int valorOtro;
    int cambioDuracion=30;
    bool cambio=false;
    bool inicioJuego=false;
    float contador;
     public Transform[] posicionesEne;
     public List<Transform> posicionesEnemigos = new List<Transform>();
    void Start()
    {
        
        scaleEnemigos = new Vector3[4];
        scaleEnemigos.SetValue(scaleNormalEnemigo,0);
        scaleEnemigos.SetValue(scaleMenosEnemigo,1);
        scaleEnemigos.SetValue(scaleMenosEnemigo1,2);
        scaleEnemigos.SetValue(scaleNormalEnemigo2,3);
        contador = 0;
        posicionesEne= posiciones.GetComponentsInChildren<Transform>();
        for(int i=0;i<posicionesEne.Length;i++){
            posicionesEnemigos.Add((Transform)posicionesEne.GetValue(i));
        }
        //int v = posicionesEnemigos.Length;
    }

    // Update is called once per frame
    void Update()
    {
         if(tiempo.comenzoJuego==true && inicioJuego == false){
             Debug.Log("Cpmenzp al inicio del juegp");
            StartCoroutine(instanciarEnemigos());
             Debug.Log(scaleEnemigos.GetValue(valor));
             inicioJuego = true;
         }
         if(tiempo.comenzoJuego == true && tiempo.segundo>0 && tiempo.segundo < tiempo.duracion-1){
             contador += Time.deltaTime; 
             if(tiempo.segundo%12==0){
                 VelocidadEnemigo+=Time.deltaTime;
             }
             if(tiempo.segundo%cambioDuracion == 0 && contador > cambioDuracion-2){
                 Debug.Log("entro al metodo");
                 contador=0;
                 if(cambio==false){
                     StopAllCoroutines();
                    StartCoroutine(instanciarEnemigoNoCaminante());
                    cambio=true;
                 }
                 else{
                     if(cambio==true){
                         Debug.Log("En el cambio true");
                         StopAllCoroutines();
                         StartCoroutine(instanciarEnemigos());
                         cambio=false;
                     }
                 }
                 
             }
         }
         if(tiempo.comenzoJuego == false && tiempo.segundo == tiempo.duracion &&inicioJuego){
             Debug.Log("se termino el juego");
             inicioJuego = false;
             VelocidadEnemigo = 5;
             tiempo.segundo = 0;
              puntuacion.ganaste = false;
             StopAllCoroutines();
         }

         if(puntuacion.ganaste){
         Debug.Log("se termino el juego");
             inicioJuego = false;
             VelocidadEnemigo = 5;
             tiempo.segundo = 0;
             puntuacion.ganaste = false;
             StopAllCoroutines();
         }
        
    }
    IEnumerator instanciarEnemigos(){
        Debug.Log("cambio de corrutina" + 1);
        while(true){
        valor = Random.Range(0,3);
       scaleDefinido = (Vector3)scaleEnemigos.GetValue(valor);
        enemigo = Instantiate(enemigoIns);
        enemigo.transform.position = transform.position;
        enemigo.transform.rotation = transform.rotation;
        enemigo.transform.localScale =scaleDefinido;
        enemigo.transform.GetComponent<AndarObjetivo>().velocidad = VelocidadEnemigo;
         yield return new WaitForSeconds(2f);
         }
    }
    IEnumerator instanciarEnemigoNoCaminante(){

        Debug.Log("cambio de corrutina" + 2);
        while(true){
            valor = Random.Range(0,3);
            valorOtro = Random.Range(0,posicionesEnemigos.Count);
            scaleDefinido = (Vector3)scaleEnemigos.GetValue(valor);
            enemigo = Instantiate(enemigoInsQuieto);
            enemigo.transform.parent = posicionesEnemigos[valorOtro];
            posicionesEnemigos.RemoveAt(valorOtro);
            enemigo.transform.localPosition = Vector3.zero;
            enemigo.transform.localRotation = Quaternion.identity;
            enemigo.transform.localScale = scaleDefinido;
         yield return new WaitForSeconds(2f);
         }
    }
}
