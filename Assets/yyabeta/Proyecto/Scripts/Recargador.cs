using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recargador : ObjetoAgarrable
{

    public bool estaRecargado = true;

    public Transform tRecargador;

    public float zPosition;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Agarrar(Transform agarrador)
    {
        zPosition = Vector3.Distance(agarrador.position,transform.position);

        zPosition=Mathf.Min(0f,zPosition);
        zPosition=Mathf.Max(0.08f,zPosition);
        Debug.Log(zPosition);
        tRecargador.localPosition = Vector3.forward*zPosition;
        rend.material = materialAgarrado;
        tCollider.enabled=false;
    }

    public override void Soltar()
    {
        rend.material = materialTocado;
        tCollider.enabled=true;
    }


}
