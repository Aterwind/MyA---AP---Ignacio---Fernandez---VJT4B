using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyController : MonoBehaviour
{
    public float radius = 0;

    public delegate void DragStick(Vector3 stickValue);
    public event DragStick OnDragStick;

    public delegate void EndStick(Vector3 stickValue);
    public event EndStick OnEndDragStick;

    private Vector3 _originalPosition;
    private Vector3 _stickValue;

    public void Start()
    {
        _originalPosition = transform.position;
    }

    public void OnDrag()
    {
        _stickValue = Vector3.ClampMagnitude(Input.mousePosition - _originalPosition, radius);
        transform.position = _stickValue + _originalPosition;

        if (OnDragStick != null)
            OnDragStick(_stickValue);
    }

    public void OnEndDrag()
    {
        transform.position = _originalPosition;
        _stickValue = Vector3.zero;

        if (OnEndDragStick != null)
            OnEndDragStick(_stickValue);
    }
}


