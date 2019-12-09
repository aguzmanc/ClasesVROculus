using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Renderer rend;
    Rigidbody body;
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSoltado;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tocar(){
        rend.material = materialTocado;
    }
    public void DegarTocar(){
        rend.material = materialSoltado;
    }
    public void Agarrar(Transform agarrador){
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;
        transform.localPosition=Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void soltar(){
        transform.parent=null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }
}
