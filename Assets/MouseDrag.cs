using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    bool isDown = false;
    private void Update()
    {
        if(isDown)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = (pos);
        }
     

    }
    void OnMouseDown()
    {
        isDown = true;
    }
    private void OnMouseUp()
    {
        isDown = false;
    }
}
