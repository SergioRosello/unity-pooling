using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPooling : MonoBehaviour {

	public GameObject prefab;
	public PoolManager poolManager;
	void Awake(){
		PoolManager.Load(prefab, 10);
		poolManager = GetComponent<PoolManager>();
	}	
	// Update is called once per frame
	void Update () {
		poolManager.Spawn(prefab);	
//		GameObject.Instantiate(prefab);
	}
}
