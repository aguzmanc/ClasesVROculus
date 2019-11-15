using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mano_zquierda;
    void Start()
    {
        transform.parent=mano_zquierda.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(0,0,0);
    }
}
