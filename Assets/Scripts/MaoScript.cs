using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoScript : MonoBehaviour
{
    // 0 idle cru > 1 slap cru
	const int STATE_IDLE = 0;
	const int STATE_SLAP = 1;
	private Animator animator;
	
	public int currentAnimationState = STATE_IDLE;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ChickenChanger.maozinha == true){
			changeState (STATE_SLAP);
		} else {
			changeState (STATE_IDLE);
		}
    }
	
	//troca de animação
	void changeState (int stateMao){
		if (currentAnimationState == stateMao)
			return;
		
		switch (stateMao) {
			
		case STATE_IDLE:
			animator.SetInteger ("stateMao", STATE_IDLE);
			break;
			
		case STATE_SLAP:
			animator.SetInteger ("stateMao", STATE_SLAP);
			break;			
		}
		
		currentAnimationState = stateMao;
		
	}
}
