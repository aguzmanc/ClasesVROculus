using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public float fuerza = 10f;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, fuerza), ForceMode.Impulse);
    }
}
