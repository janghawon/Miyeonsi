using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backGroundSR;
    [SerializeField] private Sprite[] _backGrounds;

    [Header("블랙 패널")]
    [SerializeField] private SpriteRenderer _blackPanel;
    [SerializeField] private float _activeTime;
    [SerializeField] private float _waitTime;
    [SerializeField] private Vector2 _bPanelRWaitPos;
    [SerializeField] private Vector2 _bPanelUpWaitPos;

    private void Start()
    {
        _blackPanel.enabled = false;
    }

    public void SetBackGround(BackGround bg)
    {
        _backGroundSR.sprite = _backGrounds[(int)bg];
    }

    public void BlackPanelActive(BlackPanelActiveType bpat)
    {

    }
}
