using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module : MonoBehaviour
{
    public List<GameObject> TurretList = new List<GameObject>();
    public Canvas canvas;
    public int cost;
    // Update is called once per frame
    void MouseUpdate()  
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100f) )
            {
                if(hit.transform.tag == "Module")
                {
                    GetBuildPosition();
                    OnMouseDown();
                }
                else if (hit.collider.CompareTag("Ground"))
                {
                    Debug.Log("Close");
                }
            }


        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.tag == "Module")
        {
            Debug.Log("click sur le module");
            canvas.gameObject.SetActive(true);
            Debug.Log("canvas ok");
        }else
        {
            Debug.Log("canvas off");
            canvas.gameObject.SetActive(false);
        }
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    void Update()
    {
        foreach (GameObject TurretObj in GameObject.FindGameObjectsWithTag("Turret"))
        {

            TurretList.Add(TurretObj);
        }
    }
}
