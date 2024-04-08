using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private float timeBeetweenAnimation;
    private void Update()
    {
       StartCoroutine(TimeBeetweenAnimation());
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    private IEnumerator TimeBeetweenAnimation()
    {
        yield return new WaitForSeconds(timeBeetweenAnimation);
        MoveProjectile() ;
    }
}
