using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValorDinheiro : MonoBehaviour
{
    public static float money;
	public static float moneyTo;
    int moneyInt;
	public float duration = 0.4f;
	public float lerp = 0f;
	public static bool lerpReseted = true;
    public TextMeshProUGUI MoneyCounter;
    
    // Start is called before the first frame update
	
	void Awake()
	{
		if(PlayerPrefs.HasKey("money")){
			money = PlayerPrefs.GetFloat("money");
			moneyTo = PlayerPrefs.GetFloat("money");
		} else {
			money = 0f;
			moneyTo = 0f;
		}
	}
	
    void Start()
    {
        MoneyCounter = GetComponent<TextMeshProUGUI>();
    }
	
	public void LerpReset()
	{
		lerp = 0f;
		lerpReseted = true;
	}
	
	public void ChangeMoney()
	{
		
	}

    // Update is called once per frame
    void Update()
    {
		if( money != moneyTo && lerpReseted == false){
			lerp += Time.deltaTime / duration;
			money = (int)Mathf.MoveTowards(money, moneyTo, 5 * lerp);
		} else if(money == moneyTo){
			LerpReset();
		}
        moneyInt = Mathf.RoundToInt(money);
        MoneyCounter.text = /*(Mathf.RoundToInt())*/FormatNumber(moneyInt).ToString();
		
		PlayerPrefs.SetFloat("money", ValorDinheiro.moneyTo);
    }


    
    static string FormatNumber(int num) {
    if(num >= 1000000000)
    {
        return FormatNumber(num / 1000) + "B";
    }
    if(num >= 1000000)
    {
        return FormatNumber(num / 1000) + "M";
    }
    if (num >= 100000)
        return FormatNumber(num / 1000) + "K";
    if (num >= 10000) {
        return (num / 1000D).ToString("0.#") + "K";
    }
    return num.ToString("#,0");
    }
    
}
