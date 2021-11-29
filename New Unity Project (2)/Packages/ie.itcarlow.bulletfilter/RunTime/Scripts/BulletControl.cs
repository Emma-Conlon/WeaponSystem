using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public  Bullet bullet;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    Vector2 bulletPos;
    public float DIRECTION = 1;
    public GameObject player;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("IM IN ");    
    }
    public GameObject GetBullet()
    {
        return Bullet;
    }
    // Update is called once per frame
    private void Update()
    {
       
    }

    public void fire()
    {
        
        if(DIRECTION == -1)
        {
            bulletPos += new Vector2(-1f, -0.43f);
       
          
        }
        if (DIRECTION == 1)
        {
            bulletPos += new Vector2(+1f, -0.43f);
         
        }

    }
   
}
