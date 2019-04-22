﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MenuItemController : MonoBehaviour
{
    private GazeAware _gazeAware;
    private GameObject _manager;
    private float startingScaleX;
    private float startingScaleZ;

    public GameObject puzzle;

    void Start()
    {
        this._gazeAware = GetComponent<GazeAware>();
        this._manager = GameObject.Find("Manager");
        this.startingScaleX = this.gameObject.transform.localScale.x;
        this.startingScaleZ = this.gameObject.transform.localScale.z;
    }

    void Update()
    {
        //this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + Time.deltaTime * 10, this.gameObject.transform.localScale.y + Time.deltaTime * 10, this.gameObject.transform.localScale.z + Time.deltaTime * 10);
        if (this._gazeAware.HasGazeFocus)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + Time.deltaTime * 10, 150, this.gameObject.transform.localScale.z + Time.deltaTime * 5);
        }
        else if (!this._gazeAware.HasGazeFocus && this.gameObject.transform.localScale.x > this.startingScaleX)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x - Time.deltaTime * 10, 150, this.gameObject.transform.localScale.z - Time.deltaTime * 5);
        }

        if (this.gameObject.transform.localScale.x > 170)
        {
            gameObject.transform.localScale.Set(startingScaleX,150,startingScaleZ);
            this.StartPuzzle();
        }
    }

    private void StartPuzzle()
    {
        this._manager.GetComponent<ManagerController>().StartPuzzle(puzzle);
    }
}