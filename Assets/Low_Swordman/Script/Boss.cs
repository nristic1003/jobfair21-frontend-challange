using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{

	public GameObject player;

	public GameObject c;


	public bool isFlipped = false;


	public void showBossHealth()
    {
		c.SetActive(true);
    }

	public void LookAtPlayer()
	{

		Transform t = player.transform;
		Vector3 flipped = transform.localScale;
		flipped.x *= -1f;

		if (transform.position.x > t.position.x && isFlipped)
		{
			transform.localScale = flipped;
			isFlipped = false;
		}
		else if (transform.position.x < t.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			isFlipped = true;
		}
	}

}
