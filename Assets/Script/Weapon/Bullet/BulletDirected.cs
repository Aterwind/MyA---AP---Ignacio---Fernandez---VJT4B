using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirected : UnitBullet
{
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        BackStock.Invoke(this);
    }
}
