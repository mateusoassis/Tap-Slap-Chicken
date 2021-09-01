using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OfflineProgress : MonoBehaviour
{	
	public bool offlineProgressCheck;
	
	public WorkerScript[] WorkersArray;
	public float chickenGains;
	public float rawTime;
	
	private string parentName;
	private int workerIndex;
	public int numberOfWorkers;
	
	public WorkerScript workerParent;
	public WorkerArrayLogic workerArrayNow;
	
	public void DeleteWorkerFromParentName()
	{
		parentName = parentName.Replace("Worker", "");
		workerIndex = int.Parse(parentName);
	}
	
	public void LoadOfflineProduction()
	{
		// Offline Time Management
		var tempOfflineTime = Convert.ToInt64(PlayerPrefs.GetString("OfflineTime"));
		var oldTime = DateTime.FromBinary(tempOfflineTime);
		var currentTime = DateTime.Now;	
		var difference = currentTime.Subtract(oldTime);
		rawTime = (float)difference.TotalSeconds;
		var offlineTime = rawTime / 10; // ????
			
		AddChickens(rawTime);
	}
	
	void Awake()
	{
		workerParent = gameObject.GetComponentInParent(typeof(WorkerScript)) as WorkerScript;
		parentName = transform.parent.name;
		workerArrayNow = GameObject.Find("WorkerArray").GetComponent<WorkerArrayLogic>();
		if(PlayerPrefs.HasKey("Workers")){
			numberOfWorkers = PlayerPrefs.GetInt("Workers", numberOfWorkers);
		}
	}
	
	
	
	void Start()
	{
		DeleteWorkerFromParentName();
		LoadOfflineProduction();
	}
	
	public void AddChickens(float time)
	{
		if(numberOfWorkers >= workerIndex){
			chickenGains = time / (2 * WorkerScript.timeToCookRefresher);
			workerParent.ChickenCookeds += Mathf.Floor(chickenGains);
			if(workerParent.ChickenCookeds > WorkerScript.MaxChickenStored){
					workerParent.ChickenCookeds = WorkerScript.MaxChickenStored;
			}		
		}
	}
	
	
}
