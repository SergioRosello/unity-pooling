﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

	protected static T _instance;
	public static T Instance{
		get {
			if (Instance == null)
			_instance = GameObject.FindObjectOfType<T>().GetComponent<T>();
		return _instance;
		}
	}
}