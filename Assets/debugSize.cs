using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Bounds b = new Bounds();
        foreach(Renderer r in gameObject.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }

        Debug.Log(b.center);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
