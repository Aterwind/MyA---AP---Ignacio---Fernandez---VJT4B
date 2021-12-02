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

    public static readonly Flyweight BulletSphere = new Flyweight
    {
        speed = 5,
    };

    public static readonly Flyweight EnemySeek = new Flyweight
    {
        speed = 8,
        timeResetCollider = 3,
        enemyTypeScore = 50,
        player = 8,
        bullets = 9,
        bounds = 12,
    };

    public static readonly Flyweight EnemyBasic = new Flyweight
    {
        speed = 6,
        enemyTypeScore = 25,
        player = 8,
        bullets = 9,
        bounds = 12,

    };

}
