using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreDosPuntos : MonoBehaviour
{
    public GameObject bala;
    public Transform cubo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Instantiate(bala,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity );
        }
        //cubo.transform.position = Vector3.Lerp(derecha.position, izquierda.position, 0.5f);
        // Physics.Raycast

    }
}
