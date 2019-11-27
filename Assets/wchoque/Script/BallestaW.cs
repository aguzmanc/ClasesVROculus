using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaW : MonoBehaviour
{
       public Renderer rend;
    Rigidbody body;
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSoltado;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
