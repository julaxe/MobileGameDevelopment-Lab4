using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Singleton */
[System.Serializable]
public class BulletFactory
{
    // step 1. private static instance
    private static BulletFactory instance = null;

    // prefab references
    public GameObject enemyBullet;
    public GameObject playerBullet;

    // game controller reference
    private GameController gameController;

    // step 2. make constructor private
    private BulletFactory()
    {
        Initialize();
    }

    // step 3. make a public static creational method for class access
    public static BulletFactory Instance()
    {
        if (instance == null)
        {
            instance = new BulletFactory();
        }

        return instance;
    }

    private void Initialize()
    {
        // step 4. Create a Resources folder
        // step 5. Move our Bullet prefabs into a new Resources/Prefabs folder
        
        enemyBullet = Resources.Load("Prefabs/EnemyBullet") as GameObject;
        playerBullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;

        gameController = GameObject.FindObjectOfType<GameController>();
    }

    public GameObject createBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch (type)
        {
            case BulletType.ENEMY:
                temp_bullet = MonoBehaviour.Instantiate(enemyBullet);
                break;
            case BulletType.PLAYER:
                temp_bullet = MonoBehaviour.Instantiate(playerBullet);
                break;
        }

        temp_bullet.transform.parent = gameController.gameObject.transform;
        temp_bullet.SetActive(false);

        return temp_bullet;
    }
}
