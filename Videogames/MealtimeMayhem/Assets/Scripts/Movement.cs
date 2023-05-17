using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.1f;
    private Transform target;
    private Animator anim;
    private bool isClicked = true;
    private enum animaciones {idle, running};
    animaciones state;

    void Start(){
        anim=GetComponent<Animator>();
    }

    void Update(){
        if (isClicked = true){
            mover();
            state = animaciones.running;
            anim.SetInteger("state", (int)state);
        }
    }

    void mover(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null){
                target = hit.transform;
            }
        }

        if (target != null){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}