using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayo : MonoBehaviour
{
    
    public Renderer cuadro;
    public Material transparente;
    public Material verde;
    martillo martillo;
    bool finalizado;
    bool subio;
    void Start()
    {
        finalizado=false;
        subio=false;
        martillo=null;
    }

    void Update()
    {
        if (!finalizado)
        {
            
            RaycastHit hit;
            bool choca = Physics.Raycast(transform.position, transform.forward,  out hit);
            if (choca)
            {
                if (hit.collider.name== "zona_martillo")
                {
                    cuadro.material=verde;
                    if (martillo==null)
                    {
                        martillo = hit.collider.GetComponentInChildren<bate>().transform.parent.GetComponent<martillo>();
                        martillo.subiendo=true;
                        martillo.DefinirFinal(transform);
                    }
                    else{
                        finalizado = martillo.finalizado;
                        subio = martillo.terminado;
                        martillo.Mover();
                    }
                    Debug.DrawRay(transform.position, 6f*transform.forward, Color.blue);
                }
                else
                {
                    cuadro.material=transparente;
                    if (martillo!=null)
                    {
                        if (!subio)
                        {
                            martillo.Reset();
                        }
                        else
                        {
                            martillo.Mover();
                        }
                    }
                    Debug.DrawRay(transform.position, 6f*transform.forward, Color.red);
                }
            }
        }
        else
        {
            Destroy(transform.gameObject);
        }


    }
}
