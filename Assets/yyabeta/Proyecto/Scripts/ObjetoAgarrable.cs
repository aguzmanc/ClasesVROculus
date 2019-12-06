using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjetoAgarrable : MonoBehaviour
{
    Rigidbody rigidbody = null;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
