
using UnityEngine;
using System;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] public float groundDistance;
    [SerializeField] public float sprintSpeed;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float acceleration;
    [SerializeField] public float deceleration;
    [SerializeField] public float gravityValue;
    [SerializeField] public float maxJumpSpeed;
    [SerializeField] public float jumpSpeed;
    [SerializeField] public float jumpAcceleration;
    [SerializeField] public float jumpHeigth;
    [SerializeField] public float airTime;

    [Space]
    [Space]
    [Space]

    [Header("Debug")]
    [SerializeField] TextMeshProUGUI stateDebug;
    public PlayerState PlayerState;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private FakeAnimator fakeAnimator;
    private boxEffector connectedBox;
    [SerializeField] public float moveX;
    [SerializeField] public float moveY;

    //cache
    private float OnJumpTimer;
    private float OnJumpPeakTimer;
    private Vector2 onJumpPosition;
    public bool sprint;

    //gameobject
    [SerializeField]public EiniControl Eini;
    [SerializeField]public TurtControl Turt;
    
    public virtual void Start()
    {
        Parameters();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>(); 
        
        fakeAnimator = GetComponent<FakeAnimator>();
        InputHandler.Instance.OnMovementReleased += stopMovement;
        InputHandler.Instance.OnJumpReleased += Falling;
        InputHandler.Instance.OnSprintPressed += Sprinting;
        InputHandler.Instance.OnSprintReleased += Notsprinting;
        InputHandler.Instance.OnPushButtonDown += Push;
        InputHandler.Instance.OnPushButtonUp += ReleasePush;
    }
    public virtual void Update()
    {
        stateDebug.text = PlayerState.ToString();
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (!CheckGround())
        {
            Gravity();
        }
        if (CheckGround())
        {
            InputHandler.Instance.OnJumpPressed += Jump;
            InputHandler.Instance.OnMovementPressed += GroundedMovement;
            if (PlayerState != PlayerState.OnJump && PlayerState != PlayerState.Jumping)
            {
                moveY = 0;
            }
        }

        if (PlayerState == PlayerState.OnJump)
        {
            OnJumpTimer -= Time.deltaTime;
            if (OnJumpTimer < 0)
            {
                if (CheckGround())
                {
                    PlayerState = PlayerState.Floor;
                }
                else
                {
                    PlayerState = PlayerState.Jumping;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, moveY);
    }

    public virtual void Parameters()
    {
        groundDistance = 0.4f;
        sprintSpeed = 10f;
        maxSpeed = 10f;
        acceleration = 10f;
        deceleration = 1f;
        gravityValue = 31f;
        maxJumpSpeed = 15f;
        jumpSpeed = 20f;
        jumpAcceleration = 45f;
        jumpHeigth = 3.5f;
        airTime = 0.19f;
    }

    public virtual void Gravity()
    {
        if (PlayerState != PlayerState.Jumping && PlayerState != PlayerState.OnJump)
        {
            moveY = -gravityValue;
        }
    }

    public virtual bool CheckGround()
    {
        //RaycastHit2D hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, groundDistance);
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(col.bounds.center.x, (col.bounds.center.y - col.size.y / 2) - 0.1f), Vector2.down, groundDistance);
        Debug.DrawRay(new Vector3(col.bounds.center.x, (col.bounds.center.y - col.size.y / 2) - 0.1f), Vector2.down, Color.green);

        if (hit)
        {
            if (hit.collider.GetComponent<npc1>() != null || hit.collider.GetComponent<npc2>() != null)
            {
                return false;
            }
            if (PlayerState != PlayerState.OnJump)
            {
                if (PlayerState != PlayerState.Floor)
                {
                    moveX = Input.GetAxisRaw("Horizontal") * maxSpeed / 2;
                }
                PlayerState = PlayerState.Floor;
            }
            return true;
        }
        else 
        {
            return false;
        }
    }

    public virtual void GroundedMovement(float direction)
    {
        if (!sprint)
        {    
            if (Mathf.Abs(moveX) < maxSpeed)
            {
                moveX += Input.GetAxisRaw("Horizontal") * acceleration;
            }
            else
            {
                moveX = Mathf.Sign(moveX) * maxSpeed;
            }
        }
        else
        {
            if (Mathf.Abs(moveX) < sprintSpeed)
            {
                moveX += Input.GetAxisRaw("Horizontal") * acceleration;
            }
            else
            {
                moveX = Mathf.Sign(moveX) * sprintSpeed;
            }
        }
        EiniAnimationHandler.Instance.PlayWalkAnimation(MathF.Sign(moveX));
    }

    public virtual void stopMovement(float direction)
    {
        if (PlayerState == PlayerState.Floor)
        {
            EiniAnimationHandler.Instance.PlayIdleAnimation();
        }
        if (deceleration > 0)
        {
            if (Math.Abs(moveX) > 0)
            {
                moveX -= Mathf.Sign(moveX) * deceleration;
            }
            else
            {
                //old
                //moveX = Input.GetAxisRaw("Horizontal") * maxSpeed;
                //new
                moveX = 0;
            }
        }
        else
        {
            moveX = 0;
        }

        if (deceleration == 0)
        {
            moveX = 0;
        }
    }

    public virtual void Jump()
    {
        if (PlayerState == PlayerState.Floor)
        {
            PlayerState = PlayerState.OnJump;
            VFXManager.Instance.PlayVFX_Jump(col);
            EiniAnimationHandler.Instance.PlayJumpAnimation();
            moveY = jumpSpeed;
            OnJumpTimer = 0.15f;
            onJumpPosition = rb.position;
        }
    }

    public virtual void Sprinting(bool sprinting)
    {
        if(GameHandler.Instance.sprintToggle == true)
        {
            sprint = true;
        }
    }

    public virtual void Notsprinting(bool sprinting)
    {
        sprint = false;
    }

    public virtual void Falling()
    {
        //check if the player is jumping or falling
        if (PlayerState == PlayerState.Jumping || PlayerState == PlayerState.Falling)
        {
            //apply gravity
            moveY -= gravityValue * Time.deltaTime;

            //check for maximum fall speed
            if (moveY < -maxJumpSpeed)
            {
                moveY = -maxJumpSpeed;
            }

            //check if player reached jump peak
            if (PlayerState == PlayerState.Jumping && rb.position.y > onJumpPosition.y + jumpHeigth)
            {
                PlayerState = PlayerState.JumpPeak;
                OnJumpPeakTimer = airTime;
            }

            //handle falling state
            if (PlayerState == PlayerState.JumpPeak)
            {
                EiniAnimationHandler.Instance.PlayFallAnimation();
                moveY = 0;
                OnJumpPeakTimer -= Time.deltaTime;
                if (OnJumpPeakTimer <= 0)
                {
                    PlayerState = PlayerState.Falling;
                }
            }


            //falling state
            if (PlayerState == PlayerState.Falling)
            {
                moveY = -gravityValue;
                if (!CheckGround())
                {
                    EiniAnimationHandler.Instance.PlayFallAnimation();
                }
                else
                {
                    PlayerState = PlayerState.Floor;
                    moveY = 0;
                }
            }    
        } 
    }

    public void Push()
    {
        if (GameHandler.Instance.PushToggle == true && PlayerState == PlayerState.Floor)
        {
            PlayerState = PlayerState.pushing;
            if(PlayerState == PlayerState.pushing)
            {
                Debug.Log("Triggered");
                RaycastHit2D rightRayHit = Physics2D.Raycast(new Vector2(col.bounds.max.x + 0.1f, col.bounds.center.y), Vector2.right, 0.5f);
                RaycastHit2D leftRayHit = Physics2D.Raycast(new Vector2(col.bounds.min.x - 0.1f, col.bounds.center.y), Vector2.left, 0.5f);

                Debug.DrawRay(new Vector2(col.bounds.max.x + 0.1f, col.bounds.center.y), Vector2.right * 0.5f, Color.red);
                Debug.DrawRay(new Vector2(col.bounds.min.x - 0.1f, col.bounds.center.y), Vector2.left * 0.5f, Color.red);

                if (rightRayHit.collider != null || leftRayHit.collider != null)
                {
                    Debug.Log("hit");
                    if (rightRayHit.collider != null && rightRayHit.collider.GetComponent<boxEffector>() != false)
                    {
                        Debug.Log("FoundRightBox");
                        boxEffector box = rightRayHit.collider.GetComponent<boxEffector>();
                        connectedBox = box;
                        box.FixedToPlayer(this);
                    }
                    else if (leftRayHit.collider != null && leftRayHit.collider.GetComponent<boxEffector>() != false)
                    {
                        Debug.Log("FoundLeftBox");
                        boxEffector box = leftRayHit.collider.GetComponent<boxEffector>();
                        connectedBox = box;
                        box.FixedToPlayer(this);
                    }
                }
                else
                {
                    Debug.Log("notHitting");
                }
            }
        }
    }

    public void ReleasePush()
    {
        if(connectedBox == null)
        {
            return;
        }
        connectedBox.DetachFromPlayer();
    }
}

public enum PlayerState
{
    Floor =0,
    OnJump = 1,
    Jumping = 2,
    JumpPeak = 3,
    Falling = 4,
    Landing = 5,
    Crouching = 6,
    pushing = 7
}
