using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EggTextColor : MonoBehaviour
{
	public TextMeshProUGUI SkinFriendsPrice;
	
	public TextMeshProUGUI SkinPumbaPrice;

    public bool friendsSkin;
    public bool pumbaSkin;

    // Start is called before the first frame update
    void Start()
    {
		
        /*if (PlayerPrefs.HasKey("SkinPriceInt"))
        {
            SkinPriceInt = PlayerPrefs.GetInt("SkinPriceInt");
            SkinPrice.text = "---";
        }*/
    }

    // Update is called once per frame
    void Update()
    {
		/*if(DiamondEggCounter.DECounter < TextFriendsSkin.SkinPriceIntFriends){
			SkinFriendsPrice.color = Color.red;
		} else {
			SkinFriendsPrice.color = Color.white;
		}*/
		
		/*if(DiamondEggCounter.DECounter < TextPumbaSkin.SkinPriceIntPumba){
			SkinPumbaPrice.color = Color.red;
		} else {
			SkinPumbaPrice.color = Color.white;
		}*/
		
		
        /*if(pumbaSkin && SkinSelect.pumbaSkinA)
        {
            SkinPrice.text = "---";
            SkinPriceInt = 0;
            PlayerPrefs.SetInt("SkinPriceInt", SkinPriceInt);
        }
        if (friendsSkin && SkinSelect.friendsSkinA)
        {
            SkinPrice.text = "---";
            SkinPriceInt = 0;
            PlayerPrefs.SetInt("SkinPriceInt", SkinPriceInt);
        }*/
    }
}
