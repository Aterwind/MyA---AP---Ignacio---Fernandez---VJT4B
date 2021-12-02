using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<StrucWeapons> weapons = new List<StrucWeapons>();
    Dictionary<Type, UnitWeapon> _weaponsDictionary = new Dictionary<Type, UnitWeapon>();

    public UnitWeapon GetWeapon(Type type)
    {
        if (_weaponsDictionary.ContainsKey(type))
            return _weaponsDictionary[type]; 
        else
            _weaponsDictionary.Add(type, weapons[(int)type].prefab); return _weaponsDictionary[type];
    }
}

[System.Serializable]
public struct StrucWeapons
{
    public UnitWeapon prefab;
    public Type type;
}

public enum Type
{
    WeaponBasic,
    WeaponSeek,
    WeaponTriple,
    WeaponSpiral,
    WeaponStart
}
