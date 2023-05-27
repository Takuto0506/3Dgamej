using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;

  private Rigidbody playerRb;
    [SerializeField] float gravityModifier;//重力値調整用
    [SerializeField] float jumpForce;//ジャンプ力
    [SerializeField] bool isOnGround;//地面についているか
    public bool gameOver;//何も書かなければprivate
    Animator playerAnim;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されて、かつ、地面にいたら、ゲームオーバーではないなら
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;//ジャンプした=地面にいない
            playerAnim.SetTrigger("Jump_trig");//ジャンプアニメ発動準備
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
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;//ゲームオーバーにする
            playerAnim.SetBool("Death_b", true);//ここで死亡状態bにする。（Death_bというのは本来自分で定義できる）
            playerAnim.SetInteger("DeathType_int", 1);//integerは整数の意味。死亡のタイプ？を1番目のやつにする的な。
        }
    }
}
