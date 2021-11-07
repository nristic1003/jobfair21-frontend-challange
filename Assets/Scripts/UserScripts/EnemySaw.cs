using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Platformer.Core.Simulation;

public class EnemySaw : MonoBehaviour
{
    public float speed = 2f;
    public bool moveForward = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.gameObject.GetComponent<Health>().Die();

          }

        }
    
}
