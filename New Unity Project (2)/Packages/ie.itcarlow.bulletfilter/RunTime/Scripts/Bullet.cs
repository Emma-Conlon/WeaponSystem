using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
   public float Direction=0;
    public float velx = 5.0f;
    public float vely = 0.0f;
    public int speed=0;
    public bool canshoot = true;
    public Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        
        canshoot = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        if(Direction==1)
        {
            rb.velocity = new Vector2(velx, vely);
        }
        if (Direction == -1)
        {
            rb.velocity = new Vector2(-velx, vely);
        }
    }

    public void setDIRECTION(int direction)
    {
        Direction = direction;

    }

    public void setY(float y)
    {
        vely = y;
    }
}
