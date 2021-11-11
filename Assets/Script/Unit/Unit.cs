using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected float _maxHp = 0;
    [SerializeField] protected float _speed = 0;
    protected float _hp = 0;

    [SerializeField] protected JoyController _myStick = null;
    protected Model _model = null;
    protected Controller _controller = null;
    protected View _view = null;

    public void TakeDamage(float dmg)
    {
        _model.TakeDamage(dmg);
    }

    public void ReceiveHP(float hp)
    {
        _model.ReceiveHP(hp);
    }
}
