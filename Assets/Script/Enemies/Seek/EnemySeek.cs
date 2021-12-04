using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : UnitEnemies
{
    private IEnemyAdvance _currentStrategy = null;
    private IEnemyAdvance[] _strategy = new IEnemyAdvance[2];

    [SerializeField] private CapsuleCollider _targetCollider = null;
    [SerializeField] private int _indexState = 0;

    private Vector3 _steering = Vector3.zero;
    private Vector3 _desired = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private List<GameObject> _listTarget = new List<GameObject>();
    private Vector3 _targetSave = Vector3.zero;

    [SerializeField] private float viewRadius = 0;
    [SerializeField] private LayerMask targetMask = 0;

    private void Start()
    {
        _strategy[0] = new EnemyBasicAdvance(_myTransform);
        _strategy[1] = new EnemySeekAdvance(_myTransform, _targetCollider, _listTarget, _steering, _desired, _velocity, _targetSave, this, backStock);
        _currentStrategy = _strategy[_indexState];
    }
    private void Update()
    {
        RadiusTargets();

        if (_currentStrategy != null)
            _currentStrategy.EnemyAdvance();

        if (_listTarget.Count >= 1)
            _currentStrategy = _strategy[1];
        else
            _currentStrategy = _strategy[0];
    }

    public void RadiusTargets()
    {
        Collider[] playerTar = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        foreach (var item in playerTar)
        {
            if(_listTarget.Count < 1)
            _listTarget.Add(item.gameObject);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        var hitPlayer = other.gameObject.GetComponent<PlayerBehoviour>();
        if (hitPlayer != null && _listTarget.Count < 1)
        {
            _listTarget.Add(hitPlayer.gameObject);
            viewRadius = 0;
            StartCoroutine(ResetCollider());
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            backStock.Invoke(this);
            _listTarget.Clear();
            EventManager.Trigger("UpdateUIScore", FlyweightPointer.EnemySeek.enemyTypeScore);
        }

        if (other.gameObject.CompareTag("Bounds"))
        {
            _listTarget.Clear();
            backStock.Invoke(this);
        }
    }

    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(FlyweightPointer.EnemySeek.timeResetCollider);
        _listTarget.Remove(_listTarget[0].gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }

}
