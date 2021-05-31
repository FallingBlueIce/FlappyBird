using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public List<SkillEntity> skillDic;
    public string skillName;

    //spine动画控制器
    public PlayerEntity()
    {
        skillDic = new List<SkillEntity>();

    }
    public void AddSkill(string skillName)
    {
        if (!CheckRepeate(skillName))
        {
            SkillEntity skillEntity = new SkillEntity(skillName, this);
            skillDic.Add(skillEntity);
        }
        else
            Debug.LogError("技能名字重复！！");


    }
    public void RemoveSkill(SkillEntity skill)
    {
        if (CheckRepeate(skill.SkillName))
        {
            skillDic.Remove(skill);
        }
    }
    public void OnGui()
    {

        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("添加技能对象:");
        skillName = GUILayout.TextField(skillName);
        if (GUILayout.Button("New"))
        {
            if (skillName != "")
            {
                AddSkill(skillName);
                skillName = "";
            }
        }
        EditorGUILayout.EndHorizontal();
        for (int i = skillDic.Count-1; i >=0 ; i--)
        {
            skillDic[i].OnGui();
        }
        EditorGUILayout.EndVertical();
    }
    public bool CheckRepeate(string name)
    {
        for (int i = 0; i < skillDic.Count; i++)
        {
            if (skillDic[i].SkillName == name)
                return true;
        }
        return false;
    }


}
