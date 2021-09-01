using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level2 : MonoBehaviour
{
	public LevelHolder levelHolder;
	public Image thisObject;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if(levelHolder.level > 1){
			thisObject.enabled = true;
		} else {
			thisObject.enabled = false;
		}
    }
}
