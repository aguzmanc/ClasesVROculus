using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoQuieto : MonoBehaviour
{
    public Enemigos enemigos;
    public float tiempoDuracion;
    // Start is called before the first frame update
    void Start()
    {
        tiempoDuracion = 0;
        enemigos = GameObject.FindWithTag("pivotBala").GetComponent<Enemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDuracion += Time.deltaTime;
        if(tiempoDuracion>4){
            enemigos.posicionesEnemigos.Add(transform.parent.transform);
            tiempoDuracion =0;
            Destroy(transform.gameObject);

        }
    }
}
