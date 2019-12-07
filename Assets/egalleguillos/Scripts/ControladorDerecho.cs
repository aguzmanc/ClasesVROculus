using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDerecho : MonoBehaviour
{
    GameObject dianaRojaDer;
    GameObject dianaVerdeDer;
    GameObject dianaAmarillaDer;
    GameObject Luz;

    float timer;

    IEnumerator Start()
    {
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
                    break;
                case 2:
                    dianaAmarillaDer.SetActive(false);
                    dianaRojaDer.SetActive(true);
                    dianaVerdeDer.SetActive(false);
                    Luz.GetComponent<Light>().color = Color.red;
                    break;
                case 3:
                    dianaAmarillaDer.SetActive(false);
                    dianaRojaDer.SetActive(false);
                    dianaVerdeDer.SetActive(true);
                    Luz.GetComponent<Light>().color = Color.green;

                    break;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
