using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBubble : Bubble
{
    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > base.lifeTime)
            gameObject.SetActive(false);
        if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
        {
            //do
        }
      
    }
}
