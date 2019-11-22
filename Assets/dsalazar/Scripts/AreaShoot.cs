using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        distancia=0;
    }
  public bool manoArea1=false;
    public bool manoArea2=false;
    public bool manoArea3=false;
    public GameObject mano2;
    public float distancia;
    // Update is called once per frame
    void Update()
    {
      float distancia=  Vector3.Distance(transform.position, mano2.transform.position);

    }
    private void OnTriggerStay(Collider other) {
       // if (other.gameObject.name=="area1")
        //    manoArea1=true;
        //}
       //else if (other.gameObject.name=="area2")
        //{
          //  manoArea2=true;
        //}
       // else if (other.gameObject.name=="area3")
        //{
         //   manoArea3=true;
        //}
        //else
        //{
          //  manoArea1=false;
           // manoArea2=false;
           // manoArea3=false;
        //}
          if (other.gameObject.name=="area1"){ 
           manoArea1=true;
        }
        else
        {
            manoArea1=false;
        }

    }
}
