using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaA : MonoBehaviour
{

    [Header("Flecha")]
    public GameObject prfabFlecha;

     Rigidbody body;
    public Material materialAgarrado;
    public Material materialSuelto;
    public Material materialTocado;

     public GameObject cu;

     public PuntoDisparo pd;

     public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        body= GetComponent<Rigidbody>();
       // rend = GetComponent<Renderer>();??
        rend.material=materialSuelto;
        cu= transform.Find("pivotB").gameObject;
        cu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKeyDown(KeyCode.O) || (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch)>=1)
        || (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch)>=1))
        {
            pd.DisparaFlecha(169);
        }
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
        cu.SetActive(true);
        Debug.Log("SIUUU2");
    
    }


public void Soltar()
{
transform.parent=null;
rend.material=materialTocado;
body.isKinematic=false;
cu.SetActive(false);
//Debug.Log("DISPARO!");
}




}
