using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    SpecialSkillActive,
    MovRight,
    MovLeft,
    Traped,
    Dead,
    None
}
public class Player : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float MaxSpeed=1;
    [SerializeField] float verticle_mov=0;
    [SerializeField] float horizon_mov=0;
    //[SerializeField] float jump_cool_down=0;
    [SerializeField] KeyRecorder keyRecorder;
    [SerializeField] KeyCode[] opcode=new KeyCode[]{KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D};
    [SerializeField] KeyCode attackCode;
    public bool p1;
    
    // Start is called before the first frame update
    public PlayerState CurPlayerState;
    Rigidbody2D rigidbody=null;

    IEnumerator moving(Vector2 dir)
    {
        
        Vector2 finaldir=(new Vector2(dir.x*horizon_mov,0));
        if(dir.y!=0)
        {
            RaycastHit2D[] raycastHit=Physics2D.RaycastAll(rigidbody.position,Vector2.down,1);
            bool findterrian=false;
            foreach(var r in raycastHit)
                if(r.collider.tag=="Terrian")
                {
                    findterrian=true;
                    break;
                }
            if(findterrian)
                finaldir+=(new Vector2(0,dir.y*verticle_mov));
        }
        
        
        if(rigidbody.velocity.magnitude>=MaxSpeed)
        {
           rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, MaxSpeed);
        }
        else
            rigidbody.AddForce(finaldir);
        yield return null;
    }
    void MovDir(Vector2 dir) // up == true , down == false
    {
        StartCoroutine(moving(dir));
    }
    void UpdateState()
    {
        if(keyRecorder.specialskill())
        {
            CurPlayerState=PlayerState.SpecialSkillActive;
            return;
        }
        Vector2 vector=new Vector2(0,0);
        
        if(Input.GetKeyDown(opcode[0]))
        {
            vector+=new Vector2(0,1);
        }
        if(Input.GetKey(opcode[1]))
        {
            vector+=new Vector2(0,-1);
        }
        if(Input.GetKey(opcode[2]))
        {
            CurPlayerState=PlayerState.MovLeft;
            vector+=new Vector2(-1,0);
        }
        if(Input.GetKey(opcode[3]))
        {
            CurPlayerState=PlayerState.MovRight;
            vector+=new Vector2(1,0);
        }
        Attack();


        if(vector.magnitude==0)
            CurPlayerState=PlayerState.None;
        else
            MovDir(vector.normalized);
    }
    void SpriteUpdate()
    {
        if(CurPlayerState==PlayerState.MovRight)
        {
            spriteRenderer.flipX=false;
        }
        if(CurPlayerState==PlayerState.MovLeft)
        {
            spriteRenderer.flipX=true;
        }
    }
    public void Trapped()
    {
        Debug.Log("called trapped");
        StopAllCoroutines();
        CurPlayerState=PlayerState.Traped;
        spriteRenderer.flipY = true;
        if (GeneralManager.Instance)
        {
            if (p1)
            {
                GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player1);
            }
            else
            {
                GeneralManager.Instance.SetThisRoundWinner(GeneralManager.Player.Player2);
            }
        }
      
    }
    void Attack()
    {
        if(Input.GetKeyDown(attackCode))
        {
            GameObject g=Instantiate(bullet,transform.position,transform.rotation);
            g.GetComponent<Bullet>().detectTag=((gameObject.tag=="PlayerA")? "PlayerB":"PlayerA");
        }
    }
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        rigidbody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteUpdate();
        if(CurPlayerState!=PlayerState.Traped&&CurPlayerState!=PlayerState.Dead)
            UpdateState();
    }
}
