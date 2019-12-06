using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : ObjetoAgarrable
{
    // Start is called before the first frame update
    public override void Start()
    {
       base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public override void Soltar() 
    {
        base.Soltar();
        body.AddForce(transform.forward*100f);
    }
}
