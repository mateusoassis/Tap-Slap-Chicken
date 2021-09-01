using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPronto : MonoBehaviour
{
	// 4 idle pronto > 5 slap pronto
	const int STATE_IDLEPRONTO = 4;
	const int STATE_SLAPPRONTO = 5;
	private Animator animator;
	
	int currentAnimationState = STATE_IDLEPRONTO;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ChickenChanger.maozinha == true){
			changeState (STATE_SLAPPRONTO);
		} else {
			changeState (STATE_IDLEPRONTO);
		}
    }
	
	void changeState (int ProntoState){
		if (currentAnimationState == ProntoState)
			return;
		
		switch (ProntoState) {
			
		case STATE_IDLEPRONTO:
			animator.SetInteger ("ProntoState", STATE_IDLEPRONTO);
			break;
			
		case STATE_SLAPPRONTO:
			animator.SetInteger ("ProntoState", STATE_SLAPPRONTO);
			break;			
		}
		
		currentAnimationState = ProntoState;
		
	}
}
