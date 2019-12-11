using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hongo : MonoBehaviour
{
    bool subir;
    bool bajar;
    Vector3 arriba;
    Vector3 original;

    void Start()
    {
        original = transform.position;
        arriba = new Vector3(transform.position.x, transform.position.y+0.4f, transform.position.z);
        subir=false;
        bajar=false;
        StartCoroutine(SubirBajar());
    }
    void Update() {
        Debug.Log(subir+" "+bajar);

        if (subir)
        {
            SubirHongo();
        }
        if (bajar)
        {
            BajarHongo();
        }
    }

     IEnumerator SubirBajar()
    {   
        while(true){
            yield return new WaitForSeconds(Random.Range(1,2));
            subir=true;
            bajar=false;
            yield return new WaitForSeconds(1);
            //yield return new WaitForSeconds(Random.Range(1,3));
            subir=false;
            bajar=true;
        }

    }
    void SubirHongo(){
        transform.position = Vector3.Lerp(transform.position, arriba, 0.1f);
    }
    void BajarHongo(){
        transform.position = Vector3.Lerp(transform.position, original, 0.15f);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.name=="bate")
        {
            other.GetComponentInChildren<bate>().NoGolpear();
            StopAllCoroutines();
            subir=false;
            bajar=true;
            StartCoroutine(Destruir());
        }
    }
    IEnumerator Destruir()
    {   
        while(true){
            yield return new WaitForSeconds(1f);
            Destroy(transform.gameObject);
        }

    }
}
