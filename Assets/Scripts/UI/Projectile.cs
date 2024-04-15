using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    private WeaponInfo weaponInfo;
    private Vector3 startPostition;

    private void Start()
    {
        startPostition = transform.position;
    }
    private void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }

    private void DetectFireDistance()
    {
        if(Vector3.Distance(transform.position, startPostition) > weaponInfo.weaponRange)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateWeaponInfo(WeaponInfo weaponInfo)
    {
        this.weaponInfo = weaponInfo; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHeath enemyHeath = collision.gameObject.GetComponent<EnemyHeath>();
        Indestructible indestructible = collision.gameObject.GetComponent<Indestructible>();

        if(!collision.isTrigger && (enemyHeath || indestructible))
        {
           enemyHeath.TakeDamage(weaponInfo.weaponDamage);
            Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

   

}
