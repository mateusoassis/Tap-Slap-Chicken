using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMao : MonoBehaviour
{
	public SlapSoundScript SlapSound;
	public Vector2[] touches = new Vector2[5];
	public NuggetScript3 nuggetScripto;
	public ChickenChanger position;
	
	public Canvas canvas;
	public GameObject MaosAqui;
	
    // Start is called before the first frame update
    void Start()
    {
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		MaosAqui = GameObject.Find("MaozinhasAqui");
		SlapSound = FindObjectOfType<SlapSoundScript>(); 
		position = GameObject.FindObjectOfType<ChickenChanger>();
        
    }

    // Update is called once per frame
    void Update()
    {
		SlapSound = FindObjectOfType<SlapSoundScript>(); 
		position = GameObject.FindObjectOfType<ChickenChanger>();
		
        int i = 0;
		while(i < Input.touchCount){
			Touch t = Input.GetTouch(i);
			RaycastHit2D hit;
			if(t.phase == TouchPhase.Began){
				touches[i] = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
				hit = Physics2D.Raycast(touches[i], Vector2.zero);
				if(hit.collider.tag == "Chicken" && UpgradePanel.isUpgradeScreenUp == false && PixChanger.isPixUp == false && SkinChanger.isSkinUp == false && LojaChanger.isLojaUp == false && position.posicao == 1){
					position.Click(Input.GetTouch(i).position);
					SlapSound.TocaTapa();
				} else if(hit.collider.tag == "Nuggeto" && UpgradePanel.isUpgradeScreenUp == false && PixChanger.isPixUp == false && SkinChanger.isSkinUp == false && LojaChanger.isLojaUp == false){
					nuggetScripto.GetNuggeto();
				}
			}
			++i;
		}
    }
}
