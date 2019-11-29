using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoC : MonoBehaviour
{
    public Renderer rend;
    Rigidbody body;
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSoltado;
    public GameObject cuerda;
    // Start is called before the first frame update
    void Start()
    {
        body =GetComponent<Rigidbody>();
        rend.material=materialSoltado;
        cuerda =transform.Find("pivotCuerda").gameObject;
        cuerda.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tocar(){
        rend.material = materialTocado;
        Debug.Log("toco");
    }
    public void DejarTocar(){
        rend.material = materialSoltado;
    }
    public void Agarrar(Transform agarrador){
        rend.material = materialAgarrado;
        body.isKinematic=true;
        transform.parent = agarrador;
        transform.localPosition=Vector3.zero;
        transform.localRotation = Quaternion.identity;
        cuerda.SetActive(true);
    }
    public void Soltar(){
        transform.parent =null;
        rend.material =materialTocado;
        body.isKinematic =false;
        cuerda.SetActive(false);
    }
}

