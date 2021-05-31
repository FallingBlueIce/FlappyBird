using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EffectComponent : ComponentBase
{
    //¹Òµã
    private string point;
    private Transform pointTrans;
    private GameObject effect1;
    private GameObject effect2;

    public EffectComponent(PlayerEntity playerEntity, SkillEntity skillEntity, string comName) : base(playerEntity, skillEntity, comName) { }
    public override void Init()
    {
        point = "Point";
        pointTrans = playerEntity.transform.Find(point);
    }
    public override void Show()
    {
        if(effect1!=null)
        {
            if(effect2!=null)
            {
                GameObject.DestroyImmediate(effect2);
                GameObject temp = GameObject.Instantiate(effect1);
                temp.transform.SetParent(pointTrans);
                temp.transform.position = pointTrans.position;
                effect2 = temp;
            }
        }
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

            //ÕâÀïÐ´ÍÏ×§Âß¼­
            //effect1=ÍÏ×§API

            EditorGUILayout.EndHorizontal();
        }
   
    }

}
