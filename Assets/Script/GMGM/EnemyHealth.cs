using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateEnum
{
    chase,
    attack,
    cool,
    die
}

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public EnemyStateEnum currentState;
    [SerializeField] private EnemyInfoSO _enemyInfo;

    private EnemyState[] _states = new EnemyState[3];
    private float _enemyHP;

    private void Awake()
    {
    }

    private void Start()
    {
        currentState = EnemyStateEnum.chase;
    }

    private void Update()
    {
        switch(currentState)
        {

        }
    }
}
