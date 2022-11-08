using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Bubble : MonoBehaviour
{
     private float timer = 0;
    [SerializeField] private float lifetime;

    private void Update()
    {
        BlowCondition();
        TimerCheck();
    }

    private void BlowCondition()
    {
        //if(Input.touchcount > 0)
        //Touch touch = Input.GetTouch(0)
        //if (TargetCheck(touch))
        //Depends on bubble color
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
