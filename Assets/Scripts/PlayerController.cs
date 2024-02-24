using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public bool isMoving;
    public float dmg_max = 20;
    public float dmg_min = 10;
    private Vector2 input;
    public Vector2 direction;
    public LayerMask solidObjectLayer;
    public LayerMask interactableLayer;

    private Animator animator;
    float moveX;
    float moveY;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");

            direction = new Vector2(moveX,moveY).normalized;

            input.x = moveX;
            input.y = moveY;
            if (input.x != 0)
            {
                input.y = 0;
            }
            if (input.y != 0)
            {
                input.x = 0;
            }
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos=transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

  
                if(isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position=Vector3.MoveTowards(transform.position, targetPos, movespeed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer|interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos=transform.position+facingDir;
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            var dmg= Random.Range(dmg_min,dmg_max);
            //Debug.Log("ther is a npc here");
            collider.GetComponent<Enemy>()?.Damage(dmg);
            
        }
        {
            
        }
    }
}
