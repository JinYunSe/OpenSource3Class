using Cinemachine;
using Photon.Pun;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
            _input = GetComponent<GunAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
            pv = GetComponent<PhotonView>();
            gun = transform.Find("MARMO3").GetComponent<Gun>();
            if (!pv.IsMine) return;
        }

        private void Update()
        {
            if (!pv.IsMine) return;
            Move();
            MouseLeft();
        }

        public void MouseLeft()
        {
            if (_input.mouseLeft)
            {
                gun.Shoot();
            }
        }
        public void EndMouseLeft()
        {
            _input.mouseLeft = false; gameObject.SetActive(true);
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
