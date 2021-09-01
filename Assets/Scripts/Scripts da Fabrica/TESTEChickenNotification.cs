using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTEChickenNotification : MonoBehaviour
{
	public WorkerScript worker;
	public SpriteRenderer renderer;
	
    // Start is called before the first frame update
    void Start()
    {
        worker = gameObject.GetComponentInParent<WorkerScript>();
		renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(worker.ChickenCookeds >= 1){
			renderer.enabled = true;
		} else {
			renderer.enabled = false;
		}
	}
	
	void OnMouseDown()
    {
        if(UpgradePanel.isUpgradeScreenUp == false){
			worker.Collect();
		}
    }
}
