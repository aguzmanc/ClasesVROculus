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

    public Transform disparador;
    
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
        GameObject f = Instantiate(prfabFlecha,disparador.position,disparador.rotation);
        f.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed*2);
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
        distance = Vector3.Distance(agarrador.position,centroCuerda.transform.position);

        distance=Mathf.Max(0f,distance);
        distance=Mathf.Min(0.3f,distance);
        
        rendCuerda.material = materialAgarrado;
        cuerdaMesh.transform.localPosition = Vector3.forward*distance;
        
    }
    public void SoltarCuerda()
    {
        cuerdaMesh.localPosition=Vector3.zero;
        DisparaFlecha((100*cuerdaMesh.localPosition.z)/0.3f);
    }


    public void Soltar() {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }


}
