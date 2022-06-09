using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGoshtMine : MonoBehaviour
{
    private Action callback;

    public void Setup(Action cb)
    {
        callback = cb;
    }

    private void OnMouseExit()
    {
        callback?.Invoke();
        callback = null;
    }
}
