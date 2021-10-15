using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Singleton */
[System.Serializable]
public class BulletManager
{
    // step 1. create a private static instance
    private static BulletManager instance = null;

    // step 2. make our default constructor private
    private BulletManager()
    {
        Initialize();
    }

    // step 3. make a public static creational method for class access
    public static BulletManager Instance()
    {
        if(instance == null)
        {
            instance = new BulletManager();
        }

        return instance;
    }

    public List<Queue<GameObject>> bulletPools;

    // Start is called before the first frame update
    private void Initialize()
    {
        bulletPools = new List<Queue<GameObject>>();

        // create a number of Queue Collections based on the number of bullet types
        for (int count = 0; count < (int)BulletType.NUMBER_OF_BULLET_TYPES; count++)
        {
            bulletPools.Add(new Queue<GameObject>());
        }
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = BulletFactory.Instance().createBullet(type);
        bulletPools[(int)type].Enqueue(temp_bullet);
    }

    /// <summary>
    /// This method removes a bullet prefab from the bullet pool
    /// and returns a reference to it.
    /// </summary>
    /// <param name="spawnPosition"></param>
    /// <returns></returns>
    public GameObject GetBullet(Vector2 spawnPosition, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;

        if (bulletPools[(int)type].Count < 1)
        {
            AddBullet(type);
        }

        temp_bullet = bulletPools[(int)type].Dequeue();
        temp_bullet.transform.position = spawnPosition;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    /// <summary>
    /// This method returns a bullet back into the bullet pool
    /// </summary>
    /// <param name="returnedBullet"></param>
    public void ReturnBullet(GameObject returnedBullet, BulletType type = BulletType.ENEMY)
    {
        returnedBullet.SetActive(false);
        bulletPools[(int)type].Enqueue(returnedBullet);
    }
}
