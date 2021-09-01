using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiamondEggCounter : MonoBehaviour
{


    public static float DECounter = 0;
    public TextMeshProUGUI DECounterText;

    void Awake()
    {
        if (PlayerPrefs.HasKey("DECounter"))
        {
            DECounter = PlayerPrefs.GetFloat("DECounter");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DECounterText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        DECounterText.text = DECounter.ToString();
        PlayerPrefs.SetFloat("DECounter", DECounter);
    }


}
