using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;
using UnityStandardAssets.CrossPlatformInput;

public class fighterController : MonoBehaviour
{
    AeroplaneController controller;
    Rigidbody rigid;
    Rigidbody rigidR;

    public float speed = 100f;
    public float stopTime = 2f;
    float pitch;
    float roll;

    private void Awake()
    {
        controller = GetComponent<AeroplaneController>();
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        pitch = Input.GetAxis("Vertical");
        roll = Input.GetAxis("Horizontal");

        // 位置の固定
        if (!Input.GetKey(KeyCode.UpArrow) &&
    !Input.GetKey(KeyCode.DownArrow) &&
    !Input.GetKey(KeyCode.RightArrow) &&
    !Input.GetKey(KeyCode.LeftArrow))
        {

            StartCoroutine("RigidFreezeAll");
        }
        else
        {
            rigid.constraints = RigidbodyConstraints.None;
            // 位置 Z だけ固定
            rigid.constraints = RigidbodyConstraints.FreezePositionZ;
        }


        float x = roll * speed;
        float y = pitch * speed;

        // 移動
        Vector3 moveVector = new Vector3(x , -y , 0);    // 移動速度の入力
        rigid.AddForce(speed * (moveVector - rigid.velocity));


        // 回転
        // 軸を基準に　pitch, 0, roll
        moveVector = new Vector3(y, 0, -x);
        Vector3 velocityVector = Vector3.zero;
        // 
        velocityVector.x = -rigid.velocity.y;
        velocityVector.z = -rigid.velocity.x;

        rigid.AddTorque(speed * (moveVector - velocityVector));

    }
    IEnumerator RigidFreezeAll()
    {
        //n秒停止
        yield return new WaitForSeconds(stopTime);

        rigid.velocity = Vector3.zero;
        pitch = 0;
        roll = 0;
        rigid.constraints = RigidbodyConstraints.FreezeAll;
    }
    void Update()
    {


    }
}
