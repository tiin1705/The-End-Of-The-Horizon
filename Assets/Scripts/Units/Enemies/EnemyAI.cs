using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Enemy: MonoBehaviour
{   private enum State
    {
        Roaming,
        Attacking
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Transform player;
    private float detectionRange = 2f;
    private float attackRange = 0.1f;

    private float attackCooldown = 1f;
    private float attackTimer;

    private IEnumerator roamingCoroutine;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        roamingCoroutine = RoamingRoutine();
        StartCoroutine(RoamingRoutine());
    }
   
    private IEnumerator RoamingRoutine()
    {
        while(state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    
}
