using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenColor : MonoBehaviour
{
    //public Color cookedPoint;
	public float lowerChicken;
	public float higherChicken;
	
    public Renderer cru;
	public Color cruColor;
	
	public Renderer quase;
	public Color quaseColor;
	
	public Renderer pronto;
	public Color prontoColor;

    public ChickenChanger chicken;

    // Start is called before the first frame update
    void Start()
    {
        //cookedPoint = render.material.color;

        chicken = GetComponentInParent<ChickenChanger>();

    }

    // Update is called once per frame
    void Update()
    {
        if(chicken.posicao == 1)
        {
			if(ClickFillBar.temp/ClickFillBar.tempUpgrade <= 0.5f && ClickFillBar.temp >= 0.0f){
				cruColor.a = 1.0f - (ClickFillBar.temp / (ClickFillBar.tempUpgrade/2));
				quaseColor.a = 1.0f;
				prontoColor.a = 1.0f;				
			} else if (ClickFillBar.temp/ClickFillBar.tempUpgrade > 0.5f){
				cruColor.a = 0.0f;
				quaseColor.a = 1.0f - ((ClickFillBar.temp - (ClickFillBar.tempUpgrade/2)) / (ClickFillBar.tempUpgrade/2));
				prontoColor.a = 1.0f;
			}
			
			cru.material.color = cruColor;
			quase.material.color = quaseColor;
			pronto.material.color = prontoColor;
            //cookedPoint.a = ClickFillBar.temp / ClickFillBar.cooktemp;
            //render.material.color = cookedPoint;
        }
    }
}
