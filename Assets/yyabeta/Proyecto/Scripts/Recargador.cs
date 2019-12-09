using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recargador : ObjetoAgarrable
{

    public bool estaRecargado = true;

    public Transform tRecargador;


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
        float zPosition = Vector3.Distance(agarrador.position,transform.position);

        zPosition=Mathf.Max(0f,zPosition);
        zPosition=Mathf.Min(0.8f,zPosition);
        tRecargador.localPosition = Vector3.forward*zPosition*0.1f;
        rend.material = materialAgarrado;
        tCollider.enabled=false;
    }

    public override void Soltar()
    {
        rend.material = materialTocado;
        tCollider.enabled=true;
    }


}
