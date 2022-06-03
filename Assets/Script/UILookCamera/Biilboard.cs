using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biilboard : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
       cam = GameManager.instance.camera;
    }   

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward + cam.up);
    }
}
