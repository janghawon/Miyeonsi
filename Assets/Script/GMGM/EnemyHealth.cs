using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    chase,
    attack,
    cool,
    die
}

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyState _currentState;
    [SerializeField] private EnemyInfoSO _enemyInfo;

    private EnemyAttack _enemyAttack;
    private EnemyChase _enemyChase;
    private EnemyDie _enemyDie;

    private float _enemyHP;

    private void Awake()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyChase = GetComponent<EnemyChase>();
        _enemyDie = GetComponent<EnemyDie>();
    }

    private void Start()
    {
        _currentState = EnemyState.chase;
    }


}
