using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCtrl : MonoBehaviour {

    private static int score = 0;
    private static Text txtScore;

    void Start() {
        txtScore = gameObject.GetComponent<Text>();
        txtScore.text = "������" + score;
    }

    public static void AddScore() {
        score++;
        txtScore.text = "������" + score;
    }
}
