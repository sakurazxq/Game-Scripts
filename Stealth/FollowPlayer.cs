using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed = 3;
    public float rotateSpeed = 3;

    private Vector3 offset;

    private Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        offset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 beginPos = player.position + offset;
        //在beginPos和player正上方的endPos之间用插值法取三个点，依次判断摄像机位于这五个点处拍摄player是否有视线阻挡
        Vector3 endPos = player.position + offset.magnitude * Vector3.up;//magnitude返回向量长度
        Vector3 pos1 = Vector3.Lerp(beginPos, endPos, 0.25f);
        Vector3 pos2 = Vector3.Lerp(beginPos, endPos, 0.5f);
        Vector3 pos3 = Vector3.Lerp(beginPos, endPos, 0.75f);

        Vector3[] posArray = new Vector3[] { beginPos, pos1, pos2, pos3, endPos };
        Vector3 targetPos = posArray[0];
        for(int i = 0; i<5; i++)
        {
            RaycastHit hitinfo;
            if(Physics.Raycast(posArray[i],player.position - posArray[i],out hitinfo))
            {
                if(hitinfo.collider.tag!= Tags.player)
                {
                    continue;
                }
                else
                {
                    targetPos = posArray[i];
                    break;
                }
            }
            else
            {
                targetPos = posArray[i];
                break;
            }
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
        Quaternion nowRotation = transform.rotation;
        transform.LookAt(player.position);//摄像机正对着目标位置
        transform.rotation = Quaternion.Lerp(nowRotation,transform.rotation,Time.deltaTime * rotateSpeed);
    }
}
