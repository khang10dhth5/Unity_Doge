using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BommController : MonoBehaviour
{
    public Vector3 targetboom;
    public float movespeed = 5;
    public GameObject explor;
  
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);//hủy đối tượng sau 2s
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate((transform.position - targetboom) * movespeed * Time.deltaTime*-1);
        transform.position = Vector3.Lerp(transform.position, targetboom, movespeed * Time.deltaTime*0.7f);
    }
    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        else
        {
            GameObject exl = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
            Destroy(exl, 0.5f);
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            
             Destroy(gameObject);
        }
    }
}
