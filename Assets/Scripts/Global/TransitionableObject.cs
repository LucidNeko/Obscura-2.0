using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransitionableObject : MonoBehaviour {

	private static List<GameObject> objects = new List<GameObject>();

	public static GameObject[] GetAll {
		get { return objects.ToArray(); }
	}

	// Use this for initialization
	void Start () {
		objects.Add (gameObject);
	}

}
