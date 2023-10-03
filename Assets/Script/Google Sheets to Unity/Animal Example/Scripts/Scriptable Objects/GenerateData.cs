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
    public string name;
    public string sentence;
    public Emotion emotion;
    public Clothes clothes;
    public BackGround backGround;
    public BlackPanelActiveType bpat;
    public bool isFadeIn;
    public bool isFadeOut;

    public SendData(List<string> datas)
    {
        name = datas[0];
        sentence = datas[1];

        try
        {
            emotion = (Emotion)Enum.Parse(typeof(Emotion), datas[2]);
        }
        catch
        {
            emotion = Emotion.same;
        }
        try
        {
            clothes = (Clothes)Enum.Parse(typeof(Clothes), datas[3]);
        }
        catch
        {
            clothes = Clothes.same;
        }
        try
        {
            backGround = (BackGround)Enum.Parse(typeof(BackGround), datas[4]);
        }
        catch
        {
            backGround = BackGround.same;
        }
        try
        {
            bpat = (BlackPanelActiveType)Enum.Parse(typeof(BlackPanelActiveType), datas[5]);
            isFadeIn = true;
        }
        catch
        {
            bpat = BlackPanelActiveType.notuse;
            isFadeIn = false;
        }
        try
        {
            isFadeOut = Convert.ToBoolean(Convert.ToInt16(datas[6]));
        }
        catch
        {
            isFadeOut = false;
        }
    }
}

[CreateAssetMenu(menuName = "SO/ChapterData")]
public class GenerateData : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<string> ID = new List<string>();
    public List<SendData> DataList = new List<SendData>();
    public void UpdateStats(List<GSTU_Cell> list, string name)
    {
        List<string> datas = new List<string>();
        for(int i = 1; i < 8; i++)
        {
            datas.Add(list[i].value);
        }
        SendData sendData = new SendData(datas);
        DataList.Add(sendData);
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
        //for(int i = 0; i < MAXSYNTEXID; i++)
        //{
        //    data.ID.Add(i.ToString());
        //}

        foreach (string dataName in data.ID)
            data.UpdateStats(ss.rows[dataName], dataName);
        EditorUtility.SetDirty(target);
    }
}