using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class CustomController_B : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    [SerializeField]
    private List<GameObject> controllerModels;
    private GameObject controllerInstance;
    private InputDevice availableDevice;

    public bool renderController; // Hand�� Controller ���̸� ������ ����
    public GameObject handModel; // �ڵ� �� prefab
    private GameObject handInstance; // �ڵ� �ν��Ͻ�

    private Animator handModelAnimator;// �ڵ� �� �ִϸ��̼� ����
    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }
    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        // ���� ����Ʈ ����̽��� XR ��Ŷ���� ��ŧ���� ��ġ (������)���� �ν��� �ϰ� ����
        foreach (var device in devices)
        {
            Debug.Log($"������ ����̽� �̸�: {device.name}, Ư¡: {device.characteristics}");
            Debug.Log(devices.Count);
        }
        if (devices.Count > 0)
        {
            availableDevice = devices[0];
            GameObject currentControllerModel;
            //string name = "";
            if (availableDevice.name.Contains("Left"))
            {
                currentControllerModel = controllerModels[1];
            }
            else if (availableDevice.name.Contains("Right"))
            {
                currentControllerModel = controllerModels[2];
            }
            else
            {
                currentControllerModel = null;
            }
            //GameObject currentControllerModel = controllerModels.Find(controller => controller.name == name);
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            else
            {
                Debug.LogError("������ ����̽��� �����ϴ�!");
                controllerInstance = Instantiate(controllerModels[0], transform);
            }
            handInstance = Instantiate(handModel, transform); // �ڵ� �ν��Ͻ� �߰�
            handModelAnimator = handInstance.GetComponent<Animator>();
        }


    }
    //void TryInitialize()
    //{
    //    List<InputDevice> devices = new List<InputDevice>();
    //    InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
    //    foreach(var device in devices)
    //    {
    //        Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
    //        Debug.Log(devices.Count);
    //    }
    //    if(devices.Count > 0)
    //    {
    //        availableDevice = devices[0];
    //        string name = "";
    //        if("Oculus Touch Controller - Left" == availableDevice.name)
    //        {
    //            name = "Oculus Quest Controller - Left";
    //        }
    //        else if("Oculus Touch Controller - Right" == availableDevice.name)
    //        {
    //            name = "Oculus Quest Controller - Right";
    //        }
    //        GameObject currentControllerModel = controllerModels.Find(controller => controller.name == name);//�ȵǸ� �Ǹ������� availableDevice.name���� �ٲٱ�
    //        if (currentControllerModel)
    //        {
    //            controllerInstance = Instantiate(currentControllerModel, transform);
    //        }
    //        else
    //        {
    //            Debug.LogError("Didn't get suitable controller model");
    //            controllerInstance = Instantiate(controllerModels[0], transform);
    //        }
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        if (!availableDevice.isValid)
        {
            TryInitialize();

            //return;
      
        }
        if(handInstance!=null)
        {
            if (renderController)
            {
                handInstance.SetActive(false);
                controllerInstance.SetActive(true);
            }
            else
            {
                handInstance.SetActive(true);
                controllerInstance.SetActive(false);
                UpdateHandAnimation();//�ڵ� �ִϸ��̼��� ���⼭�� ����
            }
        }
       
    }
    void UpdateHandAnimation()
    {
        if (availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
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
    //void UpdateHandAnimation()
    //{
    //    if(availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
    //    {
    //        handModelAnimator.SetFloat("Trigger", triggerValue);
    //    }
    //    else
    //    {
    //        handModelAnimator.SetFloat("Trigger", 0);
    //    }
    //    if(availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
    //    {
    //        handModelAnimator.SetFloat("Grip", gripValue);
    //    }
    //    else
    //    {
    //        handModelAnimator.SetFloat("Grip", 0);
    //    }
    //}
}