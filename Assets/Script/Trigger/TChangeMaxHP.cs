using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TChangeMaxHP : MonoBehaviour
{
    [SerializeField] private int _maxHp = 0;
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IReceiveHP>();
        if (hit != null)
        {
            hit.ChangeMaxHp(_maxHp);
        }
    }
}
