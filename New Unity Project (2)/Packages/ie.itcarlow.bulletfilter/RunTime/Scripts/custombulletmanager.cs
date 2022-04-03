using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custombulletmanager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletMoveSpeed;
    public float bulletLifeTime;
    public int MAX_BULLETS;
    public int currentBulletTotal = 0;
    public int DIRECTION = 0;
    /// <summary>
    /// Decrease the number of active bullets
    /// </summary>
    public void decreaseBullets()
    {
        if (currentBulletTotal <= 0)
        {
            currentBulletTotal = 0;
        }
        else
        {
            currentBulletTotal--;
        }
    }

    public void increaseBullets()
    {
        currentBulletTotal++;
    }

    /// <summary>
    /// Shoot a bullet in the direction Megaman is looking.
    /// -1 for Left, 1 for Right.
    /// </summary>
    public void shootBullet()
    {
      //  bulletPrefab.GetComponent<custombullet>().bulletManager = this;
        bulletPrefab.GetComponent<Bullet>().speed = bulletMoveSpeed;
        bulletPrefab.GetComponent<Bullet>().lifetime = bulletLifeTime;
        Instantiate(bulletPrefab);
    }

    public bool canFire()
    {
        return currentBulletTotal < MAX_BULLETS;
    }
}
