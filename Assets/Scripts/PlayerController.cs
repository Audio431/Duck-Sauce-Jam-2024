using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float dashSpeed;
    private float dashLength = .5f;
    public float dashCooldown = 1;
    private float dashCounter = 0;
    public float movespeed;
    private float normalSpeed;
    public bool isMoving;
    public bool isAlive=true;
    public float dmg_max = 20;
    public float dmg_min = 10;
    public float maxHp = 100;
    public float hp = 100;
    public Vector2 input;
    public float volume = 0;
    [SerializeField] private AudioClip attackClip;
    public LayerMask solidObjectLayer;
    public LayerMask interactableLayer;
    public GameObject healthbar;
    private Slider slider;
    public LogicManager logic;


    private Animator animator;
    float moveX;
    float moveY;

    public Vector2 LastmoveVector; 
    private void Awake()
    {
        animator = GetComponent<Animator>();
        LastmoveVector = new Vector2(1,0f);

    }
    private void Start()
    {
        normalSpeed = movespeed;
        animator.SetFloat("moveX", -1f);

        healthbar = Instantiate(healthbar, transform.position, transform.rotation);
        healthbar.transform.parent = transform;
        slider = healthbar.GetComponent<Slider>();
        slider.value = 0f;

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    private void Update()
    {
        healthbar.transform.position = transform.position+new Vector3(0,1,0);
        SetHealthbar(slider);
        if (isAlive)
        {
            if (!isMoving)
            {
                moveX = Input.GetAxisRaw("Horizontal");
                moveY = Input.GetAxisRaw("Vertical");


                input.x = moveX;
                input.y = moveY;
                if (input.x != 0)
                {
                    LastmoveVector = new Vector2(input.x, 0f);
                    input.y = 0;
                }
                if (input.y != 0)
                {
                    LastmoveVector = new Vector2(0f, input.y);
                    input.x = 0;
                }
                if (input != Vector2.zero)
                {
                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);
                    var targetPos = transform.position;
                    targetPos.x += input.x;
                    targetPos.y += input.y;


                    if (isWalkable(targetPos))
                        StartCoroutine(Move(targetPos));
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                SoundFXManager.instance.PlaySoundFXClip(attackClip, transform, volume);
                StartCoroutine(AttackAnimation());
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && dashCounter <= 0)
            {
                dashCounter = dashCooldown;
                movespeed = dashSpeed;
            }

            if(dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;
                if (dashCounter <= dashCooldown - dashLength)
                {
                    movespeed = normalSpeed;
                }
            }
        }
    }
    public void SetHealthbar(Slider slider)
    {
        slider.value = (maxHp - hp) / maxHp;
    }
    IEnumerator AttackAnimation()
    {
        animator.SetBool("isAttack", true);

        // Wait for a short duration (adjust as needed)
        yield return new WaitForSeconds(0.1f);

        // Call your interaction function here
        Interact();

        animator.SetBool("isAttack", false);
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
    public void IsAttacked(float damage)
    {
        hp-= damage;
        if (hp<=0)
        {
            Dead();
        }

    }
    public void Dead()
    {
        isAlive = false;
        Debug.Log("die");
        logic.GameOver();
    }
}
