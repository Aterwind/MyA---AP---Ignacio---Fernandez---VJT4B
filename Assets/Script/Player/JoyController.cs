using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image imgStickBg = null;
    [SerializeField] private Image imgStick = null;

    public float radius = 0;
    public float divideImageStick = 0;

    private Vector3 _originalPosition;
    private Vector3 _stickValue;

    public delegate void DragStick(float x, float y);
    public DragStick OnDragStick;

    public delegate void EndStick(float x, float y);
    public EndStick OnEndDragStick;

    public void Start()
    {
        _originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _stickValue = Vector3.ClampMagnitude((Vector3)eventData.position - _originalPosition, radius);
        transform.position = _stickValue + _originalPosition;

        _stickValue.x = _stickValue.x / (imgStickBg.rectTransform.sizeDelta.x / divideImageStick);
        _stickValue.y = _stickValue.y / (imgStickBg.rectTransform.sizeDelta.y / divideImageStick);
        
        imgStick.rectTransform.anchoredPosition = new Vector3(
            _stickValue.x * (imgStickBg.rectTransform.sizeDelta.x / divideImageStick), 
            _stickValue.y * (imgStickBg.rectTransform.sizeDelta.y / divideImageStick), _stickValue.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _originalPosition;
        _stickValue = Vector3.zero;

    }

    public float InputHorizontal()
    {
        if(_stickValue.x != 0)
            return _stickValue.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float InputVertical()
    {
        if (_stickValue.y != 0)
            return _stickValue.y;
        else
            return Input.GetAxis("Vertical");
    }
}


