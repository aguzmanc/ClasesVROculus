using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Huerfano : MonoBehaviour {
    void Start () {
        transform.parent = null;
    }
}
