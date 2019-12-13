using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vecino : MonoBehaviour
{
    public List<Transform> PatrolWaypoints;
    public Transform WhachtPoint;

    public Transform ojo;

    public float speed;
    int current=0;


    string state;


    Animator anim;
    AudioSource au;

    RaycastHit ver;
    // Start is called before the first frame update
    void Start()
    {
        state="Idel";
        anim=GetComponent<Animator>();
        au=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "Idel":
                if(Vector3.Distance(PatrolWaypoints[current].position,transform.position)<1)
                {
                    transform.localScale=new Vector3(1,1,transform.localScale.z*-1);
                    current++;
                    if(current>=PatrolWaypoints.Count)
                        current=0;
                }
                transform.position=Vector3.MoveTowards(transform.position,PatrolWaypoints[current].position,Time.deltaTime*speed);
            break;
            case "Mirar":
            
                if(Vector3.Distance(WhachtPoint.position,transform.position)>0.5f)
                {
                    transform.position=Vector3.MoveTowards(transform.position,WhachtPoint.position,Time.deltaTime*speed);
                }
                else
                {
                    Debug.DrawRay(ojo.position,Vector3.back*2f,Color.red);
                    if(Physics.Raycast(ojo.position,Vector3.back,out ver,2f))
                    {
                        if (ver.collider.tag=="Player")
                        {
                            GameObject.FindObjectOfType<GameManager>().SetText("Fin del Juego");
                            GameObject.FindObjectOfType<GameManager>().gameOver=true;
                        }
                    }
                     anim.SetBool("Mirando",false);
                }
            break;
        }   
    }

    public void SetEstado(string estado)
    {
        state=estado;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag=="Proyectil")
        {
            au.Play();
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
            anim.SetTrigger("Golpeado");
            anim.SetBool("Mirando",Random.Range(1,3)==1);
        }    
    }
}
