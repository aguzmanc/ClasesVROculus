using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public GameObject proyectil;
    public GameObject flechaIntantiate;
    public Rigidbody baala()
    {
        flechaIntantiate= Instantiate(proyectil);
        flechaIntantiate.transform.localScale = Vector3.one;
        flechaIntantiate.transform.parent = transform;
        flechaIntantiate.transform.localPosition = Vector3.zero;
        flechaIntantiate.transform.Rotate(new Vector3(0f,-180f,0f));
        return flechaIntantiate.GetComponentInChildren<Rigidbody>();

    }
}
