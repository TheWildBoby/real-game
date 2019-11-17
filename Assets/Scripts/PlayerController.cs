using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    float movementHorz;
    float movementVert;
    public float speed = 2;
    public float groundRayDistance;
    bool grounded = false;

    PlayerInputActions inputActions;
    public Vector2 Movement;
    public bool Jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Movement.performed += ctx => Movement = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Jump.performed += ctx => Jump = ctx.ReadValue<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GroundCheck())
        {
        }
        else {
            movementVert = 0;
        }
        rb.velocity = new Vector2(movementHorz, movementVert);
    }

    bool GroundCheck()
    {
        RaycastHit2D hit;
        Vector2 extents = gameObject.GetComponent<Renderer>().bounds.extents;
        Vector2 vPos = transform.position;
        //for (int i = -1; i <= 1; i++)
        //{
            hit = Physics2D.Raycast(transform.position, Vector2.down, groundRayDistance, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                return true;
            }
        //}
        return false;


    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
