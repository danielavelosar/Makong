using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakoController : MonoBehaviour
{
    //movement controllers
    public float jumpForce = 40f;
    public float runningSpeed = 10f;
    public float walkingSpeed = 6f;
    private Rigidbody2D makoRigidBody;
    private  Vector3 startPosition;
    private Animator makoAnimator;

 
//controllers Mako animation
    private const string STATE_LIVE = "isAlive";
    private const string STATE_GROUND = "isOnTheGround";
    public LayerMask groundMask;
    
    //awake es lo primero que abre el programa antes de comenzar 
    private void Awake()
    {
        makoRigidBody = GetComponent<Rigidbody2D> ();
        makoAnimator = GetComponent<Animator> ();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        //poner que Mako camina desde el principio
        
        startPosition = this.transform.position;
        
    }
 
    // para que cuando reinicie vuelva al mismo sitio
    public void StartGame(){
        
        
        makoAnimator.SetBool(STATE_LIVE, true);
        makoAnimator.SetBool(STATE_GROUND, true);
        Invoke("RestartPosition", 0.2f);
    }

     void RestartPosition(){
        
        this.transform.position = startPosition;
        this.makoRigidBody.velocity =  Vector2.zero;
        
    }

    // Update is called once per frame
    void Update()
    {   
        
            
            // para que cuando oprima espacio o click izquierdo salte
            if( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetMouseButtonDown(0)){
                if(GameManager.sharedInstance.currentState==GameState.inGame){
                Jump();}
                
            }
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                if(GameManager.sharedInstance.currentState==GameState.inGame){
                GetComponent<SpriteRenderer>().flipX = false;
                
                Walk();}
                
            }
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
                if(GameManager.sharedInstance.currentState==GameState.inGame){
                //para voltear a Mako y que retroceda
                GetComponent<SpriteRenderer>().flipX = true;
                
                Walk();
                }
            }
            
            

            

        makoAnimator.SetBool(STATE_GROUND, isTouchingGround());
        //para poder ver como funciona el draw ray
        Debug.DrawRay(this.transform.position, Vector2.down*1.6f, Color.red);
    }
    // fix update for no lag 
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        //para que se pare cuando no esté jugando
        if(GameManager.sharedInstance.currentState==GameState.inGame){
            if(makoRigidBody.velocity.x < walkingSpeed){
            makoRigidBody.velocity = new Vector2(
                walkingSpeed*Input.GetAxis("Horizontal") , //x
                makoRigidBody.velocity.y //y
            );
        }
        }else {
            makoRigidBody.velocity = new Vector2(
                0 , //x
                makoRigidBody.velocity.y //y
            );
        }
       
    }
    void Walk()
    {
        
        //para caminar se necesita cambiar el valor en la velocidad en x por running speed
        makoRigidBody.velocity = new Vector2(
                runningSpeed*Input.GetAxis("Horizontal") , //x
                makoRigidBody.velocity.y //y
        );
        
    }

    // Method for jumping
    void Jump()
    {
        if (isTouchingGround())
        {
            
            makoRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
        
        //cada vez que toque, saltará con la jump force, en modo impulso para que sea de una con toda la fuerza
    }    
    
        //así sabemos si está en el suelo y no repetir 
     bool isTouchingGround()
     {
            if(Physics2D.Raycast(this.transform.position,
                                Vector2.down,
                                1.6f, 
                                groundMask)){
                ;
                return true;
                
                
            }else {
                
                
                return false;
                
            }
    }
                
    public void Die(){
        this.makoAnimator.SetBool(STATE_LIVE, false);
        GameManager.sharedInstance.GameOver();
    } 
    

}
