using UnityEngine;
using UnityEngine.UI;


public class Weaon_Menu : MonoBehaviour
{
    public AmmoManager ammo;
    public enumManager mon;
    public  GameObject menu;
    public Weapons selection;
    private bool select;
    public GameObject rapidf;
    public GameObject pistols;
    public Text weapon;
    // Start is called before the first frame update
    void Start()
    {
        mon = this.GetComponent<enumManager>();
       
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
        selection = Weapons.PISTOL;
        ammo.Ammochange(selection);
        weapon.text = "Pistol";
        rapidf.SetActive(false);
        pistols.SetActive(true);
        Debug.Log("PISTOL");
    }
   
    public void rapid()
    {
        selection = Weapons.RAPID_FIRE;
        ammo.Ammochange(selection);
        weapon.text = "Shootgun";
        rapidf.SetActive(true);
        pistols.SetActive(false);
        
    }
}
