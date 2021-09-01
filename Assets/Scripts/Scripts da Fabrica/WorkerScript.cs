using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerScript : MonoBehaviour
{
	
	private int n;
	public WorkerArrayLogic workersArrayLogic;

    public float ChickenCookeds;

    public float timeToCook = 30;
    public static float timeToCookRefresher = 30f;
	public static float MaxChickenStored = 20f;
	public TextMeshPro numberOfChickens;

    public AudioSource workerSound;
    public AudioClip workerClip;
	
    // Start is called before the first frame update
	
	void Awake()
	{
		workersArrayLogic = GameObject.Find("WorkerArray").GetComponent<WorkerArrayLogic>();
		if(PlayerPrefs.HasKey(this.gameObject.name+"chicken")){
			ChickenCookeds = PlayerPrefs.GetFloat(this.gameObject.name+"chicken");
		} else {
			ChickenCookeds = 0f;
		};		
	}
    void Start()
    {
        workerSound = GetComponent<AudioSource>();
        workerSound.clip = workerClip;
		
		/*for(int n = 0; n <= 
		if(PlayerPrefs.HasKey("*/
    }

    // Update is called once per frame
    void Update()
    {
        //offline progress save 
		PlayerPrefs.SetFloat(this.gameObject.name+"chicken", ChickenCookeds);
        if(timeToCook <= 0f)
        {
            if(ChickenCookeds <= MaxChickenStored)
            {
                ChickenCookeds++;
            }
            timeToCook = timeToCookRefresher;
            Debug.Log(timeToCookRefresher);
        } else if (timeToCook > 0 && ChickenCookeds <= MaxChickenStored)
        {
            timeToCook -= Time.deltaTime;
        }
		
		//IMPRIMIR QUANTIDADE DE FRANGOS
		numberOfChickens.SetText(ChickenCookeds.ToString());
        
		/*if (Input.GetMouseButtonDown(0))
        {
            ValorDinheiro.money += 20f * ChickenCookeds;
            ChickenCookeds = 0f;
        }*/

		if(ChickenCookeds == 0){
			numberOfChickens.enabled = false;
		} else {
			numberOfChickens.enabled = true;
		}
		
		
	}
        
    /*void OnMouseDown()
    {
        if(UpgradePanel.isUpgradeScreenUp == false){
			Collect();
		}
    }*/
	
	public void Collect()
	{
		ValorDinheiro.moneyTo += ClickFillBar.payMoney * ChickenCookeds;
		ValorDinheiro.lerpReseted = false;
        ChickenCookeds = 0f;
        workerSound.PlayOneShot(workerSound.clip);
    }

}
    
    
