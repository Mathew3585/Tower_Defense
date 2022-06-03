using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-25)]
public class Module : MonoBehaviour
{
    public static Module instance;

    private List<Tourelle> TurretList = new List<Tourelle>();
    public Canvas canvas;
    public int cost;

    void Start()
    {
        instance = this; 
    }

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

    public void AddTurret(Tourelle t)
    {
        TurretList.Add(t);
        Debug.Log(t);
    }

    public void RemoveTurret(Tourelle t)
    {
        TurretList.Remove(t);
        Debug.Log(t);
    }
    
    public void FireRate()
    {
        StartCoroutine("FireRateUp");
    }


    IEnumerator FireRateUp()
    {
        foreach (Tourelle t in TurretList)
        {
            t.FireRate++;
        }

        yield return new WaitForSeconds(10);

        foreach (Tourelle t in TurretList)
        {
            t.FireRate--;
        }
    }
}
