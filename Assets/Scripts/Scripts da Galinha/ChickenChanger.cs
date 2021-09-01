using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickenChanger : MonoBehaviour
{
	// 0 idle cru > 1 slap cru
	// 2 idle quase > 3 slap quase
	// 4 idle pronto > 5 slap pronto
	
	public Transform spawner;
	public Transform centro;
	public Transform saida;
	
	public float moveSpeed;
	
	public int posicao;

    public SlapSoundScript slapSound;
	
	/* aqui é pra spawnar a mãozinha, temporizador com as duas primeiras, booleano pra controlar
	 quando void update vai usar a função "Maozinha"
	 o vector3 para gravar ONDE apertou NA GALINHA
	 transform para tirá-la de cena após a "animação/aparição"*/

 
	public float timerMao = 0.15f;
	public float resetMao = 0.15f;
	public static bool maozinha = false;
	public static Vector3 maozinhaPos;
	
	public SlapSoundScript SlapSound;
	public Vector2[] touches = new Vector2[5];
	public NuggetScript3 nuggetScripto;
	
	public GameObject[] maozinhaPrefab;
	
	public Canvas canvas;
	public GameObject MaosAqui;
	
    // Start is called before the first frame update
    void Start()
    {
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		MaosAqui = GameObject.Find("MaozinhasAqui");
		SlapSound = GetComponent<SlapSoundScript>();
		posicao++;
		
		spawner = GameObject.Find("Posição 1").GetComponent<Transform>();
		centro = GameObject.Find("Posição 2").GetComponent<Transform>();
		saida = GameObject.Find("Posição 3").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {	
		
		int i = 0;
		while(i < Input.touchCount){
			Touch t = Input.GetTouch(i);
			RaycastHit2D hit;
			if(t.phase == TouchPhase.Began){
				touches[i] = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
				hit = Physics2D.Raycast(touches[i], Vector2.zero);
				if(hit.collider.tag == "Chicken" && UpgradePanel.isUpgradeScreenUp == false && PixChanger.isPixUp == false && SkinChanger.isSkinUp == false && LojaChanger.isLojaUp == false && posicao == 1){
					Click(Input.GetTouch(i).position);
					SlapSound.TocaTapa();
				} else if(hit.collider.tag == "Nuggeto" && UpgradePanel.isUpgradeScreenUp == false && PixChanger.isPixUp == false && SkinChanger.isSkinUp == false && LojaChanger.isLojaUp == false){
					nuggetScripto.GetNuggeto();
				}
			}
			++i;
		}
		
		
		
		if (maozinha == true){
			Maozinha();
		}
		
		if (posicao == 0)
            {
                transform.position = spawner.position;
            }
		else if(posicao == 1)
            {
                transform.position = Vector2.Lerp(transform.position, centro.position, Time.deltaTime * moveSpeed);
            } 
		else if (posicao == 2)
            {
                transform.position = Vector2.Lerp(transform.position, saida.position, Time.deltaTime * moveSpeed);
            }
		if (ClickFillBar.fillAmounter == 1)
        {
			if (posicao == 0)
			{
				 posicao = 1;
			}
			else if(posicao == 1)
			{
				posicao = 2;
			}
            else if (posicao == 2)
            {
                posicao = 0;
            }
        }
		if(NuggetSpawnScript.nuggetAround == true){
			nuggetScripto = GameObject.Find("NuggetCenter(Clone)").GetComponentInChildren<NuggetScript3>();
		}
    }
	
	/*public void OnMouseDown()
	{
        if (UpgradePanel.isUpgradeScreenUp == false && PixChanger.isPixUp == false && SkinChanger.isSkinUp == false && LojaChanger.isLojaUp == false && posicao == 1){
            Click();
		}
	}*/
	
	void Maozinha()
	{
		//spawn da mão
		//mao.position = maozinhaPos;
		
		//temporizador para desativar a "aparição" da mão ( até termos a animação kkkk )
		if (timerMao <= 0){
			maozinha = false;
			timerMao = resetMao;
			//mao.position = maozinhaOut.position;
		} else {
			timerMao -= Time.deltaTime;
		}
	}
	
	public void Click(Vector3 pos)
	{
		maozinha = true;
		Vector3 nowPos = new Vector3(pos.x /*- (canvas.GetComponent<RectTransform>().rect.width/2)*/, pos.y /*- (canvas.GetComponent<RectTransform>().rect.height/2)*/, 0f);
		//maozinhaPos = pos;
		timerMao = resetMao;
		
		//if(posicao == 1){
			
		//}
		var myNewHand = Instantiate(maozinhaPrefab[Random.Range(0,2)], nowPos, transform.rotation);
		myNewHand.transform.SetParent(canvas.transform, true);
		ClickFillBar.timer = ClickFillBar.timerRefresh;

		if(ClickFillBar.tempTo > 0){

            ClickFillBar.tempTo++;
			ClickFillBar.tempReseted = false;

        } else if(ClickFillBar.tempTo <= 0){
			ClickFillBar.tempTo = 1;
			ClickFillBar.tempReseted = false;
		}


    }

}
