using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOnItemOpen : MonoBehaviour
{
	public GameObject Itens;
	public GameObject ScrollingOnItemOpen;
	
	public GameObject Position1;
	public GameObject Position2;
	public GameObject Position3;
	
	public Vector3 startPos;
	
	public float tempLerp;
	public float duration;
	
	
	public int state; // 0 = idle, 1 = abre item, 2 = fecha item
	
	void Awake()
	{
		Itens = GameObject.Find("Itens");
		ScrollingOnItemOpen = GameObject.Find("ScrollOnItemOpen");
	}
	
	public void LerpReset()
	{
		tempLerp = 0f;
	}
	
    void Start()
    {
		duration = 0.01f;
		LerpReset();
        startPos = ScrollingOnItemOpen.transform.position;
		/*Itens.transform.position = Position2.transform.position;
		ScrollingOnItemOpen.transform.position = Position1.transform.position;*/
		
		/*Itens.transform.position = Position1.transform.position;
		ScrollingOnItemOpen.transform.position = Position2.transform.position;*/
    }

    // Update is called once per frame
    void Update()
    {
		if(state != 0){
			if(state == 1){
				tempLerp += Time.deltaTime / duration;
				Itens.transform.position = Vector3.MoveTowards(Itens.transform.position, Position2.transform.position, tempLerp);
				ScrollingOnItemOpen.transform.position = Vector3.MoveTowards(ScrollingOnItemOpen.transform.position, Position1.transform.position, tempLerp);
				if(Itens.transform.position == Position2.transform.position && ScrollingOnItemOpen.transform.position == Position1.transform.position){
					state = 0;
				}
			} else if(state == 2){
				tempLerp += Time.deltaTime / duration;
				Itens.transform.position = Vector3.MoveTowards(Itens.transform.position, Position3.transform.position, tempLerp);
				ScrollingOnItemOpen.transform.position = Vector3.MoveTowards(ScrollingOnItemOpen.transform.position, Position2.transform.position, tempLerp);
				if(Itens.transform.position == Position2.transform.position && ScrollingOnItemOpen.transform.position == Position1.transform.position){
					state = 0;
				}
			}
		}
	}
	
	public void OpenItens()
	{
		state = 1;
		LerpReset();
		LojaChanger.isLojaUp = true;
	}
	
	public void CloseItens()
	{
		state = 2;
		LerpReset();
		LojaChanger.isLojaUp = false;
	}
}
