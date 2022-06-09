using UnityEngine;
using System.Collections;

public class MoveWithMouse : MonoBehaviour
{

    public Transform target;
    public float speed;
    Camera cam;
    public bool collions;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    void Update()
    {
        if (collions)
        {
            Vector3 a = transform.position;
            Vector3 b = target.position;
            transform.position = Vector3.Lerp(a, b, speed);
            Debug.Log(target.position);
            Debug.Log(transform.position);
        }
        else if (!collions)
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        }


        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision ok");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Node")
        {
            Debug.Log("Collision tag ok");
            collions = true;
            NodeGosht nodegosht = collision.gameObject.GetComponent<NodeGosht>();
            nodegosht.Setup(() => collions = false);
        }
    }
}