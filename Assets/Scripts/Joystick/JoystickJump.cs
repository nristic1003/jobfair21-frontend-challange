using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickJump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("Player").GetComponent<PlayerController>().buttonPressed = false;
    }
}
