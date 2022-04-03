using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class custombullet : MonoBehaviour
{
    public custom c;
    public custombulletmanager bulletManager;
    public float bulletDirection;
    public float speed;
    public float lifetime;

    // Update is called once per frame

    void Start()
    {
        StartCoroutine("livingTime");
        bulletDirection = 1;
        bulletManager.increaseBullets();
        speed = c.time_Sp;
        lifetime = c.time_L;
    }

    void Update()
    {
        speed = c.time_Sp;
        lifetime= c.time_L;
        if (bulletManager.DIRECTION == 1)
        {
            transform.position += new Vector3((bulletManager.DIRECTION * c.time_Sp) * Time.deltaTime, 0);
        }
        if (bulletManager.DIRECTION == -1)
        {
            speed = speed * -1;
            transform.position += new Vector3((bulletManager.DIRECTION * c.time_Sp) * Time.deltaTime, -1);
            print("LEFT" + speed);
        }
    }

    void OnTriggerEnter2D(Collider2D t_other)
    {
        bool collSuccess = false;

        if (t_other.tag != "Player")
        {
            if (collSuccess)
            {
                bulletManager.decreaseBullets(); // decrease total number of bullets
                StopCoroutine("livingTime"); // stop the co-routine before destroying
                Destroy(gameObject);
            }

        }
    }


    IEnumerator livingTime()
    {
        yield return new WaitForSeconds(c.time_L);

        bulletManager.decreaseBullets(); // decrease total number of bullets
        Destroy(gameObject); // destroy this after a set amount of time

        yield break;
    }
}
