using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONEYTEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void AddMoneys()
	{
		ValorDinheiro.moneyTo += 2000f;
		ValorDinheiro.lerpReseted = false;
	}

    public void AddDiamondEgg()
    {
        DiamondEggCounter.DECounter += 10;
    }
}
