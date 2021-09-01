using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void RiseHeater()
    {
        ClickFillBar.timer = 1;
		if(ClickFillBar.temp > 0){
			ClickFillBar.temp++;
		} else if(ClickFillBar.temp <= 0){
				ClickFillBar.temp = 1;
		}
    }
}
