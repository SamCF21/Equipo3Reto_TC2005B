using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 10f;

    Vector2 lastClickPos;
    bool move;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            move = true;
        }

        if (move && (Vector2)transform.position != lastClickPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
        }
        else
        {
            move = false;
        }
    }
}
