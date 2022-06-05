using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiilboardTuto : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
       cam = GameManagerTuto.instance.camera;
    }   

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward + cam.up);
    }
}
