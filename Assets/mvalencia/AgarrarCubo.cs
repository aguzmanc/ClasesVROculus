using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarCubo : MonoBehaviour
{
    public Transform r;
    public Transform l;
    public float speed = 1.0F;

  
    private float startTime;

   
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;

     
        journeyLength = Vector3.Distance(r.position, l.position);
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        float distCovered = (Time.time - startTime) * speed;


        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(r.position, l.position, fractionOfJourney);
    }
}
