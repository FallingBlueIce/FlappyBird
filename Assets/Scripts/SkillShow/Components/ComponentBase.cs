using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/// <summary>
/// �������Ч������
/// </summary>
public class ComponentBase
{
    public PlayerEntity playerEntity;
    public string comName;
    public SkillEntity skillEntity;
    public bool foldout;
    public ComponentBase(PlayerEntity playerEntity, SkillEntity skillEntity, string comName)
    {
        foldout = true;
        this.playerEntity = playerEntity;
        this.comName = comName;
        this.skillEntity = skillEntity;
    }
    //��ʼ�����
    public virtual void Init() { }

    //�����Editor��ʾ
    public virtual void OnGui()
    {

        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(20);
        EditorGUILayout.LabelField("�������:");
        EditorGUILayout.LabelField(comName);
        if (GUILayout.Button("Delete"))
            skillEntity.Remove(this);
        EditorGUILayout.EndHorizontal();

    }

    //�������ʵ���߼�
    public virtual void Show() { }
}
