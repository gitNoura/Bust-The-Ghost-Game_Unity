using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProbabilityText : MonoBehaviour{
    public Game clicked;
    public TextMeshPro probability;
    public double probabilitycount = 0; 
    
    void Start(){
        clicked = FindObjectOfType(typeof(Game)) as Game;
        probabilitycount = 0.012;
    }

    // Update is called once per frame
    void Update(){   
        CalculateBayesianProbability(clicked.lastClickedX, clicked.lastClickedY, clicked.GhostX, clicked.GhostY);
        probability.text =  probabilitycount.ToString();
    }
   
    void CalculateBayesianProbability(int lastClickedX, int lastClickedY, int GhostX, int GhostY){
        probabilitycount= clicked.JointTableProbability("red", 0);
    }
}
