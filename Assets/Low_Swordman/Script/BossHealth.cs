using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

	public int health = 120;

	//public GameObject deathEffect;
	public Slider slider;
	public bool isInvulnerable = false;
	public Animator anim;
	public GameObject vic;

	public ParticleSystem effect;

    private void Start()
    {
		slider.value = health;
    }

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
		slider.value = health;
		
		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{

		ParticleSystem clone = Instantiate(effect, transform.position, Quaternion.Euler(-90 ,0,0));
		clone.Play();
		GetComponent<Animator>().SetTrigger("Die");
		Invoke("victory", 2);

	}

	public void victory()
    {
		vic.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
		Debug.Log("da");
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(20);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(40f * Vector2.up, ForceMode2D.Impulse);

        }
    }






}
