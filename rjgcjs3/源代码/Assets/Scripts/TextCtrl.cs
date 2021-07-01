using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextCtrl : MonoBehaviour {

    private static GameObject txtGameOver;
    private static GameObject btnRestart;

    private void Start() {
        btnRestart = gameObject.GetComponentInChildren<Button>().gameObject;
        txtGameOver = gameObject.GetComponentInChildren<Text>().gameObject;
    }

    public static void EnableUI(bool enable) {
        btnRestart.SetActive(enable);
        txtGameOver.SetActive(enable);
    }

    public void Restart() {
        EnableUI(false);
        SceneManager.LoadScene(0);
    }

}
