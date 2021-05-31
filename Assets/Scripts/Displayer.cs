using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Spine;
public class Displayer : EditorWindow{
    string[] str = new string[] { "2", "e", "q" };
    static int i;
    [MenuItem("FlappyBird/Displayer")]
    private static void ShowWindow() {
        var window = GetWindow<Displayer>();
        window.titleContent = new GUIContent("Displayer");
        i = 0;
        window.Show();
    }

    [SerializeField]
    List<GameObject> objects = new List<GameObject>();
    protected SerializedObject _serializedObject;
    protected SerializedProperty _assetLstProperty;

    private void OnEnable()
    {        
        _serializedObject = new SerializedObject(this);
        _assetLstProperty = _serializedObject.FindProperty("objects");
    }

    private void OnGUI() {
        EditorGUILayout.PropertyField(_assetLstProperty, new GUIContent("Int Field"), GUILayout.Height(20), GUILayout.Width(300));
        _serializedObject.ApplyModifiedProperties();
        
    }
}
