using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rapid_prefab;
    public float bulletMoveSpeed;
    public float bulletLifeTime;
    public int MAX_BULLETS;
    public int currentBulletTotal = 0;
    public int DIRECTION = 0;
    private const int maxRapidAmmo = 15;
    public int rapidAmmo = maxRapidAmmo;
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
        bulletPrefab.GetComponent<Bullet>().bulletManager = this;
        bulletPrefab.GetComponent<Bullet>().speed = bulletMoveSpeed;
        bulletPrefab.GetComponent<Bullet>().lifetime = bulletLifeTime;
        Instantiate(bulletPrefab);
    }
    public void shootRapid()
    {
        rapid_prefab.GetComponent<Bullet>().bulletManager = this;
        rapid_prefab.GetComponent<Bullet>().speed = bulletMoveSpeed;
        rapid_prefab.GetComponent<Bullet>().lifetime = bulletLifeTime;
        //bulletPrefab.GetComponent<Bullet>().damage = damage;
        Instantiate(rapid_prefab);
        rapidAmmo--;
        print(rapidAmmo);
    }

    public void choosenormal()
    {

        bulletMoveSpeed = 20.0f;
        bulletLifeTime = 1.5f;

    }
    public void chooseRapid()
    { 
          
       MAX_BULLETS = 2;
       bulletMoveSpeed = 40.0f;
       bulletLifeTime = 1.0f;
    }


    public bool canFire()
    {
        return currentBulletTotal < MAX_BULLETS;
    }
}
