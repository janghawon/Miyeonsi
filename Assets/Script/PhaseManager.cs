using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public static PhaseManager Instance;
    public bool canNext;

    private BackGroundSystem _bgSystem;
    private CharacterSystem _characterSystem;

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
    }

    [SerializeField] private int _phaseCount = 0;
    [SerializeField] private int _phaseOrderCount = 0;


    public void NextOrder()
    {
        if (!canNext) return;
    }

    public void NextPhase()
    {

    }
}
