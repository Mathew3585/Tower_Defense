using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGosht : MonoBehaviour
{
    private Action callback;

    public void Setup(Action cb)
    {
        callback = cb;
    }

    private void OnMouseExit()
    {
        Debug.Log("Souris sortie");
        callback?.Invoke();
        callback = null;
        Debug.Log(callback);
    }
}
