using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
	public Canvas canvas;
	
	public RectTransform UpgradeScreen;
	
	public float CanvasHeight;
	
	public float Height; // de onde ele sai
	public float FutureHeight; // pra onde vai
	public int UpgradeMove;
	
	public Button BotaoAbrir;
	public Button BotaoFechar;
	public Image FecharImage;
	
	public static bool isUpgradeScreenUp;
	public GameObject ShowUpgradesButton;
	
	void Start()
	{
		CanvasHeight = canvas.gameObject.GetComponent<RectTransform>().rect.height-110f;
		CloseUpgradeScreen();
		UpgradeMove = 0; // 0 idle, 1 abrindo, 2 fechando
		isUpgradeScreenUp = false;
		ShowUpgradesButton = GameObject.Find("ShowUpgradesButton");
	}
	
	void Update()
	{
		if(UpgradeMove != 0){
			//UpgradeScreen.anchoredPosition = new Vector2(0, 0);
			if(UpgradeMove == 1){
				//UpgradeScreen.anchoredPosition = new Vector2(0, - CanvasHeight + 100);
				Height += CanvasHeight * 2 * Time.deltaTime;
				if(Height >= -277){
					Height = -277;
					UpgradeMove = 0;
                    //isUpgradeScreenUp = true;
                }
                
            } 
			else if(UpgradeMove == 2){
				Height -= CanvasHeight * 2 * Time.deltaTime;
				if(Height < FutureHeight){
					Height = FutureHeight;
					UpgradeMove = 0;
                    //isUpgradeScreenUp = false;
                }
                
            }

			UpgradeScreen.anchoredPosition = new Vector2(0, Height);
		}
		
	}
	public void OpenUpgradeScreen()
	{
		if(UpgradeMove == 0){
			FutureHeight = -277;
			Height = - CanvasHeight + 316; // web = -1844, android = - CanvasHeight + 316
			UpgradeMove = 1;
		}
		isUpgradeScreenUp = true;

    }
	public void CloseUpgradeScreen()
	{
		if(UpgradeMove == 0 && UpgradeScripts.isPopUp == false){
			FutureHeight = - CanvasHeight + 316; // web = -1844, android = - CanvasHeight + 316
			Height = -277;
			UpgradeMove = 2;
			isUpgradeScreenUp = false;
			ShowUpgradesButton.SetActive(true);
        }
    }
	
	public void Abrindo()
	{
		BotaoAbrir.interactable = false;	
		BotaoFechar.interactable = false;
		StartCoroutine(DelayAbrindo());
	}
	IEnumerator DelayAbrindo()
	{
		yield return new WaitForSeconds (0.1f);
		BotaoAbrir.interactable = true;
		FecharImage.gameObject.SetActive(true);
		BotaoFechar.interactable = true;
	}
	
	public void Fechando()
	{
		if(UpgradeScripts.isPopUp == false){
			BotaoAbrir.interactable = false;	
			BotaoFechar.interactable = false;
			FecharImage.gameObject.SetActive(false);
			StartCoroutine(DelayFechando());
		}
		
	}
	IEnumerator DelayFechando()
	{
		yield return new WaitForSeconds (0.1f);
		BotaoFechar.interactable = true;
		BotaoAbrir.interactable = true;
	}
}
