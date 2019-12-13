using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaPelotas : Arma
{

    [Header("Arma")]
    public List<GameObject> municion;

    public Transform boca;

    public Recargador recarga;

    [Range(100,500)]
    public float speed=500;

    AudioSource au;



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        au=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Disparar();
        }
    }

    public override void Disparar()
    {
        if (municion.Count>0)
        {
            if(recarga.estaRecargado){
                Rigidbody r = municion[0].GetComponent<Rigidbody>();
                r.transform.parent=null;
                r.isKinematic=false;
                r.AddForce(boca.forward*speed);
                municion.RemoveAt(0);
                municion[0].transform.localPosition=Vector3.zero;
                au.Play();
            }
        }
    }
}
