using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float velx = 5.0f;
    public float vely = 0.0f;
    public Rigidbody2D rb;
    private BulletControl _bulletController;
    double ammo = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _bulletController = GetComponent<BulletControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_bulletController.getDirection() == 1)
            {

                Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(rb, transform.position, transform.rotation);
                rb.velocity = new Vector2(velx, vely);
            }
            else
            {

                Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(rb, transform.position, transform.rotation);
                rb.velocity = new Vector2(-velx, vely);
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            //Object.Destroy(this.gameObject);
        }
    }
}
