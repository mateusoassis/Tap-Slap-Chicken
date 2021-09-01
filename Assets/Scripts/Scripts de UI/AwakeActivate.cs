using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeActivate : MonoBehaviour
{
	public GameObject PixBG;
	public GameObject PixClose;
	public GameObject SkinBG;
	public GameObject SkinClose;
	public GameObject LojaBG;
	public GameObject LojaClose;
	
    // Start is called before the first frame update
	void Awake()
	{
		PixBG.gameObject.SetActive(true);
		PixClose.gameObject.SetActive(true);
		SkinBG.gameObject.SetActive(true);
		SkinClose.gameObject.SetActive(true);
		LojaBG.gameObject.SetActive(true);
		LojaClose.gameObject.SetActive(true);
		
		PixChanger.isPixUp = false;
		SkinChanger.isSkinUp = false;
		LojaChanger.isLojaUp = false;
	}
	
    void Start()
    {
        
		
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
