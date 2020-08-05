using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_controller_terrain : MonoBehaviour
{
    public float speed;
    TextMesh t;
    //public Text countText1;
    public Text palin;
    public Text countText;
    private int count;
    private Rigidbody rb;
    private AudioSource source;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        t = GameObject.Find("Pick Up").GetComponentInChildren<TextMesh>();
        string palString = t.text;

        bool flg = AreParenthesisBalanced(palString);
        
        if (flg.Equals(true)){
            Debug.Log("Collected");
            count = count + 1;
            palin.text ="Collected collectibles:" + count.ToString();
            source.Play();
        }

       /* if (flg.Equals(true) && other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            palin.text = "eaten palindrom:" + count.ToString();
            SetCountText();
            source.Play();


        }*/
    }

    private static bool IsMatchingPair(char character1, char character2)
    {
        return character1 == '(' && character2 == ')';
    }
    private bool AreParenthesisBalanced(string exp)
    {
        var stack = new Stack<char>();

        for (int i = 0; i < exp.Length; i++)
        {
            switch (exp[i])
            {
                case '(':
                    stack.Push(exp[i]);
                    break;
                case ')' when stack.Count == 0:
                case ')' when !IsMatchingPair(stack.Pop(), exp[i]):
                    return false;
            }

        }
        return stack.Count == 0;
    }
    void SetCountText()
    {
        countText.text = "Count Text: " + count.ToString();

        if (count >= 10)
        {

            
            countText.text = "collected ";
        }

    }




}

