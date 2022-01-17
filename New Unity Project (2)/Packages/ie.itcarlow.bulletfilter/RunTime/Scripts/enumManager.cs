using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enumManager : MonoBehaviour
{
    
    public Weapons selection = Weapons.PISTOL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum Weapons
{ PISTOL, CUSTOM, SHEILD, RAPID_FIRE, AIR }