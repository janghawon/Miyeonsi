using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backGroundSR;
    [SerializeField] private Sprite[] _backGrounds;

    [Header("블랙 패널")]
    [SerializeField] private SpriteRenderer _blackPanel;
    private Transform _blackPanleTrm;
    [SerializeField] private float _activeTime;
    [SerializeField] private Vector2 _bPanelRWaitPos;
    [SerializeField] private Vector2 _bPanelUpWaitPos;
    [SerializeField] private Vector2 _bPanelLEndPos;

    private BlackPanelActiveType _saveBPAT;

    private void Start()
    {
        _blackPanel.enabled = false;
        _blackPanleTrm = _blackPanel.transform;
    }

    public void SetBackGround(BackGround bg)
    {
        _backGroundSR.sprite = _backGrounds[(int)bg];
    }

    public void BlackPanelActive(BlackPanelActiveType bpat)
    {
        if (_blackPanel.enabled)
        {
            Debug.LogError("[BlackPanel] has already activation");
            return;
        }

        _saveBPAT = bpat;
        _blackPanel.color = new Color(0, 0, 0, 1);
        StartCoroutine(BlackPanelActiveCo(bpat));
    }

    public void RemoveBlackPanel()
    {
        StartCoroutine(BlackPanelRemoveCo());
    }

    IEnumerator BlackPanelActiveCo(BlackPanelActiveType bpat)
    {
        PhaseManager.Instance.canNext = false;
        switch (bpat)
        {
            case BlackPanelActiveType.up_down:
                {
                    _blackPanleTrm.position = _bPanelUpWaitPos;
                    _blackPanel.enabled = true;
                    _blackPanleTrm.DOMoveY(0, _activeTime);
                    yield return new WaitForSeconds(_activeTime);
                    PhaseManager.Instance.NextOrder();
                }
                break;
            case BlackPanelActiveType.up_down_bounce:
                {
                    _blackPanleTrm.position = _bPanelUpWaitPos;
                    _blackPanel.enabled = true;
                    _blackPanleTrm.DOMoveY(0, _activeTime).SetEase(Ease.OutBounce);
                    yield return new WaitForSeconds(_activeTime);
                    PhaseManager.Instance.NextOrder();
                    
                }
                break;
            case BlackPanelActiveType.right:
                {
                    _blackPanleTrm.position = _bPanelUpWaitPos;
                    _blackPanel.enabled = true;
                    _blackPanleTrm.DOMoveY(0, _activeTime);
                    yield return new WaitForSeconds(_activeTime);
                    PhaseManager.Instance.NextOrder();
                    
                }
                break;
            case BlackPanelActiveType.right_left:
                {
                    _blackPanleTrm.position = _bPanelUpWaitPos;
                    _blackPanel.enabled = true;
                    _blackPanleTrm.DOMoveY(0, _activeTime);
                    yield return new WaitForSeconds(_activeTime);
                    PhaseManager.Instance.NextOrder();
                    
                }
                break;
            case BlackPanelActiveType.none:
                {
                    _blackPanel.color = new Color(0, 0, 0, 0);
                    _blackPanleTrm.position = Vector3.zero;
                    _blackPanel.enabled = true;
                    _blackPanel.DOFade(1, _activeTime);
                    yield return new WaitForSeconds(_activeTime);
                    PhaseManager.Instance.NextOrder();
                }
                break;
        }
    }

    IEnumerator BlackPanelRemoveCo()
    {
        PhaseManager.Instance.canNext = false;
        if (_saveBPAT == BlackPanelActiveType.right_left)
        {
            _blackPanleTrm.DOMoveY(_bPanelLEndPos.x, _activeTime);
        }
        else
        {
            _blackPanel.DOFade(0, _activeTime);
        }
        yield return new WaitForSeconds(_activeTime);
        PhaseManager.Instance.canNext = true;
        _blackPanel.enabled = false;
    }
}
