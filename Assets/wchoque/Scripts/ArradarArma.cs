using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArradarArma : MonoBehaviour
{
    public GameObject[] spriteBalas;
  //  public Image modeloBala;

    //public List<Image> imgBalas;
    public Transform pivotBala;
     public GameObject balaPrefab;
    public GameObject balaInstanciado;
   public  int cantidadMuniciones =10;
   // public CuadroTiempo cuadroTiempo;
    public Arma armaMano;
    const float limite_Agarre=0.7f;
    const float limite_Soltar=0.3f;
    [Range(0,1)]
    public float agarre;
    bool cambio;
    public bool estaAgarrando;
    float actual;
  //  public Bala bala;
    // Start is called before the first frame update
    void Start()
    {
        estaAgarrando =false;
        spriteBalas = GameObject.FindGameObjectsWithTag("SpriteMunicion");
    }

    // Update is called once per frame
    void Update()
    {   


        cambio = UpdateNivelAgarre();
      // cambio = true;
        if(estaAgarrando&& armaMano!=null && cambio){
            armaMano.Agarrar(transform);
            if(balaInstanciado==null){
                crearBala(pivotBala);
            }
        }
        if(!estaAgarrando&& cambio && armaMano!=null){
            armaMano.soltar();
        }
        
         if(armaMano!=null){
            //OVRInput.Button.PrimaryIndexTrigger
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch) && balaInstanciado!=null && estaAgarrando==true){
                //if(Input.GetKeyDown(KeyCode.T) && balaInstanciado!=null && estaAgarrando==true){
                    Debug.Log("Dispara");
                    balaInstanciado.GetComponent<Bala>().dispararBala();
                    cantidadMuniciones-=1;
                    GenerarSpriteBalas();
                    balaInstanciado=null;
                    if(balaInstanciado==null){
                        crearBala(pivotBala);
                    }
                    
            }
            //Index trigger para disparar
        }
    }
    bool UpdateNivelAgarre(){
        actual = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,OVRInput.Controller.RTouch);
        bool limiteTraspasado=false;
        if(agarre<limite_Agarre && actual>=limite_Agarre){
            estaAgarrando=true;
            limiteTraspasado =true;
        }
        if(agarre>limite_Soltar && actual<=limite_Soltar){
        estaAgarrando=false;
        limiteTraspasado =true;
        }
    agarre = actual;
    return limiteTraspasado;
    }
    
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arma"){
            Arma armaV = other.GetComponent<Arma>();
            if(armaV!=null){
                armaMano = armaV;
                armaMano.Tocar(); 
            }
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
         if(other.tag == "Arma"){
            Arma armaV = other.GetComponent<Arma>();
            if(armaV!=null){
                armaMano = armaV;
                armaMano.DegarTocar();
                armaMano=null; 
            }
        }
    }
      void crearBala(Transform pivot){
        if(cantidadMuniciones>0){
            balaInstanciado = Instantiate(balaPrefab);
            balaInstanciado.transform.parent = pivot;
            balaInstanciado.transform.localPosition = Vector3.zero;
            balaInstanciado.transform.localRotation = Quaternion.identity; 
        }
      
    }
   public  void GenerarSpriteBalas(){
        foreach(GameObject g in spriteBalas){
            g.SetActive(false);
        }
        for(int i=0;i<cantidadMuniciones;i++)  {
         
            spriteBalas[i].SetActive(true);
         
        }
        
    }
}
