using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickFillBar : MonoBehaviour
{

    public static float temp = 0f;

    public float temptolook;

    public static float cooktemp = 20.0f;
    public static float tempUpgrade;


    public Image thermos;
    public static float payMoney = 10;

    //variaveis pra diminuir temperatura
    public static float timer = 0.5f;
    public static float timerRefresh = 0.5f;

    //variavel pra troca de galinha
    public static float fillAmounter = 0;
	
	//reset da variável à qual o "temp" sempre corre atrás
	public static float tempTo;
	public static bool tempReseted = true;
	public static float tempLerp;
	public float duration = 1.2f;


    // Start is called before the first frame update
	
    void Start()
    {
        thermos = GetComponent<Image>();
        cooktemp = tempUpgrade;
		TempReset();
    }

	public void TempReset()
	{
		tempLerp = 0f;
	}

    // Update is called once per frame
    void Update()   
	{

        // Completa a imagem de temperatura		
		if( temp != tempTo){
			tempLerp += Time.deltaTime / duration;
			temp = (float)Mathf.MoveTowards(temp, tempTo, tempLerp);
		} else if(temp == tempTo){
			TempReset();
			tempReseted = true;
		}
		
		thermos.fillAmount = temp / cooktemp;
        fillAmounter = thermos.fillAmount;
        cooktemp = tempUpgrade;

        //Aumenta o dinheiro
        if(thermos.fillAmount == 1 && !ChickenSpawner.isItGolden)     {
            //ValorDinheiro.money = ValorDinheiro.money + payMoney;
			ValorDinheiro.moneyTo = ValorDinheiro.moneyTo + payMoney;
			tempTo = 0f;
			temp = 0f;
			ValorDinheiro.lerpReseted = false;
        }

        //Dinheiro da Galinha dourada
        if (thermos.fillAmount == 1 && ChickenSpawner.isItGolden)
        {
            //ValorDinheiro.money = ValorDinheiro.money + payMoney;
            ValorDinheiro.moneyTo = ValorDinheiro.moneyTo + 5 * payMoney;
            tempTo = 0f;
            ValorDinheiro.lerpReseted = false;
        }


        timer -= Time.deltaTime;
        if(timer <= 0)  {
            tempTo--;
            timer = timerRefresh;
        }
        temptolook = temp;
    }

}

/*public IEnumerator SmoothTempIncrease()
    {
        while(ClickFillBar.temp <= ClickFillBar.targetTemp){
            ClickFillBar.temp += Time.smoothDeltaTime;
        }
        yield return null;
    }*/
