using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    public void disableIntro()
    {
        GameObject.Find("LevelIntro").SetActive(false);
    }
}
