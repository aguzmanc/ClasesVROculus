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
            yield return new WaitForSeconds(Random.RandomRange(1, 3));
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
