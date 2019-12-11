using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJuego : MonoBehaviour
{
    bool iniciar;
    bool generarEnemigos;
    public Renderer rend;
    public Material apagado;
    public Material encendido;
    Vector3 boton_pulsado;
    public GameObject hongo;
    public int nHongos;
    public GameObject [] posicionesiniciales;
    List<Vector3> vectoresenLista;
    void Start()
    {
        vectoresenLista = new List<Vector3>();
        nHongos = 0;
        boton_pulsado = new Vector3(-0.351f, 0.824f, 0.055f);
        iniciar=false;
        generarEnemigos=false;
        rend.material = apagado;
    }
    void Update()
    {
        if (iniciar)
            this.MoverBoton();
    }
    Vector3 asignar;
    IEnumerator Generar()
    {   
        while(true){
            yield return new WaitForSeconds(0.75f);
            if (nHongos<3)
            {
                asignar = GetVector3Array();
                Debug.Log("xd");
                Debug.Log(asignar);
                if (asignar != new Vector3())
                {
                    Instantiate(hongo, asignar, Quaternion.Euler(0,180,0));
                    nHongos++;
                }
                //listahongos.Add(hongo);
            }
        }

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
            if (cont>10 || !repetido){
                x = posicionesiniciales[random].transform.position;
                break;

            }
        }
        return x;
    }
    public void Remover(Transform t){
        nHongos--;
        int remove=-1;
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
    void MoverBoton(){
        transform.position = Vector3.Lerp(transform.position, boton_pulsado, 0.08f);
        if (transform.position==boton_pulsado)
        {
            iniciar=false;
            StartCoroutine(Generar());
            //generarEnemigos=true;
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag=="mano")
        {
            iniciar=true;   
            rend.material = encendido;         
        }
    }
}
