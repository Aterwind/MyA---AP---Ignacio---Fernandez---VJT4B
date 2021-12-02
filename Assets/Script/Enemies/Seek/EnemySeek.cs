using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeek : UnitEnemies
{
    private ModelEnemySeek _model = null;
    private ControllerEnemySeek _controller = null;
    private ViewEnemySeek _view = null;

    private IEnemyAdvance _currentStrategy = null;
    private IEnemyAdvance[] _strategy = new IEnemyAdvance[2];

    [SerializeField] private CapsuleCollider _targetCollider = null;
    [SerializeField] private int _indexState = 0;

    private Vector3 _steering = Vector3.zero;
    private Vector3 _desired = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private List<GameObject> _listTarget = new List<GameObject>();
    private Vector3 _targetSave = Vector3.zero;

    private void Awake()
    {
        _model = new ModelEnemySeek(_hp, _maxHp, _indexState, _myTransform, _currentStrategy, _strategy, 
            _targetCollider, _steering, _desired, _velocity,_targetSave, _listTarget);
        _controller = new ControllerEnemySeek(_model);
    }
    private void Start()
    {
        _model.OnStart();
    }
    private void Update()
    {
        _controller.OnUpdate();
    }

    public void OnTriggerEnter(Collider other)
    {
        var hitPlayer = other.gameObject.GetComponent<PlayerBehoviour>();
        if (hitPlayer != null && _listTarget.Count < 1)
        {
            _listTarget.Add(hitPlayer.gameObject); _targetCollider.radius = 0;
            StartCoroutine(ResetCollider());
        }
    }

    IEnumerator ResetCollider()
    {
        yield return new WaitForSeconds(FlyweightPointer.EnemySeek.timeResetCollider);
        _listTarget.Remove(_listTarget[0].gameObject);
    }
}
