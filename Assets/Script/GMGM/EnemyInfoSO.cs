using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySO")]
public class EnemyInfoSO : ScriptableObject
{
    public float enemyHP;
    public float enemyAtk;
    public float enemyAtkCool;
}
