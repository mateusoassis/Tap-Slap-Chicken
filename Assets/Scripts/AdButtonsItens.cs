using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AdButtonsItens : MonoBehaviour
{
	public Image thisObject;
	public DateTime current;
	public DateTime tomorrow;
	
	private int activeOrNot = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        thisObject = GetComponent<Image>();
		
		
		/*DateTime startTime = DateTime.Now; 
		DateTime endTime = DateTime.Now.AddSeconds( 75 );  
		TimeSpan span = endTime.Subtract ( startTime ); 
		Debug.Log( "Time Difference (seconds): " + span.Seconds ); 
		Debug.Log( "Time Difference (minutes): " + span.Minutes ); 
		Debug.Log( "Time Difference (hours): " + span.Hours ); 
		Debug.Log( "Time Difference (days): " + span.Days );*/
		
		//current = DateTime.Now; // current time
		//tomorrow = current.AddDays(1).Date - current; // this is the "next" midnight
    }

    // Update is called once per frame
    void Update()
    {
		//PUXAR PLAYERPREFS
		if(PlayerPrefs.HasKey("ad"+this.gameObject.name)){
			activeOrNot = PlayerPrefs.GetInt("ad"+this.gameObject.name);
		}
		
		//SETAR VARIÁVEL ACTIVEORNOT
		
		//THISOBJECT ATIVO SE ACTIVEORNOT 0 OU 1
		if(activeOrNot == 1){
			thisObject.enabled = true;
		} else {
			thisObject.enabled = false;
		}
		
		
    }
}
