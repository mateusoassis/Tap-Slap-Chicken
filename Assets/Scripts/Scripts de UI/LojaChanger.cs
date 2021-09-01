using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojaChanger : MonoBehaviour
{
	public static bool isLojaUp;
	public Button OpenButton;
	public Button CloseButton;
	
    // Start is called before the first frame update

	void Awake()
	{
		CloseButton.gameObject.SetActive(true);
		OpenButton = GameObject.Find("LojaButton").GetComponent<Button>();
		CloseButton = GameObject.Find("FecharLojaButton").GetComponent<Button>();
	}

    void Start()
    {
		CloseButton.gameObject.SetActive(false);
		this.gameObject.SetActive(true);
		isLojaUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OpenLoja()
	{
		isLojaUp = true;
		CloseButton.gameObject.SetActive(true);
		this.gameObject.SetActive(true);
	}
	
	public void CloseLoja()
	{
		isLojaUp = false;
		CloseButton.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
	}
}
