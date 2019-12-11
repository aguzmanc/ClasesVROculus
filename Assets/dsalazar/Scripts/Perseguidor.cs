using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Perseguidor : MonoBehaviour {
    public GameObject objetivo;
    public float speed = 0.05f;
    public AudioSource moviminetoTanke;
    private void Start() {
        moviminetoTanke.Play();
    }
    void Update () {
        if (!objetivo) {
            return;
        }
        if (true)
        {
            
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                 objetivo.transform.position+(new Vector3(0,0,6)),
                                                 speed * Time.deltaTime);
        transform.forward = objetivo.transform.position - transform.position;
    }
}
