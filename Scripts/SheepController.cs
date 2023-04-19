using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    Vector3 target;
    public float movespeed =10;
    public float minx = -6, maxx = 6, miny = -3.5f, maxy = 3.5f;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        movespeed = 10;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);//chuyển từ tọa độ nhấn chuột trên màn hình sang tọa độ thuộc camera
            target = new Vector3(Mathf.Clamp(target.x, minx, maxx), Mathf.Clamp(target.y, miny, maxy), 0);//Mathf.Clamp giới hạn trong phạm vi
        }
        transform.position = Vector3.Lerp(transform.position, target, movespeed * Time.deltaTime);//thay đổi từ vị trí này đến vị trí kia
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().EndGame();
    }
}
