using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Variable to hold input value
    float input_Horizontal;
    float input_Vertical;
    bool input_Jump;
    bool init_sound = false;
    public bool isPlayingSteppingSounds = false;
    bool getDownPermission = false;
    public bool getDownRequest = false;
    public bool anotherRequestBegins = false;

    // Refer to other class to get data
    Player player;

    Collision2D lastCollision;
    PlayingSceneSFX audioManager;
    // Properties
    [SerializeField] float walk_Velocity;
    [SerializeField] float jump_Force;
    [SerializeField] float jump_Velocity_H;

    // Variables to record current

    // Change depends on the state
    float current_Velocity_H;

    void Awake()
    {
        player = GetComponent<Player>();
        audioManager = GameObject.Find("SoundManagers/SFXAudioManager").gameObject.GetComponent<PlayingSceneSFX>();
        //audioManager = GameObject.Find("SoundManagers/SFXAudioManager").GetComponent<SFXAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity_Control();
        getInputs();
        processInputs();
        walkingSound();
    }

    void getInputs()
    {
        input_Horizontal = Input.GetAxis("Horizontal");
        input_Vertical = Input.GetAxis("Vertical");
        input_Jump = Input.GetButtonDown("Jump");
    }

    void processInputs()
    {

        if (Mathf.Abs(input_Horizontal) > 0)
        {
            move_H();
        }
        else
        {
            player.mAnimCon.changeAnim("Running", false);
        }

        if (input_Jump && player.canJump)
        {
            jump();
        }
        /*
        if (Input.GetButtonDown("GetDown"))
        {
            StopCoroutine( RetainGetDownRequest());
            StartCoroutine( RetainGetDownRequest());
        }
        */
        if (input_Horizontal == 0 && input_Vertical == 0 && player.canJump)
        {
            Vector2 updated_Velocity = new Vector2(0, player.mRigidBody.velocity.y);
            player.mRigidBody.velocity = updated_Velocity;
        }
        if (getDownPermission && player.canJump)
        {
            // TODO: HOLD DOWN
            if (Input.GetButtonDown("GetDown"))
            {
                StartCoroutine(BlinkCollider(lastCollision));
            }
        }

    }

    void velocity_Control()
    {
        if (player.canWalk)
        {
            current_Velocity_H = walk_Velocity;
        }

        // TODO: Need to change the condition
        if (!player.canJump)
        {
            //current_Velocity_H = jump_Velocity_H;
            if (Input.GetButtonUp("Jump") && player.mRigidBody.velocity.y > 0)
            {
                Vector2 updated_Velocity = new Vector2(player.mRigidBody.velocity.x, player.mRigidBody.velocity.y / 2);
                player.mRigidBody.velocity = updated_Velocity;
            }
        }
    }


    // Controll players horizontal move
    void move_H()
    {
        Vector2 updated_Velocity = new Vector2(input_Horizontal * current_Velocity_H, player.mRigidBody.velocity.y);
        player.mRigidBody.velocity = updated_Velocity;

        player.mAnimCon.changeAnim("Running", true);
    }

    void jump()
    {
        audioManager.playJumping();
        Vector2 updated_Velocity = new Vector2(player.mRigidBody.velocity.x, jump_Force);
        player.mRigidBody.velocity = updated_Velocity;
        player.canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            audioManager.playLanding();
        }
        else
        {
            getDownPermission = true;
            lastCollision = collision;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {

        }
    }
    void walkingSound()
    {
        if (input_Horizontal != 0 && player.canJump)
        {
            if (!isPlayingSteppingSounds)
            {
                if (!init_sound)
                {
                    audioManager.startPlayingFootstep();
                    init_sound = true;
                }

                isPlayingSteppingSounds = true;
                audioManager.allowPlaying = true;

            }
        }
        else
        {
            isPlayingSteppingSounds = false;
            audioManager.allowPlaying = false;
        }
    }

    public IEnumerator BlinkCollider(Collision2D collision)
    {
        Collision2D myCollision = collision;
        myCollision.gameObject.GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.45f);
        myCollision.gameObject.GetComponent<Collider2D>().isTrigger = false;

    }

    public IEnumerator RetainGetDownRequest()
    {
        getDownRequest = true;
        yield return new WaitForSeconds(0.5f);
        getDownRequest = false;
    }
}

