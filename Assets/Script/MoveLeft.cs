using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float speed = 30;//Groundが動く速さ
    PlayerController playerControllerScript;
    float leftBound = -15;//左の限界値
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー状態でなければ、backgroundを動かす
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //左の限界値（leftBound）よりも左に行ってしまったら...
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            //障害物は消えてしまう
            Destroy(gameObject);
        }
    }
}
