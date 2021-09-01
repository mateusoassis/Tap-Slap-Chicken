using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaScript : MonoBehaviour
{
	public GameObject mapa, fabrica;
	public CameraChanger changeCamera;

	void Start()
	{
		changeCamera = GameObject.Find("Main Camera").GetComponent<CameraChanger>();
	}

	void OnMouseDown()
	{
		changeCamera.ChangeToWorkers();
		mapa.gameObject.SetActive(false);
		fabrica.gameObject.SetActive(true);
	}

}
