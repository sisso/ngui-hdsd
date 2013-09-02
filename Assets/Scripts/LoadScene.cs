using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public float waitTime = 5f;
	public string sceneName;
	
	void Start () {
		Invoke("LoadNow", waitTime);	
	}
	
	void LoadNow() {
		Application.LoadLevel(sceneName);
	}
}
