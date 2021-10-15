using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : BulletBehaviour, Bullet
{
    void Start()
    {
        type = BulletType.ENEMY;

        bulletVelocity = new Vector3(0.0f, -0.1f, 0.0f);
    }

    public int DealDamage()
    {
        return 10;
    }
}
