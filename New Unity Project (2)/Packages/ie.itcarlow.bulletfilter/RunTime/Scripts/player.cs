using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum  SECTION{
    PISTOL, //default weapon
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
        getShootInput();
        if (choose == SECTION.CUSTOM)
        {
            _bulletManager.chooseCustom();
            _timeBetweenShots = c.time_shoots.value;
        }

        if (choose == SECTION.RAPID)
        {
            _bulletManager.chooseRapid();
            _timeBetweenShots = 2.0f;
            print("RAPID");
        }
        if (choose == SECTION.PISTOL)
        {
            _bulletManager.choosenormal();
            _timeBetweenShots = 0.25f;
            print("PISTOL");
        }

    }
   public void chooseR()
    {
        print("SELECTED");
        choose = SECTION.RAPID;
        _bulletManager.chooseRapid();
        _timeBetweenShots = 2.0f;
        
    }
    public void chooseC()
    {
        print(c.time_A);
        choose = SECTION.CUSTOM;
        _bulletManager.chooseC();
        _timeBetweenShots = c.time_shoots.value;

    }

    public void chooseN()
    {
        print("SELECTED");
        choose = SECTION.PISTOL;
        _bulletManager.choosenormal();
        _timeBetweenShots = 0.25f;
    }


   

    

    void getShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (choose == SECTION.RAPID && GetComponent<BulletManager>().rapidAmmo > 0)
            {
                rapid_fire_shoooting();
            }
            if (choose == SECTION.CUSTOM && GetComponent<BulletManager>().rapidAmmo > 0)
            {
               custom_fire_shoooting();
            }
            if (choose == SECTION.PISTOL)
            {
                pistol_shooting();
            }
               
        }
      
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            _bulletManager.DIRECTION = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            _bulletManager.DIRECTION = 1;
        }
    }

    public void pistol_shooting()
    {
        
        _bulletManager.shootBullet();
        StartCoroutine("shootingCooldown");
    }

    public void rapid_fire_shoooting()
    {
       
        _bulletManager.shootRapid();
        StartCoroutine("shootingCooldown");
    }
    public void custom_fire_shoooting()
    {
       
        _bulletManager.shootCustom();
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
