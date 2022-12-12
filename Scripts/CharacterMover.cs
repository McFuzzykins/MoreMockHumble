using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour, ICharacterMover
{
    private CharacterController cont;

    [SerializeField]
    private bool isPlayer;
    public bool IsPlayer => isPlayer;

    public int Health { get; set; }
    private int speed = 5;

    private void Awake()
    {
        cont = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        Move();
        /* float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        cont.Move(new Vector3(horizontal, 0, vertical)); */
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
