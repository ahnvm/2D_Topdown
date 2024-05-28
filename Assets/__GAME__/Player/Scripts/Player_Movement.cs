using System.Collections;
using System.Collections.Generic;
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
    #endregion

    #region  Initialization
    private void Update()
    {
        Get_Input();
    }

    private void FixedUpdate()
    {
        Movement_Update();
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
}