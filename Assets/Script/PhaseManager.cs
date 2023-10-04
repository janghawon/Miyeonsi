using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager Instance;
    public bool canNext;

    private BackGroundSystem _bgSystem;
    private CharacterSystem _characterSystem;
    private DialogueSystem _dialogueSystem;

    [SerializeField] private GenerateData[] _chapterData;
    private GenerateData _selectData;
    private bool _isBlushSave;

    [SerializeField] private Emotion _saveEmo;
    private Clothes _saveCloth;
    private BackGround _saveBg;

    [SerializeField] private int _phaseCount = 0;
    [SerializeField] private int _phaseOrderCount = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("?!?!");
            return;
        }
        Instance = this;
        _bgSystem = GameObject.Find("BackGroundManager").GetComponent<BackGroundSystem>();
        _characterSystem = GameObject.Find("CharacterManager").GetComponent<CharacterSystem>();
        _dialogueSystem = GameObject.Find("Uitoolkit").GetComponent<DialogueSystem>();
    }

    private void Start()
    {
        NextPhase();
        NextOrder();
    }

    public void NextOrder()
    {
        if (!canNext) return;
        SendData sd = _selectData.DataList[_phaseOrderCount];
        _dialogueSystem.SetText(sd.name, sd.sentence);

        if (sd.isBlush != -1 && Convert.ToBoolean(sd.isBlush) != _isBlushSave)
            _isBlushSave = Convert.ToBoolean(sd.isBlush);

        if (sd.emotion != Emotion.same)
        {
            _saveEmo = sd.emotion;
        }
            
        if (sd.clothes != Clothes.same)
        {
            _saveCloth = sd.clothes;
        }
            
        if (sd.backGround != BackGround.same)
        {
            _saveBg = sd.backGround;
        }

        _characterSystem.CharacterSet(_saveCloth, _saveEmo, _isBlushSave);
        _bgSystem.SetBackGround(_saveBg);

        if (sd.isFadeIn)
            _bgSystem.BlackPanelActive(sd.bpat);
        if (sd.isFadeOut)
            _bgSystem.RemoveBlackPanel();
        _characterSystem.ActiveCharacter(sd.isActiveCharacter);
        if (sd.isCharacterShake)
            _characterSystem.ShakeCharacter();
        
        _phaseOrderCount++;
    }

    public void NextPhase()
    {
        _selectData = _chapterData[_phaseCount];
        _phaseCount++;
    }
}
