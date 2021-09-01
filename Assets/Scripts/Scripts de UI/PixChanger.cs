using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixChanger : MonoBehaviour
{
	public Vector3 maxScale = new Vector3(1f,1f,1f); // aberto
	public Vector3 minScale = new Vector3(0.001f, 0.001f, 1f); // fechado
	public Vector3 scaleTarget = new Vector3(0.001f,0.001f,1f); // atual
	public float speed;
	public int state = 0;
	public static bool isPixUp;
	public Button OpenButton;
	public Button CloseButton;
	
	
    // Start is called before the first frame update
	
    void Start()
    {
        maxScale = new Vector3(1f,1f,1f);
		minScale = new Vector3(0.001f, 0.001f, 1f);
		OpenButton = GameObject.Find("LojaButton").GetComponent<Button>();
		CloseButton = GameObject.Find("FechaLojaButton").GetComponent<Button>();
		CloseButton.interactable = false;
		CloseButton.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
		isPixUp = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(state != 0){
			if(state == 1){
				transform.localScale = Vector3.Lerp(transform.localScale, maxScale, speed * Time.deltaTime);
				if(transform.localScale.x >= 0.99f && transform.localScale.y >= 0.99f){
					transform.localScale = new Vector3(1f,1f,1f);
					state = 0;
					CloseButton.interactable = true;
					OpenButton.interactable = false;
				}
			} else if(state == 2){
				transform.localScale = Vector3.Lerp(transform.localScale, minScale, speed * Time.deltaTime);
				if(transform.localScale.x <= 0.01f && transform.localScale.y <= 0.01f){
					transform.localScale = new Vector3(0.001f,0.001f,0.001f);
					state = 0;
					this.gameObject.SetActive(false);
					isPixUp = false;
					OpenButton.interactable = true;
					CloseButton.gameObject.SetActive(false);
				}
			}
		}
    }
	
	public void OpenPix()
	{
		this.gameObject.SetActive(true);
		state = 1;
		isPixUp = true;
		CloseButton.gameObject.SetActive(true);
		CloseButton.interactable = false;
	}
	
	public void ClosePix()
	{
		state = 2;
	}
}
