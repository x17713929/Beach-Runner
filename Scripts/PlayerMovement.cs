using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private bool grounded;
    private Vector3 fp;
    private Vector3 lp;
    private float dragDistance;
    public Rigidbody rb;
    private Animator anim;
    public float forwardSpeed;
    public float sideSpeed;
    public float jumpSpeed;
    //-1.4 1.4
    //use for initial
    private void Start()
    {
        grounded = true;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        dragDistance = Screen.height * 15 / 100;
    }

    private void Update()
    {
     
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && grounded == false)
        {
            grounded = true;
            anim.SetTrigger("Grounded");
        }
    }

    //update is called once per frame
    private void FixedUpdate()
    {
        Vector3 deltaPosition = transform.forward * forwardSpeed;
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width * 0.5f)
                deltaPosition += transform.right * sideSpeed;
            else
                deltaPosition -= transform.right * sideSpeed;
        }

        transform.position += deltaPosition * Time.deltaTime;

        if (Input.touchCount == 1) 
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began) 
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) 
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) 
            {
                lp = touch.position;  

                
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   
                        if ((lp.x > fp.x))  
                        {   
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   
                        if (lp.y > fp.y)  
                        {   
                            rb.AddForce(new Vector3(0, 2, 0) * jumpSpeed, ForceMode.Impulse);
                            anim.SetTrigger("Jump");
                            grounded = false;
                            FindObjectOfType<AudioManager>().Play("Jump");
                        }
                        else
                        {   
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   
                    Debug.Log("Tap");
                }
            }
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }



    }


}
