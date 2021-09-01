using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCru : MonoBehaviour
{
	// 0 idle cru > 1 slap cru
	const int STATE_IDLECRU = 0;
	const int STATE_SLAPCRU = 1;
	private Animator animator;
	
	int currentAnimationState = STATE_IDLECRU;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ChickenChanger.maozinha == true){
			changeState (STATE_SLAPCRU);
		} else {
			changeState (STATE_IDLECRU);
		}
    }
	
	//troca de animação
	void changeState (int CruState){
		if (currentAnimationState == CruState)
			return;
		
		switch (CruState) {
			
		case STATE_IDLECRU:
			animator.SetInteger ("CruState", STATE_IDLECRU);
			break;
			
		case STATE_SLAPCRU:
			animator.SetInteger ("CruState", STATE_SLAPCRU);
			break;			
		}
		
		currentAnimationState = CruState;
		
	}
}
