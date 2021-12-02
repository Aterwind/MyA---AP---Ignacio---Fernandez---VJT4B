using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TChangeWeapon : MonoBehaviour
{
    [SerializeField] private int _weapon = 0;
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<ICollectible>();
        if (hit != null)
        {
            hit.ChangeWeapon(_weapon);
        }
    }
}
