﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class spcontroller_terrain : MonoBehaviour
{
    public Vector3 value;
    public float mWait;
    public float wait;
    public int counter;
    public float lWait;
    public bool stop;
    public int sWait;
    public GameObject[] collectibles;
    public int collectiblecount;
    int randomcollectible;
    public TextMesh Text;
    private static int palindromeLength;
    private string randomString;
    public int thestringlength;
      public Text palindrometext;
    public int countcollectible;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wSpawn());
        Text = GameObject.Find("Pick Up").GetComponentInChildren<TextMesh>();
        Text.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        wait = Random.Range(lWait, mWait);
        palindromeLength = Random.Range(3, 10);
        spawn();
    }

    IEnumerator wSpawn()
    {
        yield return new WaitForSeconds(sWait);

        while (collectiblecount <= 21)
        {


            randomcollectible = Random.Range(0, 2);

            Vector3 positionofSpawn = new Vector3(Random.Range(-value.x, value.x), 1, Random.Range(-value.z, value.z));
            Instantiate(collectibles[randomcollectible], positionofSpawn + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(wait);
            collectiblecount = collectiblecount + 1;
        }
    }
    public void spawn()
    {
        int randomNumber;
        countcollectible = 0;


        randomNumber = Random.Range(0, 3);
        randomString = "";

        string[] characters = new string[] { "x", "h", "1","(",")"};
        if (countcollectible <= 21)
        {
            if (randomNumber == 2)
            {

                Text.text = "((xh(1)x)hh)";
                countcollectible = countcollectible + 1;
                Text.text = countcollectible.ToString();

            }
            else
            {
                Text.text = GenerateRandomString(characters);
            }
        }
    }


    string GeneratePalindrome(string[] s)
    {
        randomString = "";

        thestringlength = Random.Range(9, 15);

        for (int m = 0; m < thestringlength / 2; m++)
        {
            randomString = randomString + s[Random.Range(0, s.Length)];
        }
        randomString = randomString + new string(randomString.Reverse().ToArray());



        return "(" + randomString + ")";


    }

    string GenerateRandomString(string[] s)
    {
        randomString = "";

        thestringlength = Random.Range(9, 15);

        for (int m = 0; m < thestringlength; m++)
        {
            randomString = randomString + s[Random.Range(0, s.Length)];
        }


        return randomString;

    }

}

