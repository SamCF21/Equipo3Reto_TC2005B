using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeMaster : MonoBehaviour
{
    private SpriteRenderer head;
    private SpriteRenderer eyes;
    private GameObject left;
    private GameObject right;
    private GameObject ven;
    private GameObject usa;
    private GameObject mex;
    private VarMaster varMaster;
    private int nat = 1;

    void Start(){
        head = GameObject.Find("Head").GetComponent<SpriteRenderer>();
        eyes = GameObject.Find("Eyes").GetComponent<SpriteRenderer>();
        ven = GameObject.Find("Venezuela");
        usa = GameObject.Find("USA");
        mex = GameObject.Find("México");
        left = GameObject.Find("Left");
        right = GameObject.Find("Right");
        varMaster = GameObject.FindObjectOfType<VarMaster>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            BodyColorChanger();
            EyeColorChanger();
            NationalityChanger();
        }

        ven.SetActive(false);
        usa.SetActive(false);
        mex.SetActive(false);

        switch (nat){
            case 1:
                ven.SetActive(true);
                break;
            case 2:
                mex.SetActive(true);
                break;
            case 3:
                usa.SetActive(true);
                break;
        }

        varMaster.nat = nat;
    }

    void BodyColorChanger(){
        int layerMask = 1 << LayerMask.NameToLayer("UI");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null){
            SpriteRenderer renderer = hit.collider.GetComponent<SpriteRenderer>();
            if (renderer != null){
                head.color = renderer.color;
                varMaster.headColor = head.color;
            }
        }
    }

    void EyeColorChanger(){
        int layerMask = 1 << LayerMask.NameToLayer("Tiles");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null){
            SpriteRenderer renderer = hit.collider.GetComponent<SpriteRenderer>();
            if (renderer != null){
                eyes.color = renderer.color;
                varMaster.eyeColor = eyes.color;
                Debug.Log(eyes.color);
            }
        }
    }

    void NationalityChanger(){
        int layerMask = 1 << LayerMask.NameToLayer("Characters");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null){
            if (hit.collider.gameObject.name == "Left"){
                nat -= 1;
                if (nat < 1){
                    nat = 3;
                }
            }
            else if (hit.collider.gameObject.name == "Right"){
                nat += 1;
                if (nat > 3){
                    nat = 1;
                }
            }
        }
    }
}