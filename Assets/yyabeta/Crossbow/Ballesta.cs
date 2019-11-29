using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballesta : MonoBehaviour
{
    [Header("Ballesta")]
    public Renderer rend;
    Rigidbody body;

    public Material materialTocado;
    Material materialAgarrado;
    public Material materialSuelto;


    [Header("Flecha")]
    public GameObject prfabFlecha;

    public Transform disparador;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        materialAgarrado = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void DisparaFlecha(float speed)
    {
        GameObject f = Instantiate(prfabFlecha,disparador.position,disparador.rotation);
        f.GetComponent<Rigidbody>().AddForce(disparador.transform.forward*speed);
        Destroy(f,3);
    }
    public void Soltar() 
     {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }

}
