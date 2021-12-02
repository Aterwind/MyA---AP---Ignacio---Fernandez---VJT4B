using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : UnitEnemies, IDamageable
{
    private ModelBasicEnemy _model = null;
    private ControllerBasicEnemy _controller = null;
    private ViewBasicEnemy _view = null;

    private IEnemyAdvance _currentStrategy = null;
    private IEnemyAdvance[] _strategy = new IEnemyAdvance[2];

    private void Awake()
    {
        _model = new ModelBasicEnemy(_hp, _maxHp, _myTransform, _currentStrategy, _strategy);
        _controller = new ControllerBasicEnemy(_model);
    }
    private void Start()
    {
        _model.OnStart();
    }
    void Update()
    {
        _controller.OnUpdate();
    }
    public void TakeDamage(float dmg)
    {
        throw new System.NotImplementedException();
    }
}
