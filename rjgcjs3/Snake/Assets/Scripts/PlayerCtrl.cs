using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour {
    public bool ISwith = false;  //是否吃到
    public float velocitytime = 0.5f; //初始速度
    private Vector2 dir;
    private float speed = 5;
    private DirType type;
    private List<Transform> bodyList = new List<Transform>();
    private Vector3 addOffset;

    void Start() {
        dir = Vector2.zero;
        InvokeRepeating("Move", 0.5f, velocitytime);
    }

    public void Up() {
        if (type == DirType.Up || type == DirType.Down)
            return;
        dir = Vector2.up;
        type = DirType.Up;
        addOffset = new Vector3(0, -1, 0);
    }

    public void Down() {
        if (type == DirType.Up || type == DirType.Down)
            return;
        dir = Vector2.down;
        type = DirType.Down;
        addOffset = new Vector3(0, 1, 0);
    }

    public void Left() {
        if (type == DirType.Left || type == DirType.Right)
            return;
        dir = Vector2.left;
        type = DirType.Left;
        addOffset = new Vector3(1, 0, 0);
    }

    public void Right() {
        if (type == DirType.Left || type == DirType.Right)
            return;
        dir = Vector2.right;
        type = DirType.Right;
        addOffset = new Vector3(-1, 0, 0);
    }

    private void Move() {
        Vector3 vpos = transform.position;
        transform.Translate(dir);
        if (ISwith) {
            GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/Body"), vpos, Quaternion.identity);
            bodyList.Insert(0, go.transform);
            ISwith = false;
        }
        if(bodyList.Count > 0) {
            bodyList.Last().position = vpos;
            bodyList.Insert(0, bodyList.Last());
            bodyList.RemoveAt(bodyList.Count - 1);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Food")) {
            Destroy(other.gameObject);
            ISwith = true;
            BattleCtrl.Food();
            ScoreCtrl.AddScore();
            velocitytime -= 0.01f;
        }
        else {
            Dead();
        }
    }

    private void Dead() {
        CancelInvoke();
        SceneManager.LoadScene(0);
    }
}

public enum DirType {
    Up,
    Down,
    Left,
    Right,
}
