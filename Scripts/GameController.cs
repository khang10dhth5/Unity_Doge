using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panelEnd;
    public Text txtPoint;
    public Text txtEndPoint;
    public float point;
    public bool isEndGame;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        Time.timeScale = 1;
        panelEnd.SetActive(false);
        isEndGame = false;
        audio = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        
        SceneManager.LoadScene(0);
    }
    public void GetPoint()
    {
        point++;
        txtPoint.text = "Point: " + point.ToString();
    }
    public void EndGame()
    {
        txtEndPoint.text = "Your Point: " + point.ToString();
        audio.Play();
        isEndGame = true;
        Time.timeScale = 2;
        Time.timeScale = 0;
        panelEnd.SetActive(true);
    }
}
