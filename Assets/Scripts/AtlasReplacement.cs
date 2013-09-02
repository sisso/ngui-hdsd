using UnityEngine;
using System.Collections;

public class AtlasReplacement : MonoBehaviour {
	private bool wasNone = false;
	
	private UIAtlas atlasRef;
	
	void Awake() {
		Debug.Log("Switching atlas to SD");
		
		atlasRef = Resources.Load("Atlas/AtlasRef", typeof(UIAtlas)) as UIAtlas;
		wasNone = atlasRef.replacement == null;
		
		var sdAtlas = Resources.Load("Atlas/AtlasSd", typeof(UIAtlas)) as UIAtlas;
		atlasRef.replacement = sdAtlas;
		
		GameObject.DontDestroyOnLoad(gameObject);
	}
	
#if UNITY_EDITOR
	void OnDestroy() {
		if (wasNone) {
			Debug.Log("Switching atlas back to none");
			
			atlasRef.replacement = null;
			atlasRef.spriteMaterial = null;
		} else {
			Debug.Log("Switching atlas back to hd");
			
			var hdAtlas = Resources.Load("Atlas/AtlasHd", typeof(UIAtlas)) as UIAtlas;
			atlasRef.replacement = hdAtlas;
		}
	}
#endif
}