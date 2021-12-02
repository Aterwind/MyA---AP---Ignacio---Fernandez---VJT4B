using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TReceiveHP : MonoBehaviour
{
    [SerializeField] private int _hp = 0;
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IReceiveHP>();
        if (hit != null)
        {
            hit.ReceiveHP(_hp);
        }
    }
}
