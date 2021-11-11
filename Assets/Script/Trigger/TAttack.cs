using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(_damage);
        }

    }
}
