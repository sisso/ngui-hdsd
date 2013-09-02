using UnityEngine;
using System.Collections;

public class AtlasReplacement : MonoBehaviour {
	public UIAtlas atlasRef;
	
	public string pathAtlasSd;
	
	public bool sd = true;
	
	void Awake() {
		var sdAtlas = Resources.Load(pathAtlasSd, typeof(UIAtlas)) as UIAtlas;
		atlasRef.replacement = sdAtlas;
	}
}