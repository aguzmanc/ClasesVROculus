using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetoAgarrable : MonoBehaviour
{
    [Header("Objetos")]
    public Renderer rend;
    protected Rigidbody body;


    [Header("Materiales")]
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSuelto;
    // Start is called before the first frame update
    public virtual void Start()
    {
         body=GetComponent<Rigidbody>();
    }
    
    #region Estdos de Agarre

    public void Tocar() {
        rend.material = materialTocado;
    }


    public void DejarDeTocar() {
        rend.material = materialSuelto;
    }

    public virtual void Agarrar(Transform agarrador) { 
        rend.material = materialAgarrado;
        body.isKinematic = true;
        transform.parent = agarrador;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public virtual void Soltar() 
    {
        transform.parent = null;
        rend.material = materialTocado;
        body.isKinematic = false;
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
