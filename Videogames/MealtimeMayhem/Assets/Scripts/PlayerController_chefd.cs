using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_chefd : MonoBehaviour
{
    //Initiate rigidbody for player
    private Rigidbody2D rigid;

    [SerializeField]
    private float speed; //controls character´s speed only for this script
    // Start is called before the first frame update
    void Start()
    {
        //takes the component which is the rigidbody
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis(""));
    }
}
