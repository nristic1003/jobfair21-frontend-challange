using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public static bool cutSceneOn = false;
    public Animator cam;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            cutSceneOn = true;
            cam.SetBool("cutscene0", true);
            GameObject.Find("swordMan").GetComponent<Rigidbody2D>().isKinematic = false;
           GameObject.Find("swordMan").GetComponent<Animator>().SetTrigger("intro");
            GameObject.Find("Player").GetComponent<PlayerController>().controlEnabled = false ;
            Invoke(nameof(stopCutScene), 3f);
        }
    }

    void stopCutScene()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().controlEnabled = true;
        GameObject.Find("swordMan").GetComponent<Animator>().SetTrigger("startRun");
        cutSceneOn = false;
        cam.SetBool("cutscene0", false);
        Destroy(gameObject);
    }
}
