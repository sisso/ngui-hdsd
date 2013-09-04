using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BuildWindowEditor : EditorWindow {
	[MenuItem("Window/Prepare Build")]
	public static void PrepareBuild() {
		ClearAtlasRef();
		EditorUtils.ForEachScene((string sceneName) => ClearWidgets());
		EditorUtils.ForEachPrefab((GameObject obj) => ClearWidgets());
		
		EditorApplication.OpenScene("Assets/Scenes/SplashScene.unity");
	}
	
	private static void ClearAtlasRef() {
		EditorApplication.NewScene();
		
		var atlasRef = Resources.Load("Atlas/AtlasRef", typeof(UIAtlas)) as UIAtlas;
		atlasRef.replacement = null;
		atlasRef.spriteMaterial = null;
	}
	
	private static bool ClearWidgets() {
		var changed = false;
		var widgets = GameObject.FindObjectsOfType(typeof(UITexture));
		foreach (UITexture w in widgets) {
			Debug.Log("Clear "+w.gameObject.name);
			
			w.material = null;
			w.mainTexture = null;
			changed = true;
		}
		return changed;
	}
}
