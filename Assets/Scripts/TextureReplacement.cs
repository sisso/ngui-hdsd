using UnityEngine;
using System.Collections;

public class TextureReplacement : MonoBehaviour {
	public string sdPath;
	
	void Awake() {
		GetComponent<UITexture>().mainTexture = Resources.Load(sdPath, typeof(Texture2D)) as Texture2D;
	}
}
