using Cinemachine;
using Photon.Pun;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class LeeGangHyeonThirdPersonController : MonoBehaviour
    {
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        private PlayerInput _playerInput;
#endif
        private GunAssetsInputs _input;
        private Gun gun;
        private PhotonView pv;
        [SerializeField]
        private SphereCollider sphereCollider;
        private bool _hasAnimator;
        private Animator _animator;
        private bool isMouseLeft = false;

        private int _animIDRifleAim;
        private int _animIDRifleFire;

        public Text nickNameUI;

        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
            }
        }

        private void Start()
        {
            _hasAnimator = TryGetComponent(out _animator);
            _input = GetComponent<GunAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
            AssignAnimationIDs();
            pv = GetComponent<PhotonView>();
            nickNameUI.text = pv.Owner.NickName;
            gun = transform.Find("MARMO3").GetComponent<Gun>();
        }

        private void Update()
        {
            if (!pv.IsMine) return;
            Move();
            MouseLeft();
        }

        public void MouseLeft()
        {
            if (_hasAnimator &&_input.mouseLeft && !isMouseLeft)
            {
                gun.Shoot();
                _animator.SetTrigger(_animIDRifleFire);
                isMouseLeft = true;
            }
        }
        private void OnCollider()
        {
            sphereCollider.enabled = true;
        }
        private void OffCollider()
        {
            sphereCollider.enabled = false;
        }
        public void EndMouseLeft()
        {
            isMouseLeft = false;
            _input.mouseLeft = false;
        }

        private void AssignAnimationIDs()
        {
            _animIDRifleFire = Animator.StringToHash("RifleFire");
        }

        private void Move()
        {
            if (_input.A)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, -10f, 0f));
            }
            else if (_input.D)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 10f, 0f));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
        }
    }
}
