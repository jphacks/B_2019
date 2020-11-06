using System;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

namespace KiliWare.SampleVRMApp
{
    public class TransformController : MonoBehaviour
    {
        static int VrmControllingObjectNumber;
        [SerializeField] int vrmObjectNumber;
        private Animation animation;
        private Animator animator;
        private GameObject animatorControllerDropdownGameObject;
        private TMP_Dropdown animatorControllerDropdown;
        private int previousAnimatorControllerDrowdownValue;

        protected float _rotationSpeed = 3;
        protected float _moveSpeed = 3;

        private void Start()
        {
            VrmControllingObjectNumber++;
            vrmObjectNumber = VrmControllingObjectNumber;
            animation = GetComponent<Animation>();
            animator = GetComponent<Animator>();
            animation.playAutomatically = true;
            transform.Rotate(0f,180f,0f);
            animatorControllerDropdownGameObject = GameObject.Find("AnimatorControllerDropdown");
            animatorControllerDropdown = animatorControllerDropdownGameObject.GetComponent<TMP_Dropdown>();
            previousAnimatorControllerDrowdownValue = animatorControllerDropdown.value;
            ChangedAnimatorControllerDropdownValue();
        }

        void Update()
        {
            if (VrmControllingObjectNumber != vrmObjectNumber)
            {
                return;
            }
            
            if (previousAnimatorControllerDrowdownValue != animatorControllerDropdown.value)
            {
                previousAnimatorControllerDrowdownValue = animatorControllerDropdown.value;
                ChangedAnimatorControllerDropdownValue();
            }

            // if (Input.GetKey(KeyCode.Mouse0))
            // {
            //     Rotate(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
            // }
            // if (Input.GetKey(KeyCode.Mouse1))
            // {
            //     Move(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
            // }

            if (Input.GetKey(KeyCode.U))
            {
                transform.Rotate(new Vector3(0f, 2f,0f));
            }
            if (Input.GetKey(KeyCode.O))
            {
                transform.Rotate(new Vector3(0f, -2f,0f));
            }
            if (Input.GetKey(KeyCode.I))
            {
                transform.Rotate(new Vector3(2f, 0f,0f));
            }
            if (Input.GetKey(KeyCode.K))
            {
                transform.Rotate(new Vector3(-2f, 0f,0f));
            }
            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(new Vector3(0f, 0f,-2f));
            }
            if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(new Vector3(0f, 0f,2f));
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-0.01f, 0f,0f), Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(0.01f, 0f,0f), Space.World);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0f, 0.01f,0f), Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0f, -0.01f,0f), Space.World);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(new Vector3(0f, 0,-0.01f), Space.World);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(new Vector3(0f, 0,0.01f), Space.World);
            }

        }

        private void ChangedAnimatorControllerDropdownValue()
        {
            switch (animatorControllerDropdown.value)
            {
                case 0:
                    animator.runtimeAnimatorController =  null;
                    break;
                case 1:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerArmStretching"));
                    break;
                case 2:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerCards"));
                    break;
                case 3:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerDancing"));
                    break;
                case 4:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerHapplyIdle"));
                    break;
                case 5:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerOrcIdle"));
                    break;
                case 6:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerSitting"));
                    break;
                case 7:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerSittingClap"));
                    break;
                case 8:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerThumbsUp"));
                    break;
                case 9:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerSittingYell"));
                    break;
                case 10:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerStandingWBriefcaseIdle"));
                    break;
                case 11:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerTaunt"));
                    break;
                case 12:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerTextingWhileStanding"));
                    break;
                case 13:
                    animator.runtimeAnimatorController =  (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load ("AnimatorControllers/AnimatorControllerThankful"));
                    break;
                default:
                    break;
            }
        }

        public void SetSpeed(float rotation, float move)
        {
            _rotationSpeed = rotation;
            _moveSpeed = move;
        }

        // From https://teratail.com/questions/147069#reply-221677
        protected void Rotate(Vector2 delta)
        {
            float deltaAngle = delta.magnitude * _rotationSpeed;

            if (Mathf.Approximately(deltaAngle, 0.0f))
            {
                return;
            }

            var cameraTransform = Camera.main.transform;
            var deltaWorld = cameraTransform.right * delta.x + cameraTransform.up * delta.y;
            var axisWorld = Vector3.Cross(deltaWorld, cameraTransform.forward).normalized;

            transform.Rotate(axisWorld, deltaAngle, Space.World);
        }

        protected void Move(Vector2 delta)
        {
            var cameraTransform = Camera.main.transform;
            var deltaWorld = cameraTransform.right * delta.x + cameraTransform.up * delta.y;

            transform.Translate(deltaWorld * _moveSpeed * Time.deltaTime, Space.World);
        }
    }
}