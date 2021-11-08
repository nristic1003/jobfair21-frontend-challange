using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            GameObject.Find("swordMan").GetComponent<BossHealth>().TakeDamage(30);
        }
    }
}
