using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSizeAdapter : MonoBehaviour
{

    public SpriteRenderer MainScreen;
	public RectTransform baseCanvas;
	
	public float CanvasWidth;
	public float WidthMultiplier;
	public float CanvasHeight;
	public float HeightMultiplier;
	
	//public SpriteRenderer MainSprite;
	//public SpriteRenderer IndustrySprite;
	
	public GameObject Backgrounds;
	public GameObject WorkerArray;
	public GameObject Worker1;
	public GameObject Worker2;
	public GameObject Worker3;
	public GameObject Worker4;
	public GameObject Worker5;
	public GameObject Worker6;
	public GameObject Worker7;
	public GameObject Worker8;
	public GameObject Worker9;
	public GameObject Worker10;
	public GameObject Worker11;
	public GameObject Worker12;
	public GameObject Worker13;
	public GameObject Worker14;
	public GameObject Worker15;
	
	public GameObject bgItens;
	

    // Start is called before the first frame update
    void Start()
    {
		//MainSprite = GameObject.Find("FabricaBG").GetComponent<SpriteRenderer>();
		//IndustrySprite = GameObject.Find("bg1").GetComponent<SpriteRenderer>();
		Backgrounds = GameObject.Find("BGs");
		WorkerArray = GameObject.Find("WorkerArray");
		bgItens = GameObject.Find("bgItens");
		
        //float orthoSize = MainScreen.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = 11.34f;
		
		CanvasWidth = baseCanvas.rect.width;
		CanvasHeight = baseCanvas.rect.height;
		WidthMultiplier = CanvasWidth/1080.0f;
		HeightMultiplier = CanvasHeight/2270.0f;
		
		//MainSprite.transform.localScale = new Vector3(WidthMultiplier, HeightMultiplier, 1.0f);
		//IndustrySprite.transform.localScale = new Vector3(WidthMultiplier, HeightMultiplier, 1.0f);
		Backgrounds.transform.localScale = new Vector3(WidthMultiplier, HeightMultiplier, 1.0f);
		//WorkerArray.transform.localScale = new Vector3(WidthMultiplier, HeightMultiplier, 1.0f);
		
		Worker1.transform.position = new Vector3(Worker1.transform.position.x * WidthMultiplier, Worker1.transform.position.y, Worker1.transform.position.z);
		Worker2.transform.position = new Vector3(Worker2.transform.position.x * WidthMultiplier, Worker2.transform.position.y, Worker2.transform.position.z);
		Worker3.transform.position = new Vector3(Worker3.transform.position.x * WidthMultiplier, Worker3.transform.position.y, Worker3.transform.position.z);
		Worker4.transform.position = new Vector3(Worker4.transform.position.x * WidthMultiplier, Worker4.transform.position.y, Worker4.transform.position.z);
		Worker5.transform.position = new Vector3(Worker5.transform.position.x * WidthMultiplier, Worker5.transform.position.y, Worker5.transform.position.z);
		Worker6.transform.position = new Vector3(Worker6.transform.position.x * WidthMultiplier, Worker6.transform.position.y, Worker6.transform.position.z);
		Worker7.transform.position = new Vector3(Worker7.transform.position.x * WidthMultiplier, Worker7.transform.position.y, Worker7.transform.position.z);
		Worker8.transform.position = new Vector3(Worker8.transform.position.x * WidthMultiplier, Worker8.transform.position.y, Worker8.transform.position.z);
		Worker9.transform.position = new Vector3(Worker9.transform.position.x * WidthMultiplier, Worker9.transform.position.y, Worker9.transform.position.z);
		Worker10.transform.position = new Vector3(Worker10.transform.position.x * WidthMultiplier, Worker10.transform.position.y, Worker10.transform.position.z);
		Worker11.transform.position = new Vector3(Worker11.transform.position.x * WidthMultiplier, Worker11.transform.position.y, Worker11.transform.position.z);
		Worker12.transform.position = new Vector3(Worker12.transform.position.x * WidthMultiplier, Worker12.transform.position.y, Worker12.transform.position.z);
		Worker13.transform.position = new Vector3(Worker13.transform.position.x * WidthMultiplier, Worker13.transform.position.y, Worker13.transform.position.z);
		Worker14.transform.position = new Vector3(Worker14.transform.position.x * WidthMultiplier, Worker14.transform.position.y, Worker14.transform.position.z);
		Worker15.transform.position = new Vector3(Worker15.transform.position.x * WidthMultiplier, Worker15.transform.position.y, Worker15.transform.position.z);
    }

}
