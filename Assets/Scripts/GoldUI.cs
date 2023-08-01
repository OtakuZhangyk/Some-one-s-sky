using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    public GameObject Player;

    private int gold;
    private TMP_Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<TMP_Text>();
        gold = Player.GetComponent<Attributes>().gold;

        goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gold = Player.GetComponent<Attributes>().gold;
        goldText.text = gold.ToString();
    }
}
