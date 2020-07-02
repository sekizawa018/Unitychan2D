using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCon : MonoBehaviour
{

    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    int score;
    public Stop stop;
    public Text timeLabel;
    public Text scoreLabel;
    public Text stateLabel;
    Scroll[] scrolls;
    float time = 30f;


    // Start is called before the first frame update
    void Start()
    {
        scrolls = GameObject.FindObjectsOfType<Scroll>();
        Ready();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (stop.isTigger()&&state!=State.GameOver)
        {
            foreach(var sc in scrolls)
            {
                sc.enabled = true;
            }
        }
      

        switch (state)
        {
            case State.Ready:
                if (stop.isTigger())
                {
                    stateLabel.enabled = true;
                    Invoke("GameStart",3f);
                    
                }
                break;
            case State.Play:
                if (Input.GetButtonDown("Jump"))
                {
                    score -= 10;
                }
                time -= Time.deltaTime;
                timeLabel.text = "Time : " + (int)time;
                score++;
                scoreLabel.text = "Score : " + score+ "m";
                if (time <=0f)
                {
                    GameOver();
                }
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Jump"))
                {
                    Reload();
                }
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
      
     

        scoreLabel.text = "Score : " + 0;

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready";
    }
    void GameStart()
    {
        state = State.Play;

        timeLabel.enabled = true;
        scoreLabel.enabled = true;
     
      

     

        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }

    void GameOver()
    {
        state = State.GameOver;

       

        //foreach(ScrollObject so in scrollObjects)
        foreach (var so in scrolls)
        {
            so.enabled = false;
        }
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";

    }

    void Reload()
    {
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public  void TimeDamage()
    {
        time -= 3f;
    }
    public void TimeBonus()
    {
        time += 1f;
    }
 
}
