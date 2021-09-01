using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeScripts : MonoBehaviour
{
	// tudo pra float pra não precisar converter toda hora
	public static bool isPopUp = false;
	public GameObject LockedPopUp;
	
    public static float slapUpgradeLevel;
	public float slapUpgradePrice;
	public TextMeshProUGUI SlapUpPrice;
	public GameObject SlapUpPopUp;
	public bool tutorialSlapUp = false;
	
    public static float chickenUpgradeLevel;
	public float chickenUpgradePrice;
	public TextMeshProUGUI ChiValPrice;
	public GameObject ChiValPopUp;
	public bool tutorialChiVal = false;
	
    public static float coolingUpgradeLevel;
	public float coolingUpgradePrice;
	public TextMeshProUGUI CollUpBPrice;
	public GameObject CollUpPopUp;
	public bool tutorialCollUp = false;	
	
	public static int workerUpgradeLevel;
	public static float workerUpgradePrice;
	public TextMeshProUGUI AddWorkerPrice;

    public static bool industryUpgrade = false;
    public GameObject industryButton;
	public GameObject FabricaButton;
    public float industryUpgradePrice = 200;
    public TextMeshProUGUI industryPriceText;
	public GameObject IndustryPopUp;
	public bool tutorialIndustry = false;

    public static bool collectorUpgrade = false;
    public GameObject collectorButton;
    public float collectorUpgradePrice = 500;
    public TextMeshProUGUI collectorPriceText;
	public GameObject CollectorPopUp;
	public bool tutorialCollector = false;
	public Button CollectButton;
	public GameObject CollectorBuyButton;

    public float workerTimeUpgrade;
    public float workerTimeUpgradeLimit = 0f;
    public float workerTimeUpgradePrice;
    public TextMeshProUGUI workerTimePriceText;
	public GameObject WorkerTimePopUp;
	public bool tutorialWorkerTime = false;
	public Button WorkerTimeButton;
	
	public float maxChickenStoredUpgrade;
	public float maxChickenStoredUpgradePrice; // cada upgrade aumenta em 10
	public TextMeshProUGUI maxChickenStoredPriceText;
	public GameObject maxChickenStoredPopUp;
	public bool tutorialMaxChickenStored = false;
	public Button maxChickenStoredButton;
	
	public Button AddWorkerButton;

	public GameObject moveWhenIndustryBought;
	public GameObject moveToFabricButton;
	public GameObject industryButtonVanish;
	public GameObject industryPriceVanish;

    public AudioSource moneySound;
    public AudioClip payedClip;
	
	public LevelHolder levelHolder;
	
	public GameObject Level3Locked;
	public GameObject Level4Locked;
	public GameObject Level5Locked;
	public GameObject Level6Locked;

    public static string UpgradeErrorText;
	
	//DEPOIS TEMOS QUE PASSAR O QUE TEM NO WORKERLOGICARRAY PRA CÁ, O DE SOMAR WORKER PELO MENOS
	//botão "AddWorker" ( child do "UpgradeButtons" )
	//e colocar pra gastar dinheiro também
	
	public WorkerArrayLogic workerLogic;

	void Awake()
	{
		if(PlayerPrefs.HasKey("slapUpgradeLevel")){
			slapUpgradeLevel = PlayerPrefs.GetFloat("slapUpgradeLevel");
            NewCookTemp();
        } else {
			slapUpgradeLevel = 1.0f;
		}
		if(PlayerPrefs.HasKey("slapUpgradePrice")){
			slapUpgradePrice = PlayerPrefs.GetFloat("slapUpgradePrice");
		} else {
			slapUpgradePrice = 25f;
		}
		if(PlayerPrefs.HasKey("tutorialSlapUp")){
			tutorialSlapUp = (PlayerPrefs.GetInt("tutorialSlapUp") != 0);
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("chickenUpgradeLevel")){
			chickenUpgradeLevel = PlayerPrefs.GetFloat("chickenUpgradeLevel");
		} else {
			chickenUpgradeLevel = 1.0f;
		}
		if(PlayerPrefs.HasKey("chickenUpgradePrice")){
			chickenUpgradePrice = PlayerPrefs.GetFloat("chickenUpgradePrice");
		} else {
			chickenUpgradePrice = 20f;
		}
		if(PlayerPrefs.HasKey("tutorialChiVal")){
			tutorialChiVal = (PlayerPrefs.GetInt("tutorialChiVal") != 0);
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("coolingUpgradeLevel")){
			coolingUpgradeLevel = PlayerPrefs.GetFloat("coolingUpgradeLevel");
		} else {
			coolingUpgradeLevel = 1.0f;
		}
		if(PlayerPrefs.HasKey("coolingUpgradePrice")){
			coolingUpgradePrice = PlayerPrefs.GetFloat("coolingUpgradePrice");
		} else {
			coolingUpgradePrice = 10f;
		}
		if(PlayerPrefs.HasKey("tutorialCollUp")){
			tutorialCollUp = (PlayerPrefs.GetInt("tutorialCollUp") != 0);
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("workerUpgradeLevel")){
			workerUpgradeLevel = PlayerPrefs.GetInt("workerUpgradeLevel");
		} else {
			workerUpgradeLevel = 1;
		}
		if(PlayerPrefs.HasKey("workerUpgradePrice")){
			workerUpgradePrice = PlayerPrefs.GetFloat("workerUpgradePrice");
		} else {
			workerUpgradePrice = 80.0f;
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("industryUpgrade")){
			industryUpgrade = (PlayerPrefs.GetInt("industryUpgrade") != 0);
		}
		if(PlayerPrefs.HasKey("tutorialIndustry")){
			tutorialIndustry = (PlayerPrefs.GetInt("tutorialIndustry") != 0);
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("tutorialCollector")){
			tutorialCollector = (PlayerPrefs.GetInt("tutorialCollector") != 0);
		}
		if(PlayerPrefs.HasKey("collectorUpgrade")){
			collectorUpgrade = (PlayerPrefs.GetInt("collectorUpgrade") != 0);
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("workerTimeUpgrade")){
			workerTimeUpgrade = PlayerPrefs.GetFloat("workerTimeUpgrade");
		} else {
			workerTimeUpgrade = 1.0f;
		}
		if(PlayerPrefs.HasKey("workerTimeUpgradePrice")){
			workerTimeUpgradePrice = PlayerPrefs.GetFloat("workerTimeUpgradePrice");
		} else {
			workerTimeUpgradePrice = 100f;
		}
		if(PlayerPrefs.HasKey("tutorialWorkerTime")){
			tutorialWorkerTime = (PlayerPrefs.GetInt("tutorialWorkerTime") != 0);
		}
		//////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////
		if(PlayerPrefs.HasKey("maxChickenStoredUpgrade")){
			maxChickenStoredUpgrade = PlayerPrefs.GetFloat("maxChickenStoredUpgrade");
		} else {
			maxChickenStoredUpgrade = 1f;
		}
		if(PlayerPrefs.HasKey("maxChickenStoredUpgradePrice")){
			maxChickenStoredUpgradePrice = PlayerPrefs.GetFloat("maxChickenStoredUpgradePrice");
		} else {
			maxChickenStoredUpgradePrice = 100f;
		}
		if(PlayerPrefs.HasKey("tutorialMaxChickenStored")){
			tutorialMaxChickenStored = (PlayerPrefs.GetInt("tutorialMaxChickenStored") != 0);
		}
	}

	void Start()
	{
		levelHolder = GameObject.Find("LevelHolder").GetComponent<LevelHolder>();
		
		workerLogic = GameObject.Find("WorkerArray").GetComponent<WorkerArrayLogic>();
		moveWhenIndustryBought = GameObject.Find("Locked");
		CollectButton = GameObject.Find("CollectorUpButton").GetComponent<Button>();
		WorkerTimeButton = GameObject.Find("WorkerTimeUpB").GetComponent<Button>();
		AddWorkerButton = GameObject.Find("AddWorker").GetComponent<Button>();
		FabricaButton = GameObject.Find("FabricaButton");
        industryPriceText.SetText(industryUpgradePrice.ToString());
        collectorPriceText.SetText(collectorUpgradePrice.ToString());
        workerTimePriceText.SetText(workerTimeUpgradePrice.ToString());
        moneySound.clip = payedClip;
		
		NewCookTemp();
		NewPayMoney();
		NewTimerRefresh();
		if(industryUpgrade == true){
			MoveLockedIndustryButtons();
		}
		if(collectorUpgrade == true){
			collectorPriceText.SetText("----");
		}
    }
	
	void Update()
	{
		ShowPrices();
		ColorPrices();
		PlayerPrefs.SetInt("workerUpgradeLevel", workerUpgradeLevel);
		PlayerPrefs.SetFloat("workerUpgradePrice", workerUpgradePrice);
	}
	
	public void ColorPrices()
	{
		if(ValorDinheiro.moneyTo < slapUpgradePrice){
			SlapUpPrice.color = Color.red;
		} else {
			SlapUpPrice.color = Color.white;
		}
		
		if(ValorDinheiro.moneyTo < chickenUpgradePrice){
			ChiValPrice.color = Color.red;
		} else {
			ChiValPrice.color = Color.white;
		}
		
		if(ValorDinheiro.moneyTo < coolingUpgradePrice){
			CollUpBPrice.color = Color.red;
		} else {
			CollUpBPrice.color = Color.white;
		}
		
		if(ValorDinheiro.moneyTo < workerUpgradePrice || levelHolder.level < 3){
			AddWorkerPrice.color = Color.red;
		} else {
			AddWorkerPrice.color = Color.white;
		}
        if (ValorDinheiro.moneyTo < industryUpgradePrice || levelHolder.level < 3)
        {
            industryPriceText.color = Color.red;
        } else {
            industryPriceText.color = Color.white;
        }
        if (ValorDinheiro.moneyTo < collectorUpgradePrice || levelHolder.level < 4)
        {
            collectorPriceText.color = Color.red;
        }
        else
        {
            collectorPriceText.color = Color.white;
        }
        if (ValorDinheiro.moneyTo < workerTimeUpgradePrice || levelHolder.level < 5)
        {
            workerTimePriceText.color = Color.red;
        }
        else
        {
            workerTimePriceText.color = Color.white;
        }
		
		if(ValorDinheiro.moneyTo < maxChickenStoredUpgradePrice || levelHolder.level < 6){
			maxChickenStoredPriceText.color = Color.red;
		} else {
			maxChickenStoredPriceText.color = Color.white;
		}
    }
	
	public void ShowPrices()
	{
        if (ClickFillBar.cooktemp <= 7.0f)
        {
           SlapUpPrice.SetText("---");

        }

        if (ClickFillBar.cooktemp >= 8.0f)
        {
            SlapUpPrice.SetText(slapUpgradePrice.ToString());

        }
        if(workerUpgradeLevel < 16)
        {
            AddWorkerPrice.SetText(workerUpgradePrice.ToString());
        } 
        if(workerUpgradeLevel >= 16)
        {
            AddWorkerPrice.SetText("---");

        }
        ChiValPrice.SetText(chickenUpgradePrice.ToString());
		CollUpBPrice.SetText(coolingUpgradePrice.ToString());        
        workerTimePriceText.SetText(workerTimeUpgradePrice.ToString());
		maxChickenStoredPriceText.SetText(maxChickenStoredUpgradePrice.ToString());
    }

	public void ClosePopUp()
	{
		isPopUp = false;
	}

	public void TutorialUpSlap()
	{
		if(tutorialSlapUp == false && ValorDinheiro.moneyTo >= slapUpgradePrice && ClickFillBar.cooktemp >= 6.0f){
			SlapUpPopUp.SetActive(true);
			isPopUp = true;
		} else {
			UpSlap();
		}
	}
    public void UpSlap()
    {
        if(ValorDinheiro.moneyTo >= slapUpgradePrice && ClickFillBar.cooktemp >= 8.0f)
        {
			tutorialSlapUp = true;
			PlayerPrefs.SetInt("tutorialSlapUp", (tutorialSlapUp ? 1 : 0));
            slapUpgradeLevel++;
            ValorDinheiro.moneyTo -= slapUpgradePrice;
			ValorDinheiro.lerpReseted = false;
			UpdatePriceSlap();
			NewCookTemp();
            StartCoroutine(PlayPayedSound());
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 15f;
        } else if(ValorDinheiro.money < slapUpgradePrice){
			//UpgradeErrorText = "Não possui dinheiro o bastante para comprar o upgrade de melhoria do tapa.";
			Debug.Log("Não possui dinheiro o bastante para comprar o upgrade de melhoria do tapa.");
		}
	}
	
	public void TutorialUpValue()
	{
		if(tutorialChiVal == false && ValorDinheiro.moneyTo >= chickenUpgradePrice){
			ChiValPopUp.SetActive(true);
			isPopUp = true;
		} else {
			UpValue();
		}
	}
    public void UpValue()
    {

        if (ValorDinheiro.moneyTo >= chickenUpgradePrice)
        {
			tutorialChiVal = true;
			PlayerPrefs.SetInt("tutorialChiVal", (tutorialChiVal ? 1 : 0));
            chickenUpgradeLevel++;
            ValorDinheiro.moneyTo -= chickenUpgradePrice;
			ValorDinheiro.lerpReseted = false;
			UpdatePriceChicken();
			NewPayMoney();
            StartCoroutine(PlayPayedSound());
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 15f;
			
        } else if (ValorDinheiro.money < chickenUpgradePrice){
			//UpgradeErrorText = "Não possui dinheiro o bastante para comprar o upgrade de valor da galinha.";
			Debug.Log("Não possui dinheiro o bastante para comprar o upgrade de valor da galinha.");
		}
	}

	public void TutorialUpCooling()
	{
		if(tutorialCollUp == false && ValorDinheiro.moneyTo >= coolingUpgradePrice){
			CollUpPopUp.SetActive(true);
			isPopUp = true;
		} else {
			UpCoolling();
		}
	}
	
    public void UpCoolling()
    {
        if (ValorDinheiro.moneyTo >= coolingUpgradePrice)
        {
			tutorialCollUp = true;
			PlayerPrefs.SetInt("tutorialCollUp", (tutorialCollUp ? 1 : 0));
            coolingUpgradeLevel++; ;
            ValorDinheiro.moneyTo -= coolingUpgradePrice;
			ValorDinheiro.lerpReseted = false;
			UpdatePriceCooling();
			NewTimerRefresh();
            StartCoroutine(PlayPayedSound());
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 5f;
        } else if (ValorDinheiro.money < coolingUpgradePrice){
			//UpgradeErrorText = "Não possui dinheiro o bastante para comprar o upgrade de resfriamento.";
			Debug.Log("Não possui dinheiro o bastante para comprar o upgrade de resfriamento.");
		}
	}
	/////////////////////////////////////////////
	//funções relacionadas ao slap
	public void UpdatePriceSlap()
	{
        slapUpgradePrice = Mathf.Ceil (slapUpgradePrice * 1.5f);
		PlayerPrefs.SetFloat("slapUpgradeLevel", slapUpgradeLevel);
		PlayerPrefs.SetFloat("slapUpgradePrice", slapUpgradePrice);
	}
	public void NewCookTemp()
	{
		ClickFillBar.tempUpgrade = 20.0f - (slapUpgradeLevel-1.0f);
	}


	/////////////////////////////////////////////
	//funções relacionadas à galinha
	public void UpdatePriceChicken()
	{
		chickenUpgradePrice = Mathf.Ceil(chickenUpgradePrice *1.5f);
		PlayerPrefs.SetFloat("chickenUpgradeLevel", chickenUpgradeLevel);
		PlayerPrefs.SetFloat("chickenUpgradePrice", chickenUpgradePrice);
	}
	public void NewPayMoney()
	{
		ClickFillBar.payMoney = 10f + ((chickenUpgradeLevel-1.0f) * 5f);
	}


	/////////////////////////////////////////////
	//funções relacionadas ao cooling
	public void UpdatePriceCooling()
	{
        coolingUpgradePrice = Mathf.Ceil(coolingUpgradePrice * 1.25f);
		PlayerPrefs.SetFloat("coolingUpgradeLevel", coolingUpgradeLevel);
		PlayerPrefs.SetFloat("coolingUpgradePrice", coolingUpgradePrice);
	}
	public void NewTimerRefresh()
	{
		ClickFillBar.timerRefresh += coolingUpgradeLevel*0.1f;
	}

    //Comprar industriaaaaaaaaaaaaaaaaaaaaaaaaaaaa
	
	public void TutorialIndustry()
	{
		if(levelHolder.level > 2 && tutorialCollUp == false && ValorDinheiro.moneyTo >= industryUpgradePrice && !industryUpgrade){
			IndustryPopUp.SetActive(true);
			isPopUp = true;
		} else if(levelHolder.level <= 2){
			Level3Locked.SetActive(true);
			isPopUp = true;
		} else {
			BuyIndustry();
		}
	}
    public void BuyIndustry()    {
        if (ValorDinheiro.moneyTo >= industryUpgradePrice && !industryUpgrade)
        {
			tutorialIndustry = true;
            industryUpgrade = true;
			PlayerPrefs.SetInt("tutorialIndustry", (tutorialIndustry ? 1 : 0));
			PlayerPrefs.SetInt("industryUpgrade", (industryUpgrade ? 1 : 0));
            ValorDinheiro.moneyTo -= industryUpgradePrice;
            ValorDinheiro.lerpReseted = false;
            //UpdateIndustryPrice();
			MoveLockedIndustryButtons();
			StartCoroutine(PlayPayedSound());
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 100f;
			
        } else if (industryUpgrade)
        {
            StartCoroutine(IndustryBought());
        }
    }
    IEnumerator IndustryBought()
    {
        industryPriceText.SetText("Já tem!");
        yield return new WaitForSeconds(1.5f);
        //UpdateIndustryPrice();
    }

    /*public void UpdateIndustryPrice()
    {
        industryPriceText.enabled = false;
		if(industryUpgrade == true){
			industryButton.SetActive(false);
		}
    }*/

	public void MoveLockedIndustryButtons() // web = +68f // +215.0f android
	{
		Vector3 position = moveToFabricButton.transform.position;
		moveWhenIndustryBought.transform.position = position;
		industryButtonVanish.SetActive(false);
		industryPriceVanish.SetActive(false);
		FabricaButton.SetActive(true);
	}

    //Comprar Coletor
	public void TutorialCollector()
	{
		if(industryUpgrade == false){
			LockedPopUp.SetActive(true);
			isPopUp = true;
			StartCoroutine(LockedError());
		} else if(levelHolder.level <= 3){
			Level4Locked.SetActive(true);
			isPopUp = true;
		} else {
			if(tutorialCollector == false && ValorDinheiro.moneyTo >= collectorUpgradePrice && !collectorUpgrade && industryUpgrade){
				CollectorPopUp.SetActive(true);
				isPopUp = true;
			} else {
				BuyCollector();
			}
		}
	}
	
    public void BuyCollector()
    {
        if (ValorDinheiro.moneyTo >= collectorUpgradePrice && !collectorUpgrade && industryUpgrade)
        {
			tutorialCollector = true;
            collectorUpgrade = true;
			PlayerPrefs.SetInt("tutorialCollector", (tutorialCollector ? 1 : 0));
            PlayerPrefs.SetInt("collectorUpgrade", (collectorUpgrade ? 1 : 0));
            ValorDinheiro.moneyTo -= collectorUpgradePrice;
            ValorDinheiro.lerpReseted = false;
            StartCoroutine(PlayPayedSound());
            UpdateCollectorPrice();
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 100f;
			
        }
    }

    public void UpdateCollectorPrice()
    {
        collectorPriceText.SetText("----");
    }

    IEnumerator CollectorBought()
    {
        collectorPriceText.SetText("Já tem!");
        yield return new WaitForSeconds(1.5f);
        UpdateCollectorPrice();
    }

    //Upgrade de trabalhador
	public void TutorialUpgradeWorker()
	{
		if(industryUpgrade == false){
			LockedPopUp.SetActive(true);
			isPopUp = true;
			StartCoroutine(LockedError());
		} else if(levelHolder.level <= 4){
			Level5Locked.SetActive(true);
			isPopUp = true;
		} else {
			if(tutorialWorkerTime == false && ValorDinheiro.moneyTo >= workerTimeUpgradePrice && industryUpgrade && workerTimeUpgradeLimit < 20){
				WorkerTimePopUp.SetActive(true);
				isPopUp = true;
			} else {
				UpgradeWorkerTime();
			}
		}
	}
	
    public void UpgradeWorkerTime()
    {
        if (ValorDinheiro.moneyTo >= workerTimeUpgradePrice && industryUpgrade && workerTimeUpgradeLimit < 20)
        {
			tutorialWorkerTime = true;
			PlayerPrefs.SetInt("tutorialWorkerTime", (tutorialWorkerTime ? 1 : 0));
            WorkerScript.timeToCookRefresher--;
            workerTimeUpgradeLimit++;
            workerTimeUpgrade++;
            ValorDinheiro.moneyTo -= workerTimeUpgradePrice;
            ValorDinheiro.lerpReseted = false;
            StartCoroutine(PlayPayedSound());
            workerTimeUpgradePrice = Mathf.Ceil(workerTimeUpgradePrice * 1.5f);
			PlayerPrefs.SetFloat("workerTimeUpgrade", workerTimeUpgrade);
			PlayerPrefs.SetFloat("workerTimeUpgradePrice", workerTimeUpgradePrice);
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 10f;
			
        }
    }
	
	public void TutorialMaxChickenStoredUpgrade()
	{
		if(industryUpgrade == false){
			LockedPopUp.SetActive(true);
			isPopUp = true;
			StartCoroutine(LockedError());
		} else if(levelHolder.level <= 5){
			Level6Locked.SetActive(true);
			isPopUp = true;
		} else {
			if(tutorialMaxChickenStored == false && ValorDinheiro.moneyTo >= maxChickenStoredUpgradePrice && industryUpgrade){
				maxChickenStoredPopUp.SetActive(true);
				isPopUp = true;
			} else {
				MaxChickenStoredUpgrade();
			}
		}
	}
	
	public void MaxChickenStoredUpgrade()
	{
		if(ValorDinheiro.moneyTo >= maxChickenStoredUpgradePrice && industryUpgrade){
			tutorialMaxChickenStored = true;
			PlayerPrefs.SetInt("tutorialMaxChickenStored", (tutorialMaxChickenStored ? 1 : 0));
			WorkerScript.MaxChickenStored += 10f;
			maxChickenStoredUpgrade++;
			ValorDinheiro.moneyTo -= maxChickenStoredUpgradePrice;
			ValorDinheiro.lerpReseted = false;
			maxChickenStoredUpgradePrice = Mathf.Ceil(workerTimeUpgradePrice * 1.4f);
			StartCoroutine(PlayPayedSound());
			PlayerPrefs.SetFloat("maxChickenStoredUpgrade", maxChickenStoredUpgrade);
			PlayerPrefs.SetFloat("maxChickenStoredUpgradePrice", maxChickenStoredUpgradePrice);
			
			levelHolder.LerpReset();
			LevelHolder.totalExpTo += 15f;
			
		}
	}
	
	public void LockedButton()
	{
		if (industryUpgrade == false){
			LockedPopUp.SetActive(true);
			isPopUp = true;
			StartCoroutine(LockedError());
		}
	}
	
	public IEnumerator LockedError()
	{
		yield return new WaitForSeconds(5);
		isPopUp = false;
		LockedPopUp.SetActive(false);
	}

    IEnumerator PlayPayedSound()
    {
        yield return new WaitForSeconds(0.1f);
        moneySound.PlayOneShot(moneySound.clip);
    }
}
