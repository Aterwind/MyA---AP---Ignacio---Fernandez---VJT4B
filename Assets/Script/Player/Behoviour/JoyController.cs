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

    private bool onTouch = false;
    private Vector3 _originalPositionStick;
    private Vector3 _stickValue;

    public delegate void DragStick(float x, float y);
    public DragStick OnDragStick;

    public delegate void EndStick(float x, float y);
    public EndStick OnEndDragStick;


    public void Start()
    {
        _originalPositionStick = imgStick.transform.position;
    }

    //------------------------------------------------------------------------------------------------------------------------------------//
    // Stick
    //------------------------------------------------------------------------------------------------------------------------------------//

    public void OnDrag(PointerEventData eventData)
    {
        _stickValue = Vector3.ClampMagnitude((Vector3)eventData.position - _originalPositionStick, radius);

        _stickValue.x /=(imgStickBg.rectTransform.sizeDelta.x / divideImageStick);
        _stickValue.y /=(imgStickBg.rectTransform.sizeDelta.y / divideImageStick);
        
        imgStick.rectTransform.anchoredPosition = new Vector3(
            _stickValue.x * (imgStickBg.rectTransform.sizeDelta.x / divideImageStick), 
            _stickValue.y * (imgStickBg.rectTransform.sizeDelta.y / divideImageStick), _stickValue.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        imgStick.transform.position = _originalPositionStick;
        
        if (OnEndDragStick != null)
        {
            _stickValue = Vector3.zero;
        }
    }

    public float InputHorizontal(float x)
    {
        if(_stickValue.x != 0)
            return _stickValue.x;
        else
            return x;
    }

    public float InputVertical(float y)
    {
        if (_stickValue.y != 0)
            return _stickValue.y;
        else
            return y;
    }

    //------------------------------------------------------------------------------------------------------------------------------------//
    // Button Attack
    //------------------------------------------------------------------------------------------------------------------------------------//

    public void ShootButton()
    {
        onTouch = true;
        InputShoot(onTouch);
    }

    public void ExitShootButton()
    {
        onTouch = false;
        InputShoot(onTouch);
    }

    public bool InputShoot(bool a)
    {
        if(onTouch != false)
            return onTouch;
        else
            return false;
    }
}


