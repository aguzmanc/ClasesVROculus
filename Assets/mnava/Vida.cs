using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    int vida;
    void Start()
    {
        vida=100;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vida);
    }
    public void bajarVida(int daño)
    {
        vida-=daño;
    }
}
