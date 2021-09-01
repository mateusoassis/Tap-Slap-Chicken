using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAll : MonoBehaviour
{
	public WorkerScript[] WorkersArray;
	public UpgradeScripts upgradeScript;
	
    // Start is called before the first frame update
    void Start()
    {
		upgradeScript = GameObject.Find("UpgradeButtons").GetComponent<UpgradeScripts>();
		this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WorkersArray = FindObjectsOfType(typeof(WorkerScript)) as WorkerScript[];
    }
	
	public void CollectAllMoney()
	{
		if(UpgradePanel.isUpgradeScreenUp == false){
			foreach(WorkerScript WorkersArray in WorkersArray){
				WorkersArray.Collect();
			}
		}
	}
}
