using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoA : MonoBehaviour
{
    Rigidbody body;
    public Material materialAgarrado;
    public Material materialSuelto;
    public Material materialTocado;

    

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody>();
       // rend = GetComponent<Renderer>();??
        rend.material=materialSuelto;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tocar(){
        rend.material=materialTocado;

    }

    public void DejarDeTocar()
    {
        rend.material=materialSuelto;
    }

    public void Agarrar(Transform agarrador)
    {
         rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    
    }


public void Soltar()
{
transform.parent=null;
rend.material=materialTocado;
body.isKinematic=false;
}


}
