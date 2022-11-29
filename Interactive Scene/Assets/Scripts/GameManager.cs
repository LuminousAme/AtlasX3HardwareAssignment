using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float maxTime;
    float remainingTime;

    [SerializeField] int goal;
    int score;

    [SerializeField] TMP_Text remainingTimeText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text goalText;

    bool b0, b1; //green is b0, blue is b1, I think

    bool displayany, displayblue, displaygreen;

    [SerializeField] GameObject blueCircle, greenCircle;
    float timeSinceDisplay;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = maxTime;
        goalText.text = "Goal: " + goal.ToString();
        score = 0;
        b0 = false;
        b1 = false;
        displayany = false;
        displayblue = false;
        displaygreen = false;
        timeSinceDisplay = 0f;
        blueCircle.SetActive(false);
        greenCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime <= 0f)
        {
            PersistantScore.score = score;
            if(score >= goal)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }


        scoreText.text = "Score: " + score.ToString();

        int mins = TimeSpan.FromSeconds(remainingTime).Minutes;
        int secs = TimeSpan.FromSeconds(remainingTime).Seconds;
        remainingTimeText.text = mins.ToString() + ":" + secs.ToString();

        if(InputSystem.instance != null)
        {
            b0 = InputSystem.instance.ReadButton(0);
            b1 = InputSystem.instance.ReadButton(1);

            if(displayblue && b1 && !b0)
            {
                GetPoint();
            }
            else if (displaygreen && b0 && !b1)
            {
                GetPoint();
            }
            else if (!displayany && !b0 && !b1 && timeSinceDisplay > 1f)
            {
                DisplayNew();
            }
        }

        remainingTime -= Time.deltaTime;
        timeSinceDisplay += Time.deltaTime;
    }

    void GetPoint()
    {
        blueCircle.SetActive(false);
        greenCircle.SetActive(false);
        displayblue = false;
        displaygreen = false;
        displayany = false;

        timeSinceDisplay = 0f;
        score++;
    }

    void DisplayNew()
    {
        int rand = UnityEngine.Random.Range(0, 2);
        if(rand == 0)
        {
            displayany = true;
            displayblue = true;
            blueCircle.SetActive(true);
        }
        else if (rand == 1)
        {
            displayany = true;
            displaygreen = true;
            greenCircle.SetActive(true);
        }
    }
}
