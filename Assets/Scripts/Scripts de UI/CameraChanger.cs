using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChanger : MonoBehaviour
{
    public Transform Principal;
    public Transform Fabrico;
	
	public GameObject bgItens;

	public GameObject MainButton;
	public GameObject FabricaButton;
	public GameObject Heater;
	public GameObject HeaterFill;

	public GameObject Upgrade;
	
	public GameObject CollectAll;
	
	public GameObject LojaButton;
	public GameObject SkinsButton;
	public GameObject ItensButton;
	public GameObject LevelHolder;
	
	public float tempLerp;
	public float duration;
	public int state; // 0 idle, 1 abrindo, 2 fechando
	
	public void LerpReset()
	{
		tempLerp = 0f;
	}
	
	void Start()
	{
		MainButton = GameObject.Find("MainButton");
		FabricaButton = GameObject.Find("FabricaButton");
		bgItens = GameObject.Find("bgItens");
		Heater = GameObject.Find("Termometro");
		HeaterFill = GameObject.Find("TermometroCompleto");
		Upgrade = GameObject.Find("UpgradePanel");
		CollectAll = GameObject.Find("CollectAllSprite");
		bgItens = GameObject.Find("ItensPosition");
		
		MainButton.SetActive(false);
        FabricaButton.SetActive(UpgradeScripts.industryUpgrade);
		duration = 0.8f;
		LerpReset();
    }
	
    // Update is called once per frame
    void Update()
    {
		if(state != 0){
			if(state == 1){
				tempLerp += Time.deltaTime / duration;
				transform.position = Vector3.MoveTowards(transform.position, bgItens.transform.position, tempLerp);
				if(transform.position == bgItens.transform.position){
					state = 0;
				}
			} else if(state == 2){
				tempLerp += Time.deltaTime / duration;
				transform.position = Vector3.MoveTowards(transform.position, Principal.position, tempLerp);
				if(transform.position == Principal.position){
					state = 0;
				}
			}
		}
    }

    public void ChangeToPrincipal()
    {
		if(UpgradePanel.isUpgradeScreenUp == false && UpgradeScripts.isPopUp == false){
			transform.position = Principal.position;
			MainButton.SetActive(false);
            FabricaButton.SetActive(true);
            Heater.SetActive(true);
			HeaterFill.SetActive(true);
			Upgrade.SetActive(true);		
			LojaButton.SetActive(true);
			SkinsButton.SetActive(true);
			ItensButton.SetActive(true);		
			LevelHolder.SetActive(true);			
            if (UpgradeScripts.collectorUpgrade)
            {
                CollectAll.SetActive(false);
            }
		}      
    }

    public void ChangeToWorkers()
    {
        if(UpgradePanel.isUpgradeScreenUp == false && UpgradeScripts.isPopUp == false){
			transform.position = Fabrico.position;
			MainButton.SetActive(true);
            FabricaButton.SetActive(false);
			Heater.SetActive(false);
			HeaterFill.SetActive(false);
			Upgrade.SetActive(false);
			LojaButton.SetActive(false);
			SkinsButton.SetActive(false);
			ItensButton.SetActive(false);
			LevelHolder.SetActive(false);
            if (UpgradeScripts.collectorUpgrade)
            {
                Debug.Log("asdas");
                CollectAll.SetActive(true);
            }
        }
    }
	
	public void OpenItens()
	{
		if(UpgradePanel.isUpgradeScreenUp == false && UpgradeScripts.isPopUp == false){
			state = 1;
			LerpReset();
			LojaChanger.isLojaUp = true;
		}
	}
	
	public void CloseItens()
	{
		if(UpgradePanel.isUpgradeScreenUp == false && UpgradeScripts.isPopUp == false){
			state = 2;
			LerpReset();
			LojaChanger.isLojaUp = false;
		}
	}
	/*public void CheckIfCollectBought()
	{
		if(isCollectAllBought == true){
			CollectAll.SetActive(true);
		} else {
			CollectAll.SetActive(false);
		}
	}*/

}
