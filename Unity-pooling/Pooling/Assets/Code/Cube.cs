using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
	private Rigidbody rb;
	private MeshRenderer meshRenderer;


	void Awake(){
		rb = GetComponent<Rigidbody>();
		meshRenderer = GetComponent<MeshRenderer>();
	}

	// Use this for initialization
	void Start () {
		meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
		rb.AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized * Random.Range(5f, 10f), ForceMode.Impulse);
		rb.AddTorque(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)).normalized * Random.Range(5f, 10f), ForceMode.Impulse);
		Destroy(gameObject, 5);
		
	}
}
