using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Fontions
    public float panSpeed = 30f;


    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime);
        }
    }
}
