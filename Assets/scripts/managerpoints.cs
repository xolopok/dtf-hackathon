using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerpoints : MonoBehaviour
{
    public int points;
    public Text TextPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddPoints(int x)
    {
        points += x;
        TextPoints.text = "Points: " + points.ToString();
    }
}
