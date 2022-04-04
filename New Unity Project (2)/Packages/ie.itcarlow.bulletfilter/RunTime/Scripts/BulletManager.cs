using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject custom_prefab;
    public GameObject rapid_prefab;
    public custom c;
    public float bulletMoveSpeed;
    public float bulletLifeTime;
    public float MAX_BULLETS;
    public int currentBulletTotal = 0;
    public int DIRECTION = 0;
    private const int maxRapidAmmo = 15;
    public float rapidAmmo = maxRapidAmmo;
    public Text text;
    public Text tex;
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
    public void shootCustom()
    {
        custom_prefab.GetComponent<Bullet>().bulletManager = this;
        custom_prefab.GetComponent<Bullet>().speed = bulletMoveSpeed;
        custom_prefab.GetComponent<Bullet>().lifetime = bulletLifeTime;
        //bulletPrefab.GetComponent<Bullet>().damage = damage;
        Instantiate(custom_prefab);
        rapidAmmo--;
        print(rapidAmmo);
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
        text.text = "Damage:" + 1;
        tex.text = "Damage:" + 1;
    }
    public void chooseRapid()
    { 
          
       MAX_BULLETS = 2;
       bulletMoveSpeed = 40.0f;
       bulletLifeTime = 1.0f;

        text.text = "Damage:" + 3;
        tex.text = "Damage:" + 1;
    }
    public void chooseCustom()
    {

        bulletMoveSpeed = c.time_sp.value;
        print("cust" + bulletMoveSpeed);
        bulletLifeTime = c.time_l.value;
        MAX_BULLETS = c.time_b.value;
        text.text = "Damage:" + c.time_b.value;
        tex.text = "Damage:" + c.time_b.value;
    }
    public void chooseC()
    {
        bulletMoveSpeed = c.time_sp.value;
        print("cust" + bulletMoveSpeed);
        bulletLifeTime = c.time_l.value;
        MAX_BULLETS = c.time_b.value;
        rapidAmmo = c.time_a.value;
       
      
}
    public void chooseR()
    {
        MAX_BULLETS = 2;
        bulletMoveSpeed = 40.0f;
        bulletLifeTime = 1.0f;
        rapidAmmo = 15;
    }
    public bool canFire()
    {
        return currentBulletTotal < MAX_BULLETS;
    }
}
