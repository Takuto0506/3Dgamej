using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] float gravityModifier;//重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたら
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //上へ力を加える
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;//ジャンプした=地面にいない
        }
    }
    //衝突が起きたら実行
    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかった相手（collsion）のタグがGroundなら
        if(collision.gameObject.CompareTag("Ground"))
        { 
            isOnGround = true;//地面についている状態に変更
        }
    }
}
