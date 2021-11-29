using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float velx = 5.0f;
    public float vely = 0.0f;
    public Rigidbody2D rb;
    private BulletControl _bulletController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _bulletController = GetComponent<BulletControl>();
    }

    // Update is called once per frame
    void Update()
    {       
        if(_bulletController.getDirection() == 1)
        {
            rb.velocity = new Vector2(velx, vely);
        }
        else
        {
            rb.velocity = new Vector2(-velx, vely);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
