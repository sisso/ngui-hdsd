using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using System.IO;

public class EditorUtils {
	public static void ForEachScene(Func<string, bool> closure) {
		foreach (var p in FindPaths(new string[] { "*.unity" })) {
			EditorApplication.OpenScene(p);
			var save = closure(p);
			if (save) EditorApplication.SaveScene();
		}
	}
	
	public static void ForEachPrefab(Func<GameObject, bool> closure) {
	EditorApplication.NewScene();
	foreach (var p in FindPaths(new string[] { "*.prefab" })) {
			var prefab = AssetDatabase.LoadMainAssetAtPath(p);
			var obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			var save = closure(obj);
			if (save) PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.Default);
			GameObject.DestroyImmediate(obj);
		}
	}
	
	public static string[] FindPaths(string[] filters) {
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
