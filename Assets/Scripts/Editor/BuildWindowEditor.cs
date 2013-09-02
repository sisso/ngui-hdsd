using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BuildWindowEditor : EditorWindow {
	[MenuItem("Window/Prepare Build")]
	public static void PrepareBuild() {
		ClearAtlasRef();
		PrepareScenes();
		PreparePrefabs();
		
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
		}
	}
	
	private static void PreparePrefabs() {
		foreach(var p in FindPaths(new string[] { "*.prefab" })) {
			EditorApplication.NewScene();
			var prefab = AssetDatabase.LoadMainAssetAtPath(p);
			var obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			var dirt = false;
			
			var widgets = obj.GetComponentsInChildren(typeof(UIWidget));
			foreach (UIWidget w in widgets) {
				w.enabled = false;
				w.enabled = true;
				
				dirt = true;
			}
			
			if (dirt) {
				Debug.Log("Updating "+p);
				PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.Default);
			}
			GameObject.DestroyImmediate(obj);
		}
	}
	
	private static string[] FindPaths(string[] filters) {
 		var paths = new List<string>();    	
 		foreach(var filter in filters) {
			var files = Directory.GetFiles(Application.dataPath, filter, SearchOption.AllDirectories);
			foreach(var f in files) {
				paths.Add(NormalizeDataPath(f));
			}
		}
		return paths.ToArray();
	}
	
	private static string NormalizeDataPath(string path) {
		var normalizedPath = "Assets" + path.Replace(Application.dataPath, "").Replace('\\', '/');
		return normalizedPath;
	}
}
