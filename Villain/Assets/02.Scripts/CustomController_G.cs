using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController_G : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;

    [SerializeField]
    private List<GameObject> controllerModels; // ��Ʈ�ѷ� �� ������ �ޱ� ���� ����
    private GameObject controllerInstance; // Instantiate�� ������ ����
    private InputDevice availableDevice; // ����ϰ� �ִ� ����̽� Ȯ���� ����

    public bool renderController; // Hand�� Controller ���̸� ������ ����
    public GameObject handmodel; // �ڵ� �� ������
    private GameObject handInstance; // �ڵ� �ν��Ͻ�
    public GameObject machineprefab; // �ӽ� ������ ��������

    private Animator handModelAnimator; // �ڵ� �� �ִϸ��̼� ����
    private Animator machineAnimatotr; // �ӽ� �ִϸ��̼� ����

    bool triggerButton;


    void Start()
    {
        
    }

    private void Update()
    {
        if (!availableDevice.isValid)
        {
            TryInitialize();
        }

        if (renderController)
        {
            handInstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handInstance.SetActive(true);
            controllerInstance.SetActive(false);

        }

        bool menuButtonValue;
        if (availableDevice.TryGetFeatureValue(CommonUsages.triggerButton, out menuButtonValue) && menuButtonValue)
        {
            if (triggerButton == false)
            {
                Debug.Log("A");
                UpdateHandAnimation();
                machineprefab.GetComponent<MachineShoot_G>().Shoot();
                triggerButton = true;
            }
        }
        else
        {
            triggerButton = false;
        }

        if (FindObjectOfType<GameManager_G>().isGameOver)
        {
            bool menuButtonValues;
            if (availableDevice.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonValues) && menuButtonValues)
            {
                FindObjectOfType<GameManager_G>().RestartGame();
            }

        }

        void TryInitialize()
        {
            List<InputDevice> devices = new List<InputDevice>(); // devices��� ����Ʈ ���� (Ÿ���� : InputDevice)
                                                                 // 
            InputDevices.GetDevicesWithCharacteristics(characteristics, devices); // ������ ��Ʈ�ѷ��� �Է¹ޱ� ���� ���

            foreach (var device in devices) // device�� ��� �˻��Ͽ� ����� �����
            {
                // Debug.Log($"Available Device Name : {device.name}, Characteristic : {device.characteristics}");
                // Debug.Log(devices.Count);
            }

            if (devices.Count > 0)
            {
                availableDevice = devices[0];
                string name = "";
                if ("Oculus Touch Controller - Left" == availableDevice.name)
                {
                    name = "Oculus Quest Controller - Left";
                }
                else if ("Oculus Touch Controller - Right" == availableDevice.name)
                {
                    name = "Oculus Quest Controller - Right";
                }

                GameObject currentControllerModel = controllerModels.Find(controller => controller.name == name);
                if (currentControllerModel)
                {
                    controllerInstance = Instantiate(currentControllerModel, transform);
                }
                else
                {
                    Debug.LogError("������ ����̽��� �����ϴ�!");
                    controllerInstance = Instantiate(controllerModels[0], transform);
                }

                handInstance = Instantiate(handmodel, transform); // �ڵ� �ν��Ͻ��߰�
                handModelAnimator = handInstance.GetComponent<Animator>();
                machineAnimatotr = machineprefab.GetComponent<Animator>();


            }
        }

        void UpdateHandAnimation() // Trigger, Grip �ִϸ��̼� value�� �ֱ�
        {
            if (availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handModelAnimator.SetFloat("Trigger", triggerValue);
                //Debug.Log("1");
                //machineprefab.GetComponent<Animator>().SetBool("Fire", true);
                //Debug.Log("2");
                //machineprefab.GetComponent<Animator>().SetBool("Fire", false);
                //Debug.Log("3");
                // handModelAnimator.SetFloat("Trigger", triggerValue);
            }
            else
            {

                handModelAnimator.SetFloat("Trigger", 0);
            }

            if (availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handModelAnimator.SetFloat("Grip", gripValue);
            }
            else
            {
                handModelAnimator.SetFloat("Grip", 0);
            }
        }

    }

}