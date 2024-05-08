using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float moveSpeed;
    public float minY;
    public float maxY;

    private float oldPosition;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 10;
        moveSpeed = 3;
        minY = -1;
        maxY = 1;
             
    }


    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("ResetWall"))
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);

    }
    public void Wallstop()
    {
        moveSpeed = 0;
    }
}
