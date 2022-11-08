using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBubble : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float minTapTime;
    private float timer = 0;
    private bool tapMade;
    private float tapTimer;
    
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

            if (TargetCheck(touch)) tapMade = true;
           
            if (touch.phase == TouchPhase.Ended && tapTimer < minTapTime) ResetCondition();
        }
        else tapMade = false;

        if (tapMade) tapTimer += Time.deltaTime;

        if (tapTimer >= minTapTime) ConditionReached();
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
    private void ResetCondition()
    {
        tapMade = false;
        tapTimer = 0;
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
