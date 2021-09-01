using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour, IUnityAdsListener
{
	string GooglePlay_ID = "4156391";
	public bool testMode = false;
	
	string myPlacementID = "rewardedVideo";
	
	public int whichAd = 0;
	public LevelHolder levelHolder;
	
	public int chickenSold = 0;
	public int addExp = 0;
	public int addDiamonds = 0;
	
	public int buttonClicked = 0;
	public GameObject[] Buttons;
	
    // Start is called before the first frame update
    void Start()
    {
		Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, testMode);
		levelHolder = GameObject.Find("LevelHolder").GetComponent<LevelHolder>();
    }

    public void DisplayInterstitialAD()
	{
		Advertisement.Show();
	}
	
	public void DisplayVideoAD()
	{
		Advertisement.Show(myPlacementID);
	}
	
	public void OnUnityAdsDidFinish (string placementID, ShowResult showResult){
		if(showResult == ShowResult.Finished)
		{
			Debug.Log(whichAd);
			if(whichAd == 1){
				ValorDinheiro.moneyTo += chickenSold * ClickFillBar.payMoney;
				ValorDinheiro.lerpReseted = false;
				PlayerPrefs.SetFloat("moneyTo", ValorDinheiro.moneyTo);
				Debug.Log("grana");
			} else if(whichAd == 2){
				LevelHolder.totalExpTo += addExp;
				levelHolder.LerpReset();
				PlayerPrefs.SetFloat("totalExpTo", LevelHolder.totalExpTo);
				Debug.Log("exp");
			} else if(whichAd == 3){
				DiamondEggCounter.DECounter += addDiamonds;
				PlayerPrefs.SetFloat("DECounter", DiamondEggCounter.DECounter);
				Debug.Log("chicoin");
			}
			PlayerPrefs.SetInt("ad"+Buttons[buttonClicked].name, 0);
			
		} else if(showResult == ShowResult.Skipped){
			Debug.Log("You DON'T get a reward.");
		} else if(showResult == ShowResult.Failed){
			Debug.Log("The ad did not finish due to an error.");
		}
	}
	
	public void OnUnityAdsReady (string placementID){
		if(placementID == myPlacementID){
			
		}
	}
	
	public void OnUnityAdsDidError (string message){
		
	}
	
	public void OnUnityAdsDidStart (string placementID){
		
	}
	
	public void OleoAd()
	{	
		whichAd = 1; // venda de galinhas
	} 
	
	public void PimentaAd()
	{
		whichAd = 2; // add exp
	} 
	
	public void SalAd()
	{
		whichAd = 3; // add chicoins
	} 
	
	public void Button1()
	{
		buttonClicked = 1;
		Debug.Log(buttonClicked);
	}
	public void Button2()
	{
		buttonClicked = 2;
		Debug.Log(buttonClicked);
	}
	public void Button3()
	{
		buttonClicked = 3;
		Debug.Log(buttonClicked);
	}
	public void Button4()
	{
		buttonClicked = 4;
		Debug.Log(buttonClicked);
	}
	public void Button5()
	{
		buttonClicked = 5;
		Debug.Log(buttonClicked);
	}
	public void Button6()
	{
		buttonClicked = 6;
		Debug.Log(buttonClicked);
	}
	public void Button7()
	{
		buttonClicked = 7;
		Debug.Log(buttonClicked);
	}
	public void Button8()
	{
		buttonClicked = 8;
		Debug.Log(buttonClicked);
	}
	public void Button9()
	{
		buttonClicked = 9;
		Debug.Log(buttonClicked);
	}
}
