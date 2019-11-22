using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoA : MonoBehaviour
{

    [Header("Flecha")]
    public GameObject prfabFlecha;

    public GameObject cuerda;
    Rigidbody body;
    public Material materialAgarrado;
    public Material materialSuelto;
    public Material materialTocado;

    

    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody>();
       // rend = GetComponent<Renderer>();??
        rend.material=materialSuelto;
        cuerda= transform.Find("pivot").gameObject;
        cuerda.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.F)){
            DisparaFlecha(100);
        }
    }

public void DisparaFlecha(float speed)
    {
        Quaternion quaternion = Quaternion.Euler(90, 0, 0);
        GameObject f = Instantiate(prfabFlecha,transform.position,quaternion);
        f.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed*2);
        Destroy(f,10);
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
        cuerda.SetActive(true);

    
    }


public void Soltar()
{
transform.parent=null;
rend.material=materialTocado;
body.isKinematic=false;
cuerda.SetActive(false);
Debug.Log("DISPARO!");


}


}
