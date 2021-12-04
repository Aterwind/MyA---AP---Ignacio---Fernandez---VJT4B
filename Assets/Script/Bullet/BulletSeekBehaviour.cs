using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSeekBehaviour : UnitBullet
{
    [SerializeField] private CapsuleCollider _targetCollider = null;
    [SerializeField] private float _radiusCollider = 0;

    private Vector3 _steering = Vector3.zero;
    private Vector3 _desired = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private List<GameObject> _listTarget = new List<GameObject>();
    private Vector3 _targetSave = Vector3.zero;

    void Start()
    {
        _targetCollider.radius = _radiusCollider;
        _strategy[0] = new BulletBasicAdvance(FlyweightPointer.BulletBasicPlayer.speed, _transform);
        _strategy[1] = new BulletSeekAdvance(FlyweightPointer.BulletSeekPlayer.speed, _transform ,_targetCollider, _listTarget, FlyweightPointer.BulletSeekPlayer.timeResetCollider,
            FlyweightPointer.BulletSeekPlayer.distanceBackStock, _steering, _desired, _velocity, _targetSave, this, BackStock);
        _currentStrategy = _strategy[1];
    }

    void Update()
    {
        if (_currentStrategy != null)
            _currentStrategy.BulletAdvance();

        if(_listTarget.Count >= 1)
            _currentStrategy = _strategy[1];
        else
            _currentStrategy = _strategy[0];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (_listTarget.Count < 1)
            _listTarget.Add(other.gameObject);
    }

    public void OnTriggerExit(Collider other)
    {
        _listTarget.Remove(other.gameObject);
        _targetCollider.radius = 0;

        StartCoroutine(resetCollider());

    }

    IEnumerator resetCollider()
    {
        yield return new WaitForSeconds(FlyweightPointer.BulletSeekPlayer.timeResetCollider);
        _targetCollider.radius = _radiusCollider;
    }

}
