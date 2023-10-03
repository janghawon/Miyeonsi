using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class GenerateData : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<string> Names = new List<string>();
    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i].value);
        }
    }
}

[CustomEditor(typeof(GenerateData))]
public class DataEditor : Editor
{
    GenerateData data;

    void OnEnable()
    {
        data = (GenerateData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Label("Read Data Examples");

        if (GUILayout.Button("Pull Data Method One"))
        {
            UpdateStats(UpdateMethodOne);
        }
    }

    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
    }

    void UpdateMethodOne(GstuSpreadSheet ss)
    {
        //data.UpdateStats(ss.rows["Jim"]);
        foreach (string dataName in data.Names)
            data.UpdateStats(ss.rows[dataName], dataName);
        EditorUtility.SetDirty(target);
    }
    
}