using UnityEngine;

public class BlueBubble : Bubble
{     
    protected override bool BlowCondition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (TargetCheck(touch)) return true;            
        } 
        return false;     
    }          
}
