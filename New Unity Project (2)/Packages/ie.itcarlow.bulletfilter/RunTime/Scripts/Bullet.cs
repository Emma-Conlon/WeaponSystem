using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletManager bulletManager;
    public float bulletDirection;
    public float speed;
    public float lifetime;
   
    // Update is called once per frame

    void Start()
    {
        StartCoroutine("livingTime");
        bulletDirection = 1;
        bulletManager.increaseBullets();
        if (bulletManager.DIRECTION == -1)
        {
            transform.position = new Vector3(transform.position.x - 1.25f, transform.position.y + 0.8f, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            
            transform.position = new Vector3(0,transform.position.y - 0.8f,transform.position.z);
            
        }
        if (bulletManager.DIRECTION == 2)
        {
            speed *= -1;
            transform.position = new Vector3(0, transform.position.y + 0.8f, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void Update()
    {

       
       transform.position += new Vector3((bulletManager.DIRECTION * speed) * Time.deltaTime, 0);
        
     
    }

     void OnTriggerEnter2D(Collider2D t_other)
     {
        if(t_other.tag=="enemy")
        {
            Destroy(gameObject); // destroy this after a set amount of time
            bulletManager.decreaseBullets(); // decrease total number of bullets
            StopCoroutine("livingTime"); // stop the co-routine before destroying  
        }
        
     }


    IEnumerator livingTime()
    {
        yield return new WaitForSeconds(lifetime);

        bulletManager.decreaseBullets(); // decrease total number of bullets
        Destroy(gameObject); // destroy this after a set amount of time

        yield break;
    }
}
