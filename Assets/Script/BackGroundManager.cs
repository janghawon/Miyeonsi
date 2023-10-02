using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backGroundSR;
    [SerializeField] private SpriteRenderer _blackPanel;
    [SerializeField] private Sprite[] _backGrounds;
    
    public void SetBackGround(BackGround bg)
    {
        _backGroundSR.sprite = _backGrounds[(int)bg];
    }
}
