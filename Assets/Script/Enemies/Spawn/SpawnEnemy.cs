using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Tipo y cantidad de enemigos")]
    public Transform myTransform = null;
    public UnitEnemies enemies = null;
    public int stock = 0;
    public TypeSpawn type;
    private int _maxRandomListEnemy = 0;

    [Header("Rate de Oleadas")]
    private float nextWaveTime = 2;

    [Header("Variables para los patrones")]
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _startAngle = 0;
    [SerializeField] private float endAngle = 0;
    [SerializeField] private float radius = 0;
    [SerializeField] private float division = 0;
    private float angleStep = 0;
    private float angle = 0;
    [SerializeField] private int initialPosX = 0;
    [SerializeField] private int initialPosY = 0;

    [Header("Lista de spawn")]
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
        if(Time.time >= nextWaveTime)
        {
            _currenStrategy.PatronAdvance();
            nextWaveTime = Time.time + FlyweightPointer.Wave.timeWave;
        }
    }
}

public enum TypeSpawn
{
    One,
    Two
}
