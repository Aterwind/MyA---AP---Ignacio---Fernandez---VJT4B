using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TReceiveHP : UnitColletable
{
    [SerializeField] private int _type = 0;
    private void Update()
    {
        transform.position += transform.forward * FlyweightPointer.Collectable.speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IReceiveHP>();
        if (hit != null)
        {
            hit.ReceiveHP(_type);
            backStock(this);
        }
    }
}
