using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TxtCoin : MonoBehaviour
{
    Text text;
    public int coincount;
    void Awake()
    {
       text = GetComponent<Text>();
    }
    
    
    void Update()
    {
        text.text = coincount.ToString();
    }
}
