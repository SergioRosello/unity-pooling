using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager> {

	private Dictionary<string, List<GameObject>> pool;
	private Transform poolParent;

	void Awake(){
		pool = new Dictionary<string, List<GameObject>>();
		poolParent = new GameObject("Pool").transform;
	}

	public static void Load(GameObject prefab, int quantity=1){
		Instance.LoadInternal(prefab, quantity);
	}
	private void LoadInternal(GameObject prefab, int quantity=1){
		var goName = prefab.name;

//Si es la primera vez que lo instancia
		if(!pool.ContainsKey(goName)){
			// Crea una lista para este tipo de objetos
			pool[goName] = new List<GameObject>();
		}
		//Crear tantos objetos como quantity
		for (int i = 0; i < quantity; i++){
			var go = Instantiate(prefab);
			go.name = goName;
			// Hacemos que su posicion sea la de la esfera
			go.transform.SetParent(poolParent);
			// Hacemos que el objeto no esté automaticamente activo
			go.SetActive(false);
			// Añadimos el GO a la lista de objetos similares
			pool[goName].Add(go);
		}
	}

	private GameObject SpawnInternal(GameObject prefab){
		if(!pool.ContainsKey(prefab.name) || pool[prefab.name].Count == 0){
			Load(prefab, 1);
		}

		var l = pool[prefab.name];
		var go = l[0];
		l.RemoveAt(0);
		go.SetActive(true);
		go.transform.SetParent(null);
		return go;
	}

	public GameObject Spawn(GameObject prefab){
		return SpawnInternal(prefab);
	}
}
