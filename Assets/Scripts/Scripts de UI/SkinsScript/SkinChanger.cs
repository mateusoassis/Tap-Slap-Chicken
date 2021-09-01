using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
	public static bool isSkinUp;
	public Button OpenButton;
	public Button CloseButton;
	
    // Start is called before the first frame update
	
    void Start()
    {
		CloseButton.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
		isSkinUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OpenSkin()
	{
		isSkinUp = true;
		CloseButton.gameObject.SetActive(true);
		this.gameObject.SetActive(true);
	}
	
	public void CloseSkin()
	{
		isSkinUp = false;
		CloseButton.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
	}
}
