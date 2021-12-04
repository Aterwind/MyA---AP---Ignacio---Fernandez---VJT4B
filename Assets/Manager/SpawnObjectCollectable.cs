using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectCollectable : MonoBehaviour
{
    public List <UnitColletable> typeObject = new List<UnitColletable>();
    public int stock = 0;
    [SerializeField] private float waveTime = 0;
    private float _nextDropTime = 0;

    private int _limitList = 0;
    private int _randomList = 0;
    private int _maxRandomList = 0;

    public List<GameObject> spawnList = new List<GameObject>();
    ObjectPool<UnitColletable> poolType = null;

    private void Start()
    {
        _limitList = typeObject.Count;
        _maxRandomList = spawnList.Count;

        EventManager.Subscribe("SpawnObject", Spawn);
        poolType = new ObjectPool<UnitColletable>(CollectableReturn, typeObject[_randomList].TurnOn, typeObject[_randomList].TurnOff, stock);
    }

    public void Spawn(object[] parameters)
    {
        typeObject[_randomList] = poolType.GetObject();
        int spawnRandomList = Random.Range(0, _maxRandomList);

        typeObject[_randomList].transform.position = spawnList[spawnRandomList].transform.position;
        typeObject[_randomList].transform.forward = spawnList[spawnRandomList].transform.forward;
        typeObject[_randomList].backStock = poolType.ReturnObject;
    }

    public UnitColletable CollectableReturn()
    {
        _randomList = Random.Range(0, _limitList);
        return Instantiate(typeObject[_randomList]);
    }
}
