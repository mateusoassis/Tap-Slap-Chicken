using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationQuase : MonoBehaviour
{
	// 2 idle quase > 3 slap quase
	const int STATE_IDLEQUASE = 2;
	const int STATE_SLAPQUASE = 3;
	private Animator animator;
	
	int currentAnimationState = STATE_IDLEQUASE;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if(ChickenChanger.maozinha == true){
			changeState (STATE_SLAPQUASE);
		} else {
			changeState (STATE_IDLEQUASE);
		}
    }
	
	void changeState (int QuaseState){
		if (currentAnimationState == QuaseState)
			return;
		
		switch (QuaseState) {
			
		case STATE_IDLEQUASE:
			animator.SetInteger ("QuaseState", STATE_IDLEQUASE);
			break;
			
		case STATE_SLAPQUASE:
			animator.SetInteger ("QuaseState", STATE_SLAPQUASE);
			break;			
		}
		
		currentAnimationState = QuaseState;
		
	}
}
