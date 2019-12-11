using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vecino : MonoBehaviour
{
    public List<Transform> PatrolWaypoints;
    public Transform WhachtPoint;

    public float speed;
    int current=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(PatrolWaypoints[current].position,transform.position)<1)
        {
            current++;
            if(current>=PatrolWaypoints.Count)
                current=0;
        }
        transform.position=Vector3.MoveTowards(transform.position,PatrolWaypoints[current].position,Time.deltaTime*speed);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="Proyectil")
        {
            float value=0;
            switch(other.gameObject.name)
            {
                case "Pelota":
                    value=0.1f;
                break;
                case "Disco":
                    value=0.5f;
                break;
            }
            GameObject.FindObjectOfType<GameManager>().AddIra(value); 
        }    
    }
}
