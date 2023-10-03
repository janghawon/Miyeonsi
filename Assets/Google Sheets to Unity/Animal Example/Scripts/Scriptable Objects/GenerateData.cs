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

[System.Serializable]
public class SendData
{
    private string ID;
    public string name;
    public string sentence;
    public Emotion emotion;
    public Clothes clothes;
    public BackGround backGround;
    public BlackPanelActiveType bpat;
    public bool isFadeIn;
    public bool isFadeOut;

    SendData(string _id, string _name, string _sen, string _emo, string _clo,
             string _bg, string _bpat)
    {

    }
}

public class GenerateData : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<string> ID = new List<string>();
    public List<SendData> DataList = new List<SendData>();
    public void UpdateStats(List<GSTU_Cell> list, string name)
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
        foreach (string dataName in data.ID)
            data.UpdateStats(ss.rows[dataName], dataName);
        EditorUtility.SetDirty(target);
    }
}