using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeMao : MonoBehaviour
{
	public float x, y;
	public Vector3 shakePos;
	
    // Start is called before the first frame update
    void Start()
    {
        x = 5;
		y = 5;
    }

    // Update is called once per frame
    void Update()
    {
		if(ChickenChanger.maozinha == true){
			shakePos = ChickenChanger.maozinhaPos;
			transform.position = new Vector3(shakePos.x + Random.Range(0,x), shakePos.y + Random.Range(0,y), transform.position.z);
		}
    }
}
