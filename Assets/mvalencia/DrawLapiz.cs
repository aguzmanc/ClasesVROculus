using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLapiz : MonoBehaviour
{
    public GameObject line;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public Transform leftPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreteLinea()
    {
        currentLine = Instantiate(line, transform.position, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, leftPosition.position);
        lineRenderer.SetPosition(1, leftPosition.position);
    }
}
