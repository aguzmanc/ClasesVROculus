using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoW : MonoBehaviour
{
    Renderer rend;
    public Material materialTocado;
    public Material materialAgarrado;
    public Material materialSoltado;

    // Start is called before the first frame update
    void Start()
    {
        rend= GetComponent<Renderer>();
        rend.material=materialSoltado;
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
