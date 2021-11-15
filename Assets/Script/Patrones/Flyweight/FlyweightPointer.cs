using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    public static readonly Flyweight BulletBasicPlayer = new Flyweight
    {
        speed = 18,
    };

    public static readonly Flyweight BulletSeekPlayer = new Flyweight
    {
        speed = 22,
        distanceBackStock = 0.7f,
        timeResetCollider = 0.1f,
    };

}
