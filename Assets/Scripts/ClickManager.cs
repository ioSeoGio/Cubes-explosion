using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private List<IClickHandler> _handlers;

    private void Awake()
    {
        _handlers = GetComponents<IClickHandler>().ToList();
    }

    private void OnMouseDown()
    {
        foreach (var handler in _handlers)
        {
            handler.HandleClick();
        }
    }
}