using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBubble : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float maxTimeBetweenTaps;

    private float timer = 0;
    private float tapTimer;
    private bool tapMade;

    public static Action OnBubbleBlows;

   

    private void BlowCondition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (TargetCheck(touch))
            {
                if (tapMade && tapTimer < maxTimeBetweenTaps) ConditionReached();


                if (touch.phase == TouchPhase.Ended) tapMade = true;                    
            }     
        }            
    }

    private void Update()
    {
        BlowCondition();
        TimerCheck();

        if (tapMade) tapTimer += Time.deltaTime;

        if (tapTimer >= maxTimeBetweenTaps) ResetCondition();
    }
   
    private void ResetCondition()
    {
        tapMade = false;
        tapTimer = 0;
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
