using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SkillEditor : EditorWindow
{
    public static List<string> RoleNames;
    private static int index;
    private GameObject player;
    PlayerEntity entity;
    static bool  foldout;
    [MenuItem("Kit/ShowSkillEditor")]
    public static void Open()
    {
        foldout = false;
        var editorPlatform = GetWindow<SkillEditor>();
        index = 0;
        editorPlatform.position = new Rect(
            Screen.width / 2,
            Screen.height * 2 / 3,
            600,
            500
        );
        RoleNames = new List<string>();
        GetAllNames();
        editorPlatform.Show();
    }

    private static void GetAllNames()
    {
        RoleNames.Add("1");
        RoleNames.Add("2");
        RoleNames.Add("3");
    }

    public void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        index = EditorGUILayout.Popup("Ñ¡È¡½ÇÉ«", index, RoleNames.ToArray());
        if (GUILayout.Button("New"))
        {
            if (player != null)
            {
                GameObject.DestroyImmediate(player);
            }
            player = GameObject.Instantiate(Resources.Load<GameObject>(RoleNames[index]));
            entity = player.AddComponent<PlayerEntity>();
        }
        EditorGUILayout.EndHorizontal();
        EditorShowSkill();
        EditorGUILayout.EndVertical();
    }

    private void EditorShowSkill()
    {
        if (entity != null)
            entity.OnGui();
    }
}
