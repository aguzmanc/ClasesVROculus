using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJuego : MonoBehaviour
{
    bool iniciar;
    bool terminar;
    bool generarEnemigos;
    public Renderer rend;
    public Material apagado;
    public Material encendido;
    Vector3 boton_pulsado;
    Vector3 boton_sin_pulsar;
    public GameObject hongo;
    public int nHongos;
    public GameObject [] posicionesiniciales;
    List<Vector3> vectoresenLista;
    public puntaje puntaje;
    bool boton_presionado;

    public GameObject mensajeInicio;
    void Start()
    {
        mensajeInicio.SetActive(true);        
        boton_presionado=false;
        vectoresenLista = new List<Vector3>();
        nHongos = 0;
        boton_pulsado = new Vector3(-0.351f, 0.824f, 0.055f);
        boton_sin_pulsar = new Vector3(-0.351f, 0.824f, 0f);
        iniciar=false;
        terminar=false;
        generarEnemigos=false;
        rend.material = apagado;
    }
    void Update()
    {
        if (iniciar)
            this.MoverBotonInicio();
        if (terminar)
            this.MoverBotonFin();
    }
    Vector3 asignar;
    IEnumerator Generar()
    {   
        yield return new WaitForSeconds(4);
        while(true){
            yield return new WaitForSeconds(Random.RandomRange(1, 2));
            if (puntaje.temporizador<1)
            {
                AcabarPartida();
                break;
            }
            if (nHongos<3)
            {
                nHongos++;
                asignar = GetVector3Array();
                if (asignar != new Vector3())
                {
                    Instantiate(hongo, asignar, Quaternion.Euler(0,180,0));
                }
                //listahongos.Add(hongo);
            }
        }
        

    }

    void AcabarPartida()
    {
        terminar=true;
        StopAllCoroutines();
    }

    Vector3 GetVector3Array(){
        Vector3 x = new Vector3();
        int cont = 0;
        int random;
        bool repetido=false;
        while (true)
        {
            random=Random.Range(0, 4);
            for (int i = 0; i < vectoresenLista.Count; i++)
            {
                if (vectoresenLista[i]==posicionesiniciales[random].transform.position)
                {
                    repetido=true;
                    break;
                }
            }
            if (cont>100 || !repetido){
                x = posicionesiniciales[random].transform.position;
                break;

            }
        }
        return x;
    }
    public void Remover(Transform t){
        int remove=-1;
        nHongos--;

        for (int i = 0; i < vectoresenLista.Count; i++)
        {
            if (vectoresenLista[i]==t.position)
            {
                remove=i;
                break;
            }
        }
        if (remove>-1)
        {
            vectoresenLista.RemoveAt(remove);
        }
    }
    void MoverBotonInicio(){
        transform.position = Vector3.Lerp(transform.position, boton_pulsado, 0.08f);
        if (transform.position==boton_pulsado)
        {
            iniciar=false;
            StartCoroutine(Generar());
            puntaje.IniciarPartida();
            //generarEnemigos=true;
        }
    }
    void MoverBotonFin(){
        transform.position = Vector3.Lerp(transform.position, boton_sin_pulsar, 0.08f);
        if (transform.position==boton_sin_pulsar)
        {
            iniciar=false;
            terminar=false;
            boton_presionado=false;
            rend.material = apagado;   
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag=="mano")
        {
            if (!boton_presionado)
            {
                boton_presionado=true;
                iniciar=true;   
                rend.material = encendido;         
                mensajeInicio.SetActive(false);                
            }
        }
    }
}
