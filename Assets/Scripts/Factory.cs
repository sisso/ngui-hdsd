using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {
	public GameObject prefab;
	
	void Start () {
		NGUITools.AddChild(gameObject, prefab);
	}
}
