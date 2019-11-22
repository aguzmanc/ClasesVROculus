using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    [Header("Arco")]
    public Renderer rend;
    Rigidbody body;

    public Transform cuerda;


    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto;

    [Header("Cuerda")]
    public GameObject centroCuerda;
    public Transform cuerdaMesh;
    public Renderer rendCuerda;

    float distance;

    [Header("Flecha")]
    public GameObject prfabFlecha;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rend.material = materialSuelto;
        rendCuerda.material=materialSuelto;
    }

    private void Update() {
        if(Input.GetButtonUp("Fire1")){
            DisparaFlecha(100);
        }
    }



    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public void DisparaFlecha(float speed)
    {
        GameObject f = Instantiate(prfabFlecha,transform.position,transform.rotation);
        f.GetComponent<Rigidbody>().AddForce(transform.forward*speed);
        Destroy(f,3);
    }

    public void Estirar(Vector3 position){
        cuerda.localPosition = -Vector3.forward*Vector3.Distance(transform.position,position);
    }

    public void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void TocarC() {
        rendCuerda.material = materialTocado;
    }


    public void DejarDeTocarC() {
        rendCuerda.material = materialSuelto;
    }

    public void MoverCuerda(Transform agarrador)
    {
        distance = Vector3.Distance(centroCuerda.transform.position,agarrador.position);
        

        rendCuerda.material = materialAgarrado;
        //body.isKinematic = true;
        //transform.parent = agarrador;

        if(cuerdaMesh.localPosition.z>=0 && cuerdaMesh.localPosition.z<=0.05)
        {
            transform.localPosition = Vector3.forward*distance;
            transform.localRotation = Quaternion.identity;
        }
        
    }
    public void SoltarCuerda()
    {
        cuerdaMesh.localPosition=Vector3.zero;
        DisparaFlecha((100*cuerdaMesh.localPosition.z)/0.05f);
    }


    public void Soltar() {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }


}
