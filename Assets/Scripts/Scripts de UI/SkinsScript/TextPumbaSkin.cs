using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPumbaSkin : MonoBehaviour
{
	public TextMeshProUGUI SkinPrice;
	public static int SkinPriceIntPumba;
	
    public EggTextColor eggText;
	
	void Awake()
	{
		eggText = transform.parent.GetComponent<EggTextColor>();
	}
	
    void Start()
    {
        if (PlayerPrefs.HasKey("SkinPricePumba"))
        {
            SkinPriceIntPumba = PlayerPrefs.GetInt("SkinPricePumba");
            SkinPrice.text = "---";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
		if(DiamondEggCounter.DECounter < SkinPriceIntPumba){
			SkinPrice.color = Color.red;
		} else {
			SkinPrice.color = Color.white;
		}
		
		if(eggText.pumbaSkin && SkinSelect.pumbaSkinA)
        {
            SkinPrice.text = "---";
            SkinPriceIntPumba = 0;
            PlayerPrefs.SetInt("SkinPricePumba", SkinPriceIntPumba);
        }
    }
}
