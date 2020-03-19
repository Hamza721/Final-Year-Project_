    using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Gentleman obj_gentleman;
    public Theif obj_Theif;
    public HouseWife obj_HouseWife;

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    public GameObject cam7;
    public GameObject cam8;


    public CapsuleCollider capsuleCollider;

    private CharacterController controller;
    private float verticalVelocity;
    private float gravity = 14.0f;
    private float jumpForce = -50.0f;


    public Animator anim;
    public Rigidbody rbody;
    private NavMeshAgent navAgent;
    public GameObject pos, House_wife;
    public InputField Text;

    private float inputH = 0;
    private float inputV = 0;
    private string get_text;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        capsuleCollider = GetComponent<CapsuleCollider>();

        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        speed = navAgent.speed;


    }// Global variables 
    public static bool agent_active = false;
    public string Subject = "";
    public string Object = "";
    public string task = "";
    public void OnSubmit()
    {
        print("----------------------->           done");

        get_text = Text.text;

        char[] spearator = { ',' };
        Int32 count = 3;

        // Using the Method 
        String[] strlist = get_text.Split(spearator, count, StringSplitOptions.None);

        Subject = strlist[0];   //action performer
        task = strlist[1];      //action
        Object = strlist[2];    //destination 
        //int size = get_text.Length - 1;

        //Object = get_text.Substring(0, get_text.IndexOf(' '));
        //task = get_text.Substring(get_text.IndexOf(' ') + 1, size - Object.Length);


        // to show the agent is still moving towards destination
        agent_active = true;

        // setting destination and moving towards it
        House_wife = GameObject.FindWithTag(Object);
        navAgent.SetDestination(House_wife.transform.position);
    }
    public void OwnSubmit(string get_text)
    {
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
        cam6.SetActive(false);
        cam7.SetActive(false);
        cam8.SetActive(false);

        cam1.SetActive(true);
        cam2.SetActive(false);

        char[] spearator = { ',' };
        Int32 count = 3;

        // Using the Method 
        String[] strlist = get_text.Split(spearator, count, StringSplitOptions.None);

        Subject = strlist[0];   //action performer
        task = strlist[1];      //action
        Object = strlist[2];    //destination 

        // to show the agent is still moving towards destination
        agent_active = true;

        // setting destination and moving towards it
        House_wife = GameObject.FindWithTag(Object);
        navAgent.SetDestination(House_wife.transform.position);
    }
    private void Action()
    {

        cam1.SetActive(false);
        cam2.SetActive(true);

        if (task == "sit")
        {
            sit();
        }
        else if (task == "jump")
        {
            jump();
        }
        else if (task == "maleSitting")
        {
            maleSitting();
        }
        else if (task == "sittingLaughing")
        {
            sittingLaughing();
        }
        else if (task == "standingFistPump")
        {
            standingFistPump();
        }
        else if (task == "dying")
        {
            dying();
        }
        else if (task == "pointing")
        {
            pointing();
        }
        else if (task == "agony")
        {
            agony();
        }
        else if (task == "jumpDown")
        {
            jumpDown();
        }
        else if (task == "elbowPunch")
        {
            elbowPunch();
        }
        else if (task == "punching")
        {
            punching();
        }
        else if (task == "stabbing")
        {
            stabbing();
        }
        else if (task == "injuredWalking")
        {
            injuredWalking();
        }
        else if (task == "thoughtfulHeadShake")
        {
            thoughtfulHeadShake();
        }
        else if (task == "shakHeadYes")
        {
            shakHeadYes();
        }
        else if (task == "shakHeadNo")
        {
            shakHeadNo();
        }
        else if (task == "shovedReactionWithSpin")
        {
            shovedReactionWithSpin();
        }
        else if (task == "pray")
        {
            pray();
        }
        else if (task == "yell")
        {
            yell();
        }
        else if (task == "standUp")
        {
            standUp();
        }
        else if (task == "standingUp")
        {
            standingUp();
        }
        else if (task == "defeated")
        {
            defeated();
        }
        else if (task == "maleStandingPose")
        {
            maleStandingPose();
        }
        else if (task == "standingDeathBackwards")
        {
            standingDeathBackwards();
        }
        else if (task == "deathFromFrontHeadshot")
        {
            deathFromFrontHeadshot();
        }
        else if (task == "hitToHead")
        {
            hitToHead();
        }
        else if (task == "layingShakingHead")
        {
            layingShakingHead();
        }
        else if (task == "kick")
        {
            kick();
        }
        else if (task == "cockyHeadTurn")
        {
            cockyHeadTurn();
        }
        else if (task == "jumpAndKick")
        {
            jumpAndKick();
        }
        else if (task == "ShoulderHitAndFall")
        {
            ShoulderHitAndFall();
        }
        else if (task == "seeAndSit")
        {
            seeAndSit();
        }
        StartCoroutine(sleeper((double)3));
    }
    private void OnTriggerEnter(Collider other)
    {
        //print(" ----------------------------------enteredd");
        if (other.tag == "door")
        {
            navAgent.speed = 1;
            anim.Play("openDoor", -1, 0f);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "door")
        {
            navAgent.speed = speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (agent_active && (navAgent.remainingDistance > 1.1 && navAgent.remainingDistance < 1.15))
        {
            print("TASk-->" + task);
            Action();
            if (task == "stabbing")
            {
                if (Object == "housewife")
                {
                    obj_HouseWife.agony();
                }
                else if (Object == "theif")
                {
                    obj_Theif.agony();
                }
                else if (Object == "gentleman")
                {
                    obj_gentleman.agony();
                }
            }
            if (task == "punching")
            {
                if (Object == "housewife")
                {
                    obj_HouseWife.hitToHead();
                }
                else if (Object == "gentleman")
                {
                    obj_gentleman.hitToHead();
                }
                else if (Object == "theif")
                {
                    obj_Theif.hitToHead();
                }
            }
            if (task == "yell")
            {
                if (Object == "housewife")
                {
                    obj_HouseWife.shakHeadYes();
                }
                else if (Object == "gentleman")
                {
                    obj_gentleman.shakHeadYes();
                }
                else if (Object == "theif")
                {
                    obj_Theif.shakHeadYes();
                }
            }
            agent_active = false;
        }



        if ((navAgent.velocity.sqrMagnitude == 0.0))
        {
            anim.SetFloat("inputH", 0);
            anim.SetFloat("inputV", -1);

        }
        else
        {
            anim.SetFloat("inputH", 0);
            anim.SetFloat("inputV", 1);
        }

        if (Input.GetKeyDown("1"))
        {

            anim.Play("New State", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("IdleWalkTransition", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("IdleComeHere", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("IdleFight", -1, 0f);
        }
        if (Input.GetKeyDown("5"))
        {
            anim.Play("IdleMonster", -1, 0f);
        }
        if (Input.GetKeyDown("6"))
        {
            anim.Play("ghtRightFtFirstRightFtFirst", -1, 0f);
        }
        if (Input.GetKeyDown("7"))
        {
            anim.Play("New State 0", -1, 0f);
        }
        if (Input.GetKeyDown("8"))
        {
            anim.Play("Ascending Stairs(1)", -1, 0f);
            rbody.MovePosition(transform.position + (transform.forward * 4f * Time.deltaTime));
        }
        if (Input.GetKeyDown("9"))
        {
            pointing();
            //rbody.isKinematic = false;
            //navAgent.enabled = false;
            //anim.Play("Sitting(1)", -1, 0f);
            //capsuleCollider.direction = 2;
            //StartCoroutine(Death(1.5));

            //    verticalVelocity -= gravity * Time.deltaTime;
            //    moveVector = new Vector3(0, verticalVelocity, 0);
            //    controller.Move(moveVector * Time.deltaTime);
            //            rbody.MovePosition(transform.position + (transform.forward * 4f * Time.deltaTime));
        }
        if (Input.GetAxis("Vertical") > 0)
        {

            rbody.MovePosition(transform.position + (transform.forward * 3f * Time.deltaTime));
        }
        if (Input.GetAxis("Vertical") < 0)
        {

            rbody.MovePosition(transform.position - (transform.forward * 3f * Time.deltaTime));
        }
        if (Input.GetAxis("Horizontal") < 0)
        {

            transform.Rotate(Vector3.up, -30 * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {

            transform.Rotate(Vector3.up, 30 * Time.deltaTime);
        }
        // inputH = Input.GetAxis("Horizontal");
        // inputV = Input.GetAxis("Vertical");

        //anim.SetFloat("inputH",inputH);
        //anim.SetFloat("inputV", inputV);

        float moveX = inputH * 10f * Time.deltaTime;
        float moveZ = inputV * 20f * Time.deltaTime;

        rbody.velocity = new Vector3(moveX, 0f, moveZ);
    }

    IEnumerator Death2(double number)
    {
        float time_ = (float)number;
        yield return new WaitForSeconds(time_);
        rbody.constraints = RigidbodyConstraints.FreezeAll;

    }
    void sit()
    {
        anim.Play("Sit", -1, 0f);
        capsuleCollider.direction = 2;
        double time_ = 0.3;
        StartCoroutine(Death2(time_));
    }
    void jump()
    {
        anim.Play("Jumping", -1, 0f);
        navAgent.enabled = false;
    }
    void maleSitting()
    {
        anim.Play("Male Sitting Pose", -1, 0f);
    }
    void sittingLaughing()
    {
        anim.Play("Sitting Laughing", -1, 0f);
    }
    void standingFistPump()    // for standing
    {
        anim.Play("Standing Fist Pump", -1, 0f);
    }
    void dying()
    {
        navAgent.enabled = false;
        anim.Play("Dying", -1, 0f);
    }
    void pointing()
    {
        anim.Play("Pointing", -1, 0f);
    }
    public void agony()
    {
        anim.Play("Agony", -1, 0f);
    }
    void jumpDown()
    {
        navAgent.enabled = false;
        anim.Play("Jump Down", -1, 0f);
    }
    void elbowPunch()
    {
        anim.Play("Elbow Punch", -1, 0f);
    }
    void punching()
    {
        anim.Play("Punching", -1, 0f);
    }
    void stabbing()
    {
        anim.Play("Stabbing", -1, 0f);
    }
    void injuredWalking()
    {
        anim.Play("Injured Walking", -1, 0f);
    }
    void thoughtfulHeadShake()
    {
        anim.Play("Thoughtful Head Shake", -1, 0f);
    }
    public void shakHeadYes()
    {
        anim.Play("Shak Head Yes", -1, 0f);
    }
    void shakHeadNo()
    {
        anim.Play("Shak Head No", -1, 0f);
    }
    void shovedReactionWithSpin()
    {
        anim.Play("Shoved Reaction With Spin", -1, 0f);
    }
    void pray()
    {
        anim.Play("Praying", -1, 0f);
    }
    void yell()
    {
        anim.Play("Yelling", -1, 0f);
    }
    void standUp()                 //gddgfddtydghmfghmgjgfdsrdfgkhjhzxfcgjjytrsxfc
    {
        anim.Play("Stand Up", -1, 0f);
    }
    void standingUp()                 //gddgfddtydghmfghmgjgfdsrdfgkhjhzxfcgjjytrsxfc
    {
        capsuleCollider.direction = 2;
        anim.Play("Standing Up", -1, 0f);
    }
    void defeated()
    {
        anim.Play("Defeated", -1, 0f);
    }
    void maleStandingPose()
    {
        anim.Play("Male Standing Pose", -1, 0f);
    }
    void standingDeathBackwards()
    {
        anim.Play("Standing Death Backward", -1, 0f);
        navAgent.enabled = false;
    }
    void deathFromFrontHeadshot()
    {
        anim.Play("Death From Front Headshot", -1, 0f);
        navAgent.enabled = false;
    }
    public void hitToHead()
    {
        anim.Play("Hit To Head", -1, 0f);
        navAgent.enabled = false;
    }
    void layingShakingHead()
    {
        anim.Play("Laying Shaking Head", -1, 0f);
        navAgent.enabled = false;
        rbody.isKinematic = false;
        capsuleCollider.direction = 2;
    }
    void kick()
    {
        anim.Play("Kicking", -1, 0f);
    }
    void cockyHeadTurn()
    {
        anim.Play("Cocky Head Turn", -1, 0f);
    }
    void jumpAndKick()
    {
        anim.Play("JumpAndKick", -1, 0f);
        navAgent.enabled = false;
    }
    void ShoulderHitAndFall()
    {
        rbody.isKinematic = false;
        navAgent.enabled = false;
        anim.Play("Shoulder Hit And Fall", -1, 0f);
        capsuleCollider.direction = 2;
        double time_ = 4;
        StartCoroutine(Death2(time_));
    }


    IEnumerator Death(double number)
    {
        print("I lo dare i'm here");
        //rbody.isKinematic = false;
        navAgent.enabled = false;

        float time_ = (float)number;
        yield return new WaitForSeconds(time_);
        //capsuleCollider.direction = 2;

        time_ = 1;
        yield return new WaitForSeconds(time_);
        //float y = transform.position.y - (float)0.277773;
        //transform.position = new Vector3(transform.position.x, y, transform.position.z);
        //rbody.constraints = RigidbodyConstraints.FreezeAll;

    }
    void seeAndSit()
    {
        anim.Play("seeAndSit", -1, 0f);

        double time_ = 3;
        StartCoroutine(Death(time_));

    }
    IEnumerator sleeper(double number)
    {

        float time_ = (float)number;
        yield return new WaitForSeconds(time_);

        print("I lo dare i'm here");
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
        cam6.SetActive(false);
        cam7.SetActive(false);
        cam8.SetActive(false);

        cam1.SetActive(true);
        cam2.SetActive(false);


        time_ = (float)1;
        yield return new WaitForSeconds(time_);

        obj_gentleman.set_Action_completed();
    }
}
