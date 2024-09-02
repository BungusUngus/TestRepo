using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    private bool facingRight;
    private bool facingUp;
    [SerializeField] Vector2 targetPosition;
    float lerpSpeed = 0.05f;


    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float blend = Mathf.Pow(0.5f, Time.deltaTime * lerpSpeed);
        transform.position = Vector2.Lerp(targetPosition, transform.position, blend);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;
    }
}
 