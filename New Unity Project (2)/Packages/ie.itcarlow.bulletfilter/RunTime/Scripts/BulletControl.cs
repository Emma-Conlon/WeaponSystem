using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public  Bullet bullet;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    Vector2 bulletPos;
    public int DIRECTION = 1;
    public GameObject player;
    public GameObject Bullet;

    public void fire()
    {
        if(DIRECTION == -1) // LEFT
        {
            bulletPos += new Vector2(-0.5f, -0.43f);
        }
        else // RIGHT
        {
            bulletPos += new Vector2(+0.5f, -0.43f);
        }
    }

    public void setDirection(int direction)
    {
        DIRECTION = direction;
    }

    public int getDirection()
    {
        return DIRECTION;
    }

    public GameObject GetBullet()
    {
        return Bullet;
    }
}
