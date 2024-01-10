using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMove), typeof(PlayerAttack))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private GameObject _camera, _player;

    private PlayerMove _playerMove;
    private PlayerAttack _playerAttack;
    private Animator _anim;

    private const string _moveXN = "MoveX", _moveYN = "MoveY", _camYN = "CamY";

    private void Start()
    {
        _anim ??= GetComponent<Animator>();
        _playerMove ??= GetComponent<PlayerMove>();
        _playerAttack ??= GetComponent<PlayerAttack>();

        _playerMove.Moved += Move;
        _playerMove.Crouched += Crouch;

        _playerAttack.Attacked += Attack;
    }

    private void Attack()
    {
    }

    private void Move()
    {
        _anim.SetFloat(_moveXN, _playerMove._dirX);
        _anim.SetFloat(_moveYN, _playerMove._dirY);

        float camRotY = _camera.transform.eulerAngles.x;
        if (camRotY < 200)
            camRotY += 360;

        _anim.SetFloat(_camYN, camRotY);
    }
    private void Crouch()
    {
    }
}
