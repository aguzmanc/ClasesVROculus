using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class martillo : MonoBehaviour
{
    Vector3 origen;
    Vector3 subida;
    Vector3 final;
    
    Vector3 rotacionFinal;
    public bool subiendo;
    public bool terminado;
    public bool finalizado;
    void Start()
    {
        subiendo=false;
        terminado=false;
        finalizado=false;
        rotacionFinal=new Vector3(0,180f,0);
        origen = transform.position;
        subida = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
    }
    public void DefinirFinal(Transform t){
        final = new Vector3(t.position.x-1f, t.position.y, t.position.z-1.55f);
    }
    public void Mover()
    {
        if (!finalizado)
        {
            if (terminado)
            {   
                transform.position = Vector3.Lerp(transform.position, final, 0.05f);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotacionFinal), 0.2f);
                if (transform.position==final)
                {
                    finalizado=true;
                }
            }
            else{
                
                if ((transform.position-subida).magnitude<0.1f)
                {
                    terminado=true;
                }
                else{
                    if (subiendo)
                    {
                        transform.position = Vector3.Lerp(transform.position, subida, 0.015f);
                    }
                }
            }
        }
    }
    public void Reset()
    {
        Debug.Log("reset");
        if (!finalizado)
        {
            transform.position = Vector3.Lerp(transform.position, origen, 0.05f);
        }
    }
}
