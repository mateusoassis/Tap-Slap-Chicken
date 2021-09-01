using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fabrica : MonoBehaviour
{
	public Sprite[] ButtonSprites;
	public SpriteState locked;
	public SpriteState unlocked;
	public Button button;
	public int n;
	
	public LevelHolder levelHolder;
	
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Image>().sprite = ButtonSprites[0];
		button.spriteState = locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(UpgradeScripts.industryUpgrade == false && levelHolder.level > n){
			button.GetComponent<Image>().sprite = ButtonSprites[2];
			button.spriteState = unlocked;
		}
    }
}
