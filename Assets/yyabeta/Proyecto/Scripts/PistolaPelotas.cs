using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaPelotas : Arma
{

    [Header("Arma")]
    public List<GameObject> municion;

    public Transform boca;

    public Recargador recarga;

    [Range(0,100)]
    public float speed=50;



    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }
}
