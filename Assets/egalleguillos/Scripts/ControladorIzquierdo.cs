using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIzquierdo : MonoBehaviour
{
    GameObject dianaRojaIzq;
    GameObject dianaVerdeIzq;
    GameObject dianaAmarillaIzq;
    GameObject Luz;

    float timer;
    public int activo;

    IEnumerator Start()
    {
        dianaAmarillaIzq = transform.GetChild(0).gameObject;
        dianaRojaIzq = transform.GetChild(1).gameObject;
        dianaVerdeIzq = transform.GetChild(2).gameObject;
        Luz = transform.GetChild(3).gameObject;

        while(true){
            int r = Random.Range(1,4);

            switch(r){
                case 1:
                    dianaAmarillaIzq.SetActive(true);
                    dianaRojaIzq.SetActive(false);
                    dianaVerdeIzq.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.yellow;
                    activo = 0;
                    break;
                case 2:
                    dianaAmarillaIzq.SetActive(false);
                    dianaRojaIzq.SetActive(true);
                    dianaVerdeIzq.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.red;
                    activo = 1;
                    break;
                case 3:
                    dianaAmarillaIzq.SetActive(false);
                    dianaRojaIzq.SetActive(false);
                    dianaVerdeIzq.SetActive(true);
                    Luz.GetComponent<Light>().color = Color.green;
                    activo = 3;
                    break;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
