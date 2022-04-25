using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Script : MonoBehaviour
{
    //Liste de Waypoint
    public Transform[] point;


    //Mettre dans la liste tout les Waypoint enfant de Waypoints
    void Awake()
    {
        point = new Transform[transform.childCount];
        for (int i = 0; i < point.Length; i++)
        {
            point[i] = transform.GetChild(i);
        }
    }

}
