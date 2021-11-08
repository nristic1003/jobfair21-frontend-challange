using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 2;
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
	private float timeBtwAttack = 1.5f;

	public void Attack()
	{
		if(timeBtwAttack < 0)
        {
			Vector3 pos = transform.position;
			pos += transform.right * attackOffset.x;
			pos += transform.up * attackOffset.y;

			Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
			if (colInfo != null)
			{
				GameObject.Find("Player").GetComponent<Health>().Decrement(attackDamage);
			}
			timeBtwAttack = 1.5f;
		}
		
	}



    public void Update()
    {
		timeBtwAttack -= Time.deltaTime;
        if(transform.localScale.x >0f)
        {
			attackOffset = new Vector3(-0.78f, -0.06f, 0);
        }else
        {
			attackOffset = new Vector3(0.78f, -0.06f, 0);
		}
    }



    void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
