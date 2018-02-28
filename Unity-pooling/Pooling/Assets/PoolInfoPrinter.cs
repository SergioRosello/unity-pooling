using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolInfoPrinter : MonoBehaviour {

	private Text text;
	public string prefabName;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PoolManager.Instance.getInstancesForPrefab(prefabName) != -1)
			text.text = prefabName + " Has: " + PoolManager.Instance.getInstancesForPrefab(prefabName).ToString() + " Instances.";
		else{
			text.text = "none";
		}
	}
}