using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBubble : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] float minDeltaPosition;
    
    private float timer = 0;
    Vector2 startPosition;
    Vector2 deltaPosition;
    private void Update()
    {
        BlowCondition();
        TimerCheck();
    }

    private void BlowCondition()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (TargetCheck(touch))
            {
                if (touch.phase == TouchPhase.Began) startPosition = touch.position;
                deltaPosition = touch.position - startPosition;
                if (deltaPosition.magnitude >= minDeltaPosition) ConditionReached();
            }
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
    private void ResetCondition()
    {
        
        
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
