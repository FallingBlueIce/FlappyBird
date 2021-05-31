using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SkillEntity 
{
    public PlayerEntity playerEntity;
    public List<ComponentBase> comDic;
    public string SkillName;
    private string comName;
    public string[] Components = new string[] {"null","Animator","Effect" };
    public int index;
    bool foldout;
    private ComponentBase com;
    public SkillEntity (string SkillName, PlayerEntity playerEntity)
    {
        this.playerEntity = playerEntity;
        this.SkillName = SkillName;
        comDic = new List<ComponentBase>();
        index = 0;
        comName = "";
        foldout = false;
        Init();

    }

    private void Init()
    {
        ComponentBase com1 = new AnimatorComponent(playerEntity, this, "动画实例1");
        ComponentBase com2 = new EffectComponent(playerEntity, this, "特效实例1");
        Add(com1);
        Add(com2);
    }

    public void Add(ComponentBase com)
    {
        if(!CheckRepeate(com.comName))
        {
            comDic.Add(com);
        }
    }
    public void Remove(ComponentBase com)
    {
        if(CheckRepeate(com.comName))
        {
            comDic.Remove(com);
        }
    }

    public void OnGui()
    {
        foldout = EditorGUILayout.Foldout(foldout, SkillName);
        if(foldout)
        {
            EditorGUILayout.BeginVertical();
            GUILayout.Space(10);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("技能名字：");
            GUILayout.Label(SkillName);
            if (GUILayout.Button("Delete"))
            {
                playerEntity.RemoveSkill(this);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("添加组件对象:");
            comName = GUILayout.TextField(comName);
            index = EditorGUILayout.Popup(index, Components);
            if (GUILayout.Button("Add"))
            {
                if (comName != "" && index != 0)
                {
                    switch (index)
                    {
                        case 1:
                            com = new AnimatorComponent(playerEntity, this, comName);
                            break;
                        case 2:
                            com = new EffectComponent(playerEntity, this, comName);
                            break;
                        default:
                            break;
                    }
                    Add(com);
                    comName = "";
                    index = 0;
                }
               
            }
            EditorGUILayout.EndHorizontal();
            for (int i = comDic.Count - 1; i >= 0; i--)
            {
                comDic[i].OnGui();
            }

            if (GUILayout.Button("Play"))
            {

                for (int i = comDic.Count - 1; i >= 0; i--)
                {
                    comDic[i].Show();
                }
            }
            GUILayout.Space(10);
            EditorGUILayout.EndVertical();
        }
     
    }

    public bool CheckRepeate(string name)
    {
        for (int i = 0; i < comDic.Count; i++)
        {
            if (comDic[i].comName == name)
                return true;
        }
        return false;
    }
}
