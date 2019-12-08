using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> puntos;

      public float speed = 0.5F;

    // Time when the movement started.
    private float startTime;
     Transform inicio;
    Transform fin;
    int contador;

    // Total distance between the markers.
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;
        inicio=puntos[0];
        fin=puntos[1];
        contador=0;
       
    }

    // Update is called once per frame
    void Update()
    {

        journeyLength = Vector3.Distance(inicio.position,fin.position);
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
         transform.position = Vector3.Lerp(inicio.position,fin.position,fractionOfJourney);
         if(transform.position==fin.position)
         {
            startTime = Time.time;
             contador+=1;
             if(contador==5)
             {
                 inicio=puntos[5];
                 fin=puntos[0];
                 contador=-1;
                 
             }
             else
             {
                inicio=puntos[contador];
                fin=puntos[contador+1];
             }
         }
       
    }
}
