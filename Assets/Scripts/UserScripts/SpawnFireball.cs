using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour
{


    public GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawn");
    }

    private IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        Instantiate(fireball, transform.position, Quaternion.Euler(0,0,-90));
        StartCoroutine("spawn");
    }
}
