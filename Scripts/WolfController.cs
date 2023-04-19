using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public GameObject boom;
    public float minBoomTime = 2, maxBoomTime=4;
    private float lastBoomTime = 0, boomTime = 0;
    private GameObject sheep;
    private Animator amin;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBoomTime();
        sheep = GameObject.FindGameObjectWithTag("Player");
        amin = gameObject.GetComponent<Animator>();
        amin.SetBool("isBoom", false);
        if(gameController==null)
            gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBoomTime + boomTime - 0.5f)
        {
            amin.SetBool("isBoom", true);

        }
        if (Time.time>=lastBoomTime+boomTime)
        {
            ThroughBoom();

        }
    }
    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }
    void ThroughBoom()
    {
        GameObject bom= Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
        bom.GetComponent<BommController>().targetboom = sheep.transform.position;
        gameController.GetComponent<GameController>().GetPoint();
        UpdateBoomTime();
        amin.SetBool("isBoom", false);
    }
}
