using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform myTransform = null;
    public UnitEnemies enemies = null;
    public int stock = 0;
    public TypeSpawn type;
    private int _maxRandomListEnemy = 0;

    [SerializeField] private float waveRate = 2;
    private float waveSum = 1;
    private float nextWaveTime = 2;

    [SerializeField] private float _distance = 0;
    [SerializeField] private float _startAngle = 0;
    [SerializeField] private float endAngle = 0;
    [SerializeField] private float radius = 0;
    [SerializeField] private float division = 0;
    private float angleStep = 0;
    private float angle = 0;
    [SerializeField] private int initialPosX = 0, initialPosY;

    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitEnemies> pool = null;
    
    IPatronAdvance _currenStrategy = null;
    IPatronAdvance[] _strategy = new IPatronAdvance[2];

    private void Awake()
    {
        _maxRandomListEnemy = spawnList.Count;
        _strategy[(int)TypeSpawn.One] = new PatronEnemyOne(myTransform,stock, _distance, _startAngle, endAngle, radius, division, angleStep,
            angle, _maxRandomListEnemy, enemies, spawnList, pool);

        _strategy[(int)TypeSpawn.Two] = new PatronEnemyTwo(myTransform, initialPosX, initialPosY, stock, _distance, _maxRandomListEnemy, 
            enemies, spawnList, pool);

        _currenStrategy = _strategy[(int)(TypeSpawn)type];
    }

    private void Start()
    {
        _currenStrategy.OnStart();
    }

    private void Update()
    {
       /*
        if(Time.time >= nextWaveTime)
        {
            _currenStrategy.PatronAdvance();
            nextWaveTime = Time.time + waveSum / waveRate ;
        }
        */

        if (Input.GetKeyDown(KeyCode.P))
        {
            _currenStrategy.PatronAdvance();
        }
    }
}

public enum TypeSpawn
{
    One,
    Two
}
