using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCentro : MonoBehaviour
{
    GameObject dianaRojaCen;
    GameObject dianaVerdeCen;
    GameObject dianaAmarillaCen;
    GameObject Luz;
    IEnumerator corr;
    public int activo = 0;
    IEnumerator Start()
    {
        corr = Start();
        dianaAmarillaCen = transform.GetChild(0).gameObject;
        dianaRojaCen = transform.GetChild(1).gameObject;
        dianaVerdeCen = transform.GetChild(2).gameObject;
        Luz = transform.GetChild(3).gameObject;

        while(true){
            int r = Random.Range(1,4);

            switch(r){
                case 1:
                    dianaAmarillaCen.SetActive(true);
                    dianaRojaCen.SetActive(false);
                    dianaVerdeCen.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.yellow;
                    activo = 1;
                    break;
                case 2:
                    dianaAmarillaCen.SetActive(false);
                    dianaRojaCen.SetActive(true);
                    dianaVerdeCen.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.red;
                    activo = 2;
                    break;
                case 3:
                    dianaAmarillaCen.SetActive(false);
                    dianaRojaCen.SetActive(false);
                    dianaVerdeCen.SetActive(true);
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
            this.GetComponent<MovimientoDianaCentro>().enabled = false;
            StopCoroutine(corr);
        }
        if(c.tag == "FlechaRoja" && activo == 2){
            c.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<MovimientoDianaCentro>().enabled = false;
            StopCoroutine(corr);
        }
        if(c.tag == "FlechaVerde" && activo == 3){
            c.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<MovimientoDianaCentro>().enabled = false;
            StopCoroutine(corr);
        }
    }
}