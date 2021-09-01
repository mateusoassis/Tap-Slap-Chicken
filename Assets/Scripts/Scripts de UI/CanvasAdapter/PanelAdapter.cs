using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAdapter : MonoBehaviour
{
	public Canvas UICanvas;
	public RectTransform rt;
	public GameObject panel;
	public float height;
	public float width;
	public Vector3 canvasPosition;
	public Vector3 sum;
	public float Ratio;
	public float WidthSize;
	public float NewWidthMultiplier;
	
	public float x, y, z;
	
    void Awake()
	{
		height = UICanvas.GetComponent<RectTransform>().rect.height;
		width = UICanvas.GetComponent<RectTransform>().rect.width;
		Ratio = width/height;
		
		WidthSize = 2270f * Ratio;
		NewWidthMultiplier = WidthSize / 1080f;
		
		sum = new Vector3(this.transform.localScale.x * NewWidthMultiplier * 1080f * x, 0f * y, 0f * z);
		
		this.GetComponent<RectTransform>().localPosition = Vector3.zero + sum;
		this.transform.localScale = new Vector3(this.transform.localScale.x * NewWidthMultiplier, this.transform.localScale.y, this.transform.localScale.z);
	}
	
    void Start()
    {		
		this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
