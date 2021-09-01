using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextFriendsSkin : MonoBehaviour
{
	public TextMeshProUGUI SkinPrice;
	public static int SkinPriceIntFriends;
	
	public EggTextColor eggText;
	
    void Awake()
	{
		eggText = transform.parent.GetComponent<EggTextColor>();
	}
	
    void Start()
    {
        if (PlayerPrefs.HasKey("SkinPriceFriends"))
        {
            SkinPriceIntFriends = PlayerPrefs.GetInt("SkinPriceFriends");
            SkinPrice.text = "---";
        }
    }

    // Update is called once per frame
    void Update()
    {
		if(DiamondEggCounter.DECounter < SkinPriceIntFriends){
			SkinPrice.color = Color.red;
		} else {
			SkinPrice.color = Color.white;
		}
		
        if (eggText.friendsSkin && SkinSelect.friendsSkinA)
        {
            SkinPrice.text = "---";
            SkinPriceIntFriends = 0;
            PlayerPrefs.SetInt("SkinPriceFriends", SkinPriceIntFriends);
        }		
    }
}
