using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float ira = 0;

    public bool gameOver = false;

    public Slider barraIra;
    public Text cronometro;

    private float StartTime;
     void Start () 
     {
         StartTime = Time.time;
     }
     void Update(){
         if (!gameOver)
         {
             float TimerControl = Time.time - StartTime;
            string mins = ((int)TimerControl/60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");
            string milisegs = ((TimerControl * 100)%100).ToString ("00");
                
            string TimerString = string.Format ("{00}:{01}:{02}", mins, segs, milisegs);

            cronometro.text=TimerString;
            
         }
         else
         {
             Time.timeScale=0;
         }
     }


    public void AddIra(float value)
    {
        ira += value;
        if (ira>=barraIra.maxValue)
        {
            SetText("Ganaste");
            Time.timeScale=0;
        }
        barraIra.value=ira;
    }

    public void SetText(string text)
    {
        cronometro.text=text;
    }
}
