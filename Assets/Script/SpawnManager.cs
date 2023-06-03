using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;//障害物プレハブ
    Vector3 spawnPos = new Vector3(25, 0, 0);//スポーンする場所
    float elapsedTime;//経過時間
    PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;//毎Fの時間を足していく
        if(elapsedTime > 2.0f && !playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            elapsedTime = 0.0f;//経過時間リセット
        }
       //nstantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
