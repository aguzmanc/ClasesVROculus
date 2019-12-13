using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDerecho : MonoBehaviour
{
    GameObject dianaRojaDer;
    GameObject dianaVerdeDer;
    GameObject dianaAmarillaDer;
    GameObject Luz;
    public int activo;
    float timer;
    IEnumerator corr;

    IEnumerator Start()
    {
        corr = Start();
        dianaAmarillaDer = transform.GetChild(0).gameObject;
        dianaRojaDer = transform.GetChild(1).gameObject;
        dianaVerdeDer = transform.GetChild(2).gameObject;
        Luz = transform.GetChild(3).gameObject;

        while(true){
            int r = Random.Range(1,4);

            switch(r){
                case 1:
                    dianaAmarillaDer.SetActive(true);
                    dianaRojaDer.SetActive(false);
                    dianaVerdeDer.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.yellow;
                    activo = 1;
                    break;
                case 2:
                    dianaAmarillaDer.SetActive(false);
                    dianaRojaDer.SetActive(true);
                    dianaVerdeDer.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.red;
                    activo = 2;
                    break;
                case 3:
                    dianaAmarillaDer.SetActive(false);
                    dianaRojaDer.SetActive(false);
                    dianaVerdeDer.SetActive(true);
                    Luz.GetComponent<Light>().color = Color.green;
                    activo = 3;
                    break;
            }
            yield return new WaitForSeconds(2f);
        }
    }

    void OnTriggerEnter(Collider c) {
        if(c.tag == "FlechaAmarilla" && activo == 1){
            c.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<MovimientoDianaDerecha>().enabled = false;
            StopCoroutine(corr);
        }
        if(c.tag == "FlechaRoja" && activo == 2){
            c.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<MovimientoDianaDerecha>().enabled = false;
            StopCoroutine(corr);
        }
        if(c.tag == "FlechaVerde" && activo == 3){
            c.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<MovimientoDianaDerecha>().enabled = false;
            StopCoroutine(corr);
        }
    }
}
