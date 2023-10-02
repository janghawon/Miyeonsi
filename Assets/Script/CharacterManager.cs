using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject _heroineObj;
    private SpriteRenderer _heroineSR;
    [SerializeField] private CTypeSO[] _characterSO;

    private int blushIdx;

    private void Awake()
    {
        _heroineObj = GameObject.Find("Heroine");
        _heroineSR = _heroineObj.GetComponent<SpriteRenderer>();
    }

    public void CharacterSet(Clothes cloth, Emotion emo, bool isBlush)
    {
        blushIdx = isBlush ? 3 : 0;
        _heroineSR.sprite = _characterSO[(int)cloth].Characters[(int)emo + blushIdx];
    }

    public void ShakeCharacter()
    {
        _heroineObj.transform.DOShakePosition(1, 10, 5);
    }

    public void ActiveCharacter(bool isActive)
    {
        _heroineSR.enabled = isActive;
    }
}
