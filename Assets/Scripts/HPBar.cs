using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public GameObject Player;

    Attributes AttributesScript;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        AttributesScript = Player.GetComponent<Attributes>();
        slider = GetComponent<Slider>();
        slider.maxValue = AttributesScript.GetHPMax();
        slider.value = AttributesScript.currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = AttributesScript.GetHPMax();
        slider.value = AttributesScript.currentHP;
    }
}
