using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum  SECTION{
    PISTOL,
    RAPID,
    CUSTOM,
}

public class player : MonoBehaviour
{
    SECTION choose;
    private Animator _animator;
    private Rigidbody2D _rb;
    public custom c;
    private bool _isShooting = false;
    private bool idleshoot;
    public float _timeBetweenShots;
    public int direction = -1;
    private BulletManager _bulletManager;
   

    
   

    void Start()
    {
        choose = SECTION.PISTOL;
        setUpPlayer();
    }

    void setUpPlayer()
    {
   
        _rb = this.GetComponent<Rigidbody2D>();
        _rb = this.GetComponent<Rigidbody2D>();
        if (!_rb)
        {
            this.gameObject.AddComponent<Rigidbody2D>();
            _rb = this.GetComponent<Rigidbody2D>();
            _rb.angularDrag = 0;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            _rb.gravityScale = 3;
        }
        _bulletManager = gameObject.GetComponent<BulletManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerAnimationStates();
        if(choose == SECTION.CUSTOM)
        {
            _timeBetweenShots = c.time_S;
        }
        
    }

    void updatePlayerAnimationStates()
    {
        
            getShootInput();
        

        Vector3 temp = transform.localScale;
        if (temp.x < 0) { direction = 1; }
        if (temp.x > 0) { direction = -1; }
    }

   

    

    void getShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_bulletManager.DIRECTION == 0)
            {
                print("PICK DIRECTION");
            }
            else
            {
                handleIdlePlayerShooting();
            }
               
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            _bulletManager.DIRECTION = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            _bulletManager.DIRECTION = 1;
        }
    }

    public void handleIdlePlayerShooting()
    {
        _isShooting = true;
        idleshoot = true;
       // if (_gunManager.getCurrentGun() == Gun.SteamPunk)
      // / {
      //      Vector2 temp = _rb.velocity;
       //     temp.x = (direction * -1) * 10;
       //     _rb.velocity = temp;
      //  }
        _bulletManager.shootBullet();
        StartCoroutine("shootingCooldown");
    }

   
    IEnumerator shootingCooldown()
    {
        yield return new WaitForSeconds(_timeBetweenShots);
        _isShooting = false;
        idleshoot = false;
        yield return new WaitForSeconds(_timeBetweenShots);
   
    }

   
   
    
}
