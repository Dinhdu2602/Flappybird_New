using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGmove : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;

    private Vector3 oldPosition;
    private GameObject obj;
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;

        moveRange = 17.7f;
        moveSpeed = 4;
    }
    void Update()
    {
        //transform.position = new Vector3(( transform.position.x - 1)* Time.deltaTime, transform.position.y ,0);
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, transform.position.y, 0));

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
    public void BGstop()
    {
        moveSpeed = 0;
    }
}
