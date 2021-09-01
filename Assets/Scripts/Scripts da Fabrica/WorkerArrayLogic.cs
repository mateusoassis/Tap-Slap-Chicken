using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorkerArrayLogic : MonoBehaviour
{
	public GameObject[] TotalWorkers;
	public int MaxWorkers = 15;
	public int Workers;
	public GameObject AddWorkerPopUp;
	public bool tutorialAddWorker;
	public UpgradeScripts Upgrades;
	
	public LevelHolder levelHolder;
	
	public GameObject Level3Locked;
	
    // Start is called before the first frame update
    void Start()
    {
		levelHolder = GameObject.Find("LevelHolder").GetComponent<LevelHolder>();
		
        Upgrades = GameObject.Find("UpgradeButtons").GetComponent<UpgradeScripts>();
		if(PlayerPrefs.HasKey("Workers")){
			Workers = PlayerPrefs.GetInt("Workers");
		} else {
			Workers = 0;
		}
		if(PlayerPrefs.HasKey("tutorialAddWorker")){
			tutorialAddWorker = (PlayerPrefs.GetInt("tutorialAddWorker") != 0);
		}
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < MaxWorkers; i++){
			if(i < Workers){
				TotalWorkers[i].SetActive(true);
			} else {
				TotalWorkers[i].SetActive(false);
			}
		}
		PlayerPrefs.SetInt("Workers", Workers);
    }
	
	public void TutorialAddWorker()
	{
		if(UpgradeScripts.industryUpgrade == false){
			Upgrades.LockedPopUp.SetActive(true);
			UpgradeScripts.isPopUp = true;
			Upgrades.StartCoroutine(Upgrades.LockedError());
		} else if(levelHolder.level <= 2){
			Level3Locked.SetActive(true);
			UpgradeScripts.isPopUp = true;
		} else {
			if(tutorialAddWorker == false && ValorDinheiro.moneyTo >= UpgradeScripts.workerUpgradePrice && UpgradeScripts.industryUpgrade){
				AddWorkerPopUp.SetActive(true);
				UpgradeScripts.isPopUp = true;
			} else {
				AddWorker();
			}
		}
	}
	public void AddWorker()
	{
		if (ValorDinheiro.moneyTo >= UpgradeScripts.workerUpgradePrice && UpgradeScripts.industryUpgrade && UpgradeScripts.workerUpgradeLevel <= 16)
        {
			tutorialAddWorker = true;
			PlayerPrefs.SetInt("tutorialAddWorker", (tutorialAddWorker ? 1 : 0));
			UpgradeScripts.workerUpgradeLevel++;
            Workers = UpgradeScripts.workerUpgradeLevel - 1;
            ValorDinheiro.moneyTo -= UpgradeScripts.workerUpgradePrice;
            ValorDinheiro.lerpReseted = false;
            UpgradeScripts.workerUpgradePrice = Mathf.Ceil(UpgradeScripts.workerUpgradePrice * 1.5f);
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 50f;
			
        } else if (ValorDinheiro.money < UpgradeScripts.workerUpgradePrice){
			//UpgradeScripts.UpgradeErrorText = "Não possui dinheiro o bastante para comprar um trabalhador extra.";
			Debug.Log("Não possui dinheiro o bastante para comprar um trabalhador extra.");
		}
	}
	
	public void SaveTime()
	{
		PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());
	}
	
	public void OnApplicationQuit()
	{
		SaveTime();
	}
	public void OnApplicationMinimize()
	{
		SaveTime();
	}
	public void OnApplicationPause()
	{
		SaveTime();
	}
}
