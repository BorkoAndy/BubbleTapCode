using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlueBubble : MonoBehaviour
{
    public static Action OnBubbleBlows;
    private float timer = 0;
    [SerializeField] private float lifetime;
    

   

    private void Update()
    {
        BlowCondition();
        TimerCheck();
    }
    private void BlowCondition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (TargetCheck(touch)) ConditionReached();
            //Touch touch = Input.GetTouch(0);
            //Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //RaycastHit hit;
        }       
    }

    private void TimerCheck()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
            gameObject.SetActive(false);
    }
    private void ConditionReached()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
    }
    private bool TargetCheck(Touch touch)
    {
        
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject)
            return true;
        else return false;
    }

}
