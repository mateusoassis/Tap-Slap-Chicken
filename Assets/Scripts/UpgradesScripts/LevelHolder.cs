using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelHolder : MonoBehaviour
{
	public int level = 1;
	public float totalExp;
	public static float totalExpTo;
	public float[] LevelExp;
	public TextMeshProUGUI LevelText;
	public Image ExpBar;
	public static float tempLerp;
	public float duration = 1f;
	public float somaNiveisAnteriores;
	public bool barFull;
	
	void Awake()
	{
		if(PlayerPrefs.HasKey("level")){
			level = PlayerPrefs.GetInt("level");
		} else {
			level = 1;
		}
		if(PlayerPrefs.HasKey("totalExpTo")){
			totalExpTo = PlayerPrefs.GetFloat("totalExpTo");
			totalExp = totalExpTo;
		} else {
			totalExpTo = 0f;
			totalExp = totalExpTo;
		}
		if(PlayerPrefs.HasKey("somaNiveisAnteriores")){
			somaNiveisAnteriores = PlayerPrefs.GetFloat("somaNiveisAnteriores");
		} else {
			somaNiveisAnteriores = 0f;
		}
	}
	
    void Start()
    {
		LevelText.SetText(level.ToString());
    }

    void Update()
    {
		LevelText.SetText(level.ToString());
		HandleLevelText();
		PlayerPrefs.SetFloat("totalExpTo", totalExpTo);
		
		if(totalExp != totalExpTo){
			tempLerp += Time.deltaTime / duration;
			totalExp = (float)Mathf.MoveTowards(totalExp, totalExpTo, 2.5f * tempLerp);
		} else if(totalExp == totalExpTo){
			LerpReset();
		}
        if(level == 1)
        {
            ExpBar.fillAmount = (totalExp) / (LevelExp[level]);
        }
		if(level > 1)
        {
            ExpBar.fillAmount = (totalExp - LevelExp[level-1]) / (LevelExp[level]-LevelExp[level-1]);
        }
		
		if((totalExpTo - somaNiveisAnteriores) == LevelExp[level]){
			barFull = true;
		}
    }
	
	public void HandleLevelText()
	{
		if(totalExp >= LevelExp[level] && level < 7){
			level++;
			PlayerPrefs.SetFloat("level", level);
			StartCoroutine("UpdateLevel");
		} 
	}
	
	public void LerpReset()
	{
		tempLerp = 0f;
	}
	
	public IEnumerator UpdateLevel()
	{
		if(barFull){
			somaNiveisAnteriores += LevelExp[level-1];
			PlayerPrefs.SetFloat("somaNiveisAnteriores", somaNiveisAnteriores);
			barFull = false;
		}
		yield return new WaitForSeconds(0.1f);
		LevelText.SetText(level.ToString());
	}
	
	public void Exp10Plus() // botão
	{
		LerpReset();
		totalExpTo += 10f;
		PlayerPrefs.SetFloat("totalExpTo", totalExpTo);       
	}


}
