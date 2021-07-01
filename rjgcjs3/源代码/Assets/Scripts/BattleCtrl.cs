using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCtrl : MonoBehaviour {

    public static int xLimit = 30;
    public static int yLimit = 22;
    void Start() {
        Food();
    }

    public static void Food() {
        int x = Random.Range(-xLimit, xLimit);
        int y = Random.Range(-yLimit, yLimit);
        Instantiate(Resources.Load("Prefabs/Food"), new Vector2(x, y), Quaternion.identity);
    }
}
