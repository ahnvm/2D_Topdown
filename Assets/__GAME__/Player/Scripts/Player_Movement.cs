using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[SelectionBase]
public class Player_Movement : MonoBehaviour
{
    #region Editor Data
    [Header("Movement Settings")]
    [SerializeField] float _moveSpeed = 100f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D _rb;
    #endregion

    #region  Private Data
    private Vector2 _moveDir = Vector2.zero;
    Animator anim;
    #endregion

    #region  Initialization

    private void Start()
    {
        Transform tr1 = transform.Find("Visuals");
        if (tr1 != null)
        {
            Transform tr2 = tr1.Find("Character");
            if (tr2 != null)
            {
                anim = tr2.GetComponent<Animator>();
            }
        }
    }
    private void Update()
    {
        Get_Input();
    }

    private void FixedUpdate()
    {
        Movement_Update();
        anim.SetFloat("xVelocity", _moveDir.x);
        anim.SetFloat("yVelocity", _moveDir.y);
        if (_moveDir.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_moveDir.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    #endregion

    #region INPUT
    private void Get_Input()
    {
        _moveDir.x = Input.GetAxis("Horizontal");
        _moveDir.y = Input.GetAxis("Vertical");
    }
    #endregion

    #region MOVEMENT
    private void Movement_Update()
    {
        _rb.velocity = _moveDir * _moveSpeed * Time.fixedDeltaTime;
    }
    #endregion

    #region Animation

    #endregion
}