using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProbabilityToggleHandler : MonoBehaviour{
    public Game game; // Reference to the Game script
    private bool showProbability = true;

    void Start(){
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleProbability);
    }

    void ToggleProbability(){
        if (showProbability){
            HideProbability();
            showProbability = false;
        }
        else{
            ShowProbability();
            showProbability = true;
        }
    }

    void HideProbability(){
        foreach (Tile tile in game.grid){
            tile.HideProbability();
        }
    }

    void ShowProbability(){
        foreach (Tile tile in game.grid){
            tile.ShowProbability();
        }
    }
}