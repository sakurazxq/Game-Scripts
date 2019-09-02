using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    private Animator anim;

    private int speedID = Animator.StringToHash("Speed");
    private int isSpeedupID = Animator.StringToHash("IsSpeedup");
    private int horizontalID = Animator.StringToHash("Horizontal");
    private int speedRotateID = Animator.StringToHash("SpeedRotate");
    private int speedZID = Animator.StringToHash("SpeedZ");
    private int vaultID = Animator.StringToHash("Vault");
    private int sliderID = Animator.StringToHash("Slider");
    private int colliderID = Animator.StringToHash("Collider");
    private int isHoldLogID = Animator.StringToHash("IsHoldLog");

    private Vector3 matchTarget = Vector3.zero;

    private CharacterController characterController;

    public GameObject unityLog = null;
    public Transform rightHand;
    public Transform leftHand;

    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        //unityLog = transform.Find("Unity_Log").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(speedZID, Input.GetAxis("Vertical") * 4.1f);
        anim.SetFloat(speedRotateID, Input.GetAxis("Horizontal") * 126);
        //anim.SetFloat(speedID, Input.GetAxis("Vertical")*4.1f);
        //anim.SetFloat(horizontalID, Input.GetAxis("Horizontal"));
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    anim.SetBool(isSpeedupID, true);
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    anim.SetBool(isSpeedupID, false);
        //}
        ProcessVault();
        ProcessSlider();
        //if(anim.GetFloat(colliderID)>0.5f)
        //{
        //    characterController.enabled = false;
        //}
        //else
        //{
        //    characterController.enabled = true;
        //}
        characterController.enabled = anim.GetFloat(colliderID) < 0.5f;
    }

    private void ProcessVault()
    {
        bool isVault = false;
        if (anim.GetFloat(speedZID) > 3 && anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 0.3f, transform.forward, out hit, 4f))
            {
                if (hit.collider.tag == "Obstacle")
                {
                    Vector3 point = hit.point;
                    point.y = hit.collider.transform.position.y + hit.collider.bounds.size.y + 0.07f;
                    matchTarget = point;
                    isVault = true;
                }
            }
        }
        anim.SetBool(vaultID, isVault);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Vault") && anim.IsInTransition(0) == false)
        {
            anim.MatchTarget(matchTarget, Quaternion.identity, AvatarTarget.LeftHand, new MatchTargetWeightMask(Vector3.one, 0), 0.32f, 0.4f);
        }
    }

    private void ProcessSlider()
    {
        bool isSlider = false;
        if (anim.GetFloat(speedZID) > 3 && anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.forward, out hit, 3f))
            {
                if (hit.collider.tag == "Obstacle")
                {
                    if (hit.distance > 2)
                    {
                        Vector3 point = hit.point;
                        point.y = 0;
                        matchTarget = point + transform.forward * 2;
                        isSlider = true;
                    }
                }
            }
        }
        anim.SetBool(sliderID, isSlider);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Slider") && anim.IsInTransition(0) == false)
        {
            anim.MatchTarget(matchTarget, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(1,0,1), 0), 0.17f, 0.67f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Log")
        {
            Destroy(other.gameObject);
            CarryWood();
        }
        if(other.tag == "Playable")
        {
            director.Play();
        }
    }

    void CarryWood()
    {
        unityLog.SetActive(true);
        anim.SetBool(isHoldLogID, true);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(layerIndex == 1)
        {
            int weight = anim.GetBool(isHoldLogID) ? 1 : 0;

            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);

            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weight);
        }
    }
}
