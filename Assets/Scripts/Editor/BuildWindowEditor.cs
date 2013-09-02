using UnityEngine;
using UnityEditor;
using System.Collections;

public class BuildWindowEditor : EditorWindow {
	[MenuItem("Window/Prepare Build")]
	public static void PrepareBuild() {
		EditorApplication.NewScene();
		
		var atlasRef = Resources.Load("Atlas/AtlasRef", typeof(UIAtlas)) as UIAtlas;
		atlasRef.replacement = null;
		atlasRef.spriteMaterial = null;
	}
}
