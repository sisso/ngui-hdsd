using UnityEngine;
using UnityEditor;
using System.Collections;

public class BuildWindowEditor : EditorWindow {
	[MenuItem("Window/Prepare Build")]
	public static void PrepareBuild() {
		ClearAtlasRef();
		PrepareScenes();
		
		EditorApplication.OpenScene("Assets/Scenes/SplashScene.unity");
	}
	
	private static void ClearAtlasRef() {
		EditorApplication.NewScene();
		
		var atlasRef = Resources.Load("Atlas/AtlasRef", typeof(UIAtlas)) as UIAtlas;
		atlasRef.replacement = null;
		atlasRef.spriteMaterial = null;
	}
	
	private static void PrepareScenes() {
		EditorApplication.OpenScene("Assets/Scenes/FirstScene.unity");
		ClearWidgets();
		EditorApplication.SaveScene();
		
		EditorApplication.OpenScene("Assets/Scenes/SecondScene.unity");
		ClearWidgets();
		EditorApplication.SaveScene();
	}
	
	private static void ClearWidgets() {
		var widgets = GameObject.FindObjectsOfType(typeof(UIWidget));
		foreach (UIWidget w in widgets) {
			w.enabled = false;
			w.enabled = true;
			w.gameObject.SetActive(false);
			w.gameObject.SetActive(true);
		}
	}
}
