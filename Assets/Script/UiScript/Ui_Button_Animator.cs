using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Button_Animator : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private string NameAnimator;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger(NameAnimator);
        }
    }
}
