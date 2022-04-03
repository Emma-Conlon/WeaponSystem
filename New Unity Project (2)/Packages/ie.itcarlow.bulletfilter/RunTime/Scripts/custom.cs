using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class custom : MonoBehaviour
{
    public float time_Sp;
    public float time_L;
    public float time_A;
    public float time_B;
    public float time_S;
    public float sp;
    public float l;
    public float a;
    public float b;
    public float s;
    public Text time_shootsText;
    public Slider time_shoots;
    public Text time_bText;
    public Slider time_b;
    public Text time_aText;
    public Slider time_a;
    public Text time_spText;
    public Slider time_sp;
    public Text time_lText;
    public Slider time_l;
    void Start()
    {
        time_shootsText = GetComponent<Text>();
    }

    public void textUpdate(float value)
    {
        time_shootsText.text = Mathf.RoundToInt(time_shoots.value) + "%";
        s = value;
    }

    public void ammo(float value)
    {
        time_aText.text =time_a.value.ToString();
        a = value;
        print(time_A);
    }
    public void maxBullets(float value)
    {
        time_bText.text = time_b.value.ToString();
        b = value;
    }
    public void speed(float value)
    {
        time_spText.text = time_sp.value.ToString();
        sp = value;
    }
    public void lifttime(float value)
    {
        time_lText.text = Mathf.RoundToInt(time_l.value * 100.0f) + "%";
        l = value;
    }


    private void Update()
    {
         time_Sp = sp;
          time_L =l;
       time_A = a;
        time_B = b;
         time_S = s;
    }

}
