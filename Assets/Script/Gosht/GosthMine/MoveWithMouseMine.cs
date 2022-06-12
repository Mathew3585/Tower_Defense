using UnityEngine;
using System.Collections;

public class MoveWithMouseMine : MonoBehaviour
{

    public Transform target;
    public float speed;
    Camera cam;
    public LayerMask mask;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    void Update()
    {
        Debug.Log(target);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.green);


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            target = hit.transform;
            Debug.Log(target);
            Vector3 a = gameObject.transform.position;
            Vector3 b = target.position;
            gameObject.transform.position = Vector3.Lerp(a, b, speed);

        }
        else
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
            target = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}