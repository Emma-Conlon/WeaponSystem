using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoManager : MonoBehaviour
{
    public enumManager mon;
    public Weapons selection;
    double RapidAmmo = 0;
    public Text ammoleft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (mon.selection == Weapons.RAPID_FIRE)
        {
            RapidAmmo = 10;
            ammoleft.text = RapidAmmo.ToString();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RapidAmmo-=1;
                ammoleft.text = RapidAmmo.ToString();
            }


        }
        if (mon.selection == Weapons.PISTOL)
        {
            
            ammoleft.text = "Infinite";
        }
        Debug.Log("ENUM CHANGED"+ mon.selection);
    }

  public  void Ammochange(Weapons t_selection)
    {
        mon.selection = t_selection;
        if(selection==Weapons.RAPID_FIRE)
        {
            Debug.Log("ENUM CHANGED");
        }
    }
}
