using UnityEngine;
using UnityEngine.UI;


public class Weaon_Menu : MonoBehaviour
{
    public BulletManager _bullet;
    public  GameObject menu;
    public Weapons selection;
    public player S;
    private bool select;
    public GameObject rapidf;
    public GameObject pistols;
    public GameObject customf;
    public Text weapon;
    // Start is called before the first frame update
    void Start()
    {
       
       
        select = false;
        selection = Weapons.PISTOL;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
           if(!select)
            {
                menu.SetActive(true);
                select = true;
                Debug.Log("YES");
            }
            else if (select)
            {
                menu.SetActive(false);
                select = false;
                Debug.Log("NO");
            }


        }
    }

    public void pistol()
    {
        _bullet.choosenormal();
        S.chooseN();
        weapon.text = "Pistol";
        rapidf.SetActive(false);
        pistols.SetActive(true);
        Debug.Log("PISTOL");
    }
    public void custom()
    {
        _bullet.chooseC();
        S.chooseC();
    }
    public void rapid()
    {
        _bullet.chooseR();
         S.chooseR();
        //ammo.Ammochange(selection);
        weapon.text = "Shootgun";
        rapidf.SetActive(true);
        pistols.SetActive(false);
        
    }
}
