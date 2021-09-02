﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class FakeConnectionCheck : ImpostorMod 
{
    [SerializeField]
    private GameObject[] redLeds, greenLeds;
    [SerializeField]
    private TextMesh[] texts;
    private int Case;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            (Ut.RandBool() ? redLeds[i] : greenLeds[i]).SetActive(true);
            var pair = Enumerable.Range(1, 8).ToList().Shuffle(); //Makes sure that the two numbers aren't equal.
            texts[2 * i].text = pair[0].ToString();
            texts[2 * i + 1].text = pair[1].ToString();
        }

        int changedPos = Rnd.Range(0, 8);
        flickerObjs.Add(texts[changedPos].gameObject);
        if (Ut.RandBool())
        {
            int newVal = Ut.RandBool() ? 0 : 9;
            texts[changedPos].text = newVal.ToString();
            Log("there is a {0}", newVal);
        }
        else
        {
            int adjacentPos = changedPos % 2 == 0 ? changedPos + 1 : changedPos - 1;
            texts[changedPos].text = texts[adjacentPos].text;
            flickerObjs.Add(texts[adjacentPos].gameObject);
            Log("there are two numbers that are the same on the same pair");
        }
    }
}