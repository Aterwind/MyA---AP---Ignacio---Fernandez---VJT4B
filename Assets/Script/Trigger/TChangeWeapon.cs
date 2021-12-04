using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TChangeWeapon : UnitColletable
{
    [SerializeField] private int _type = 0;
    private void Update()
    {
        transform.position += transform.forward * FlyweightPointer.Collectable.speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<ICollectible>();
        if (hit != null)
        {
            hit.ChangeWeapon(_type);
            Return();
        }
        else if (other.gameObject.CompareTag("Bounds"))
        {
            Return();
        }
    }

    void Return()
    {
        backStock(this);
    }
}
