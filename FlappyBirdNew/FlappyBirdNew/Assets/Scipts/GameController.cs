using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame = false;
    bool isStartFirstTime;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;
    public Button btnExit;
    public GameObject BGmove;
    public GameObject wallMove;
    //public Sprite btnIdle;
    //public Sprite btnHover;
    //public Sprite btnClick;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButton(0) && isStartFirstTime)
            {
                //Time.timeScale = 1;
                //isEndGame = false;
                //Load lai man choi
                StartGame();
            }
        }
        else
        {           
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1;
                
            }
        }
       

    }

   
    public void GetPoint()
    {       
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
        
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);        
    }

    public void Restart()
    {
        StartGame();
    }
    public void doExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
    
    public void EndGame()
    {
        //Debug.Log("EndGame");
        isEndGame = true;
        isStartFirstTime = false;
        //Time.timeScale = 0;
        BGmove.GetComponent<BGmove>().BGstop();
        Component[] wall;
        wall = wallMove.GetComponentsInChildren<WallMove>();
        foreach(WallMove _wallstop in wall)
        {
            _wallstop.Wallstop();
        }
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your Point: " + gamePoint.ToString();
    }
}
