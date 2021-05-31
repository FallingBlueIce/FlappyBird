using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// 动画组件
/// </summary>
public class AnimatorComponent : ComponentBase
{
    public string skillName;
    private AnimatorStateInfo info;

    private string[] animatorName = new string[] { "null", "attack1", "attack2", "die", "run", "sk_attack1", "sk_attack2", "stand", "win", "win_idle" };
    private int index;
    public AnimatorComponent(PlayerEntity playerEntity, SkillEntity skillEntity, string comName) : base(playerEntity, skillEntity, comName) { }

    public override void Init()
    {
        index = 0;
    }

    public override void Show()
    {
        //Spine播放动画
        
    }

    public override void OnGui()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(20);
        foldout = EditorGUILayout.Foldout(foldout, comName);
        EditorGUILayout.EndHorizontal();
        if (foldout)
        {
            base.OnGui();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(20);
            index = EditorGUILayout.Popup("动画", index, animatorName);
            EditorGUILayout.EndHorizontal();
        }
       
       
    }
}
