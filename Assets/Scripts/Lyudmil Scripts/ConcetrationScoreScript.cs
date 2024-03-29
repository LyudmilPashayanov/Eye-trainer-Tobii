﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcetrationScoreScript : MonoBehaviour {

    // Use this for initialization
    public static float concentrationScore = 10;
    public float timeForMaxPoints = 7;
    public float overallTime = 0;
    public GameObject canvas;
    public Text concentrationText;
    bool once =true;
    public GameObject manager;
    float menuTimer = 0;
    // Update is called once per frame

    void Start()
    {
        this.manager = GameObject.Find("Manager");
        Reset();
    }
    private void Reset()
    {
        
    }
    void Update () {

        if (canvas.activeSelf == false)
        {
            overallTime += Time.deltaTime;
        }
        else
        {
            menuTimer += Time.deltaTime;
            if(menuTimer > 5)
            {
                manager.GetComponent<ManagerController>().BackToMenu();
            }
            if (once)
            {
                
                once = false;
                float temp = getConcentrationScore();
                
                if (temp < 0)
                {
                    concentrationText.text = "Eye Concentration: 0/10";
                    manager.GetComponent<ManagerController>().getConcentration(temp);
                    return;
                }
                concentrationText.text = "Eye Concentration: " + temp.ToString("F2") + "/10";
                manager.GetComponent<ManagerController>().getConcentration(temp);
            }
            
        }
    }

    public float getConcentrationScore()
    {
        if (overallTime < timeForMaxPoints)
        {
            concentrationScore = 10;
        }
        else
        {
            for (float i = 0; i < overallTime - timeForMaxPoints;)
            {
                concentrationScore = concentrationScore - 0.1f;
                i = i + 0.3f;
            }
        }
        return concentrationScore;
    }
}
