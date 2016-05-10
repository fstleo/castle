using UnityEngine;
using System.Collections;

public class StickmanFly : MonoBehaviour {

    BoxCollider2D coll;
    Camera mainCamera;
    public float deadlyHeight = 5;
    public float startHeight = 0;
    bool isPinned = false;
    public bool isDead
    { get; private set; }
    StickmanAnim anim;
    Rigidbody2D rbody;
    public Vector3 rightBorderPos;
    Vector3 leftBorderPos;
#if UNITY_STANDALONE || UNITY_EDITOR
    Vector3 prevMousePos;
#else
    Vector2 prevMousePos;

    Vector2 touchDelta;
#endif

    void SetAnimator(StickmanAnim an)
    {
        anim = an;
        mainCamera = Camera.main;
        startHeight = transform.position.y;
        rbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        leftBorderPos = mainCamera.ViewportToWorldPoint(Vector3.zero);
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorderPos.x, rightBorderPos.x), transform.position.y, 0);
        if ((!isPinned) && (transform.position.y - startHeight > deadlyHeight))
            isDead = true;

        if (isPinned)
        {
#if UNITY_STANDALONE || UNITY_EDITOR 
            if (!Input.GetMouseButton(0))
            {
#else
            if (Input.touchCount == 0)
            {
#endif
                isPinned = false;
                coll.enabled = true;
#if UNITY_STANDALONE || UNITY_EDITOR
                SoundPlayer.PlaySound("flight_scream");
                rbody.AddForce((Input.mousePosition - prevMousePos) * 30);
#else
                rbody.AddForce((touchDelta) * 500);
                SoundPlayer.PlaySound("flight_scream");
#endif
            }
            else
            {
#if UNITY_STANDALONE || UNITY_EDITOR
                Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.Set(Mathf.Clamp(mousePos.x, leftBorderPos.x, rightBorderPos.x), Mathf.Max(startHeight, mousePos.y), 0);
#else
                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    rbody.AddForce((Input.touches[0].deltaPosition) * 1000);
                    SoundPlayer.PlaySound("flight_scream");
                }
                    
                Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
                touchDelta = Input.touches[0].deltaPosition;
#endif
                transform.position = mousePos;
                isDead = false;
#if UNITY_STANDALONE || UNITY_EDITOR
                prevMousePos = Input.mousePosition;
                //prevMousePos = Input.GetTouch(0).position;
#endif
            }
        }
#if !(UNITY_STANDALONE || UNITY_EDITOR)
        else
        {
            touchDelta = Vector2.zero;
        }
#endif
    }

    void Run()
    {
        rbody.velocity = Vector2.zero;
    }

    public void Catch()
    {
        if (Time.timeScale < 0.5f)
            return;
        //Debug.Log("Pin");
        isPinned = true;
        gameObject.SendMessage("Stop");
        anim.Fly();
        coll.enabled = false;
#if UNITY_STANDALONE || UNITY_EDITOR
        prevMousePos = Input.mousePosition;
#else
        prevMousePos = Input.GetTouch(0).position;
#endif
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (isPinned)
        {
            isPinned = false;
        }            
        if (other.transform.CompareTag("Level"))
        {
            if (isDead)
            {
                SoundPlayer.PlaySound("fall_scream");
                anim.Die();                
                Counter.Instance.StickmanDeath();
            }                
            else
            {
                anim.StandUp();                
            }
                
        }
    }


}
