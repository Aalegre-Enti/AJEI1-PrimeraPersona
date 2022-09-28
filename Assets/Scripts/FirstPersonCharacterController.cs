using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour
{
    [Header("Model")]
    public GameObject character;

    [Header("Movimiento")]
    public float velocidad = 10;
    [Range(1f, 2f)]
    public float groundCheck = 1.1f;
    public bool grounded;
    public float jumpStrength = 100;
    public float jetpackStrength = 100;
    float jumpCounter;
    float deposit = 1;
    public Rigidbody rb;

    [Header("Camara")]
    public Camera camera;
    public float sensitividad_vertical = 1000;
    public float sensitividad_horizontal = 1000;
    public float vertical_max = 80;
    public float vertical_min = -80;
    float rotacion_horizontal;
    float rotacion_vertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheck))
        {
            grounded = true;
            Debug.DrawRay(transform.position, -transform.up * groundCheck, Color.green);
        }
        else
        {
            grounded = false;
            Debug.DrawRay(transform.position, -transform.up * groundCheck, Color.red);
        }

    }

    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * sensitividad_horizontal * Time.deltaTime;
        rotacion_horizontal = rotacion_horizontal + mouse_x;
        transform.eulerAngles = new Vector3(0, rotacion_horizontal, 0);



        float movimiento_horizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float movimiento_vertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        transform.position = transform.position + (transform.forward * movimiento_vertical) + (transform.right * movimiento_horizontal);

        Jump();
        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded && jumpCounter <= 0)
        {
            jumpCounter = .25f;
            rb.AddForce(transform.up * jumpStrength);
        }
        jumpCounter = jumpCounter - Time.deltaTime;
        if (grounded)
        {
            deposit = Mathf.Clamp01(deposit + Time.deltaTime);
        }
        else
        {
            if (Input.GetButton("Jump") && deposit > 0 && jumpCounter <= 0)
            {
                deposit -= Time.deltaTime;
                rb.AddForce(transform.up * jetpackStrength * Time.deltaTime);
            }
        }
    }
    void LateUpdate()
    {
        float mouse_y = Input.GetAxis("Mouse Y") * sensitividad_vertical * Time.deltaTime;
        rotacion_vertical = Mathf.Clamp(rotacion_vertical + mouse_y, vertical_min, vertical_max);
        camera.transform.localEulerAngles = new Vector3(rotacion_vertical, 0, 0);
    }
}
