using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EnemyType
{
    Common,
    Elite,
    Boss
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("Common")]
    [SerializeField] public EnemyType enemyType;
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public GameObject targetPrefab;

    [Header("Stats")]
    public int enemyHealth;
    public int enemyDamage;
    public int enemyDefense;
    public float enemyAtkSpeed;
    public float enemyMoveSpeed;


}
