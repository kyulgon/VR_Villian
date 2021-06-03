using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController_G : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    
    [SerializeField]
    private List<GameObject> controllerModels; // 컨트롤러 모델 여러개 받기 위한 변수
    private GameObject controllerInstance; // Instantiate로 생성할 변수
    private InputDevice availableDevice; // 사용하고 있는 디바이스 확인할 변수

    public bool renderController; // Hand와 Controller 사이를 변경할 변수
    public GameObject handmodel; // 핸드 모델 프리팹
    private GameObject handInstance; // 핸드 인스턴스
    private Animator handModelAnimator; // 핸드 모델 애니메이션 변수

    void Start()
    {
        TryInitialize();        
    }

    private void Update()
    {
        Debug.Log(Time.deltaTime);

        if(!availableDevice.isValid)
        {
            TryInitialize();
            return;
        }

        if(renderController)
        {
            handInstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handInstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation();
        }
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>(); // devices라는 리스트 만듦 (타입은 : InputDevice)
                                                             // 
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices); // 오른쪽 컨트롤러를 입력받기 위해 사용
        
        foreach (var device in devices) // device를 모두 검사하여 디버그 찍어줌
        {
            Debug.Log($"Available Device Name : {device.name}, Characteristic : {device.characteristics}");
            Debug.Log(devices.Count);
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
                Debug.LogError("적합한 디바이스가 없습니다!");
                controllerInstance = Instantiate(controllerModels[0], transform);
            }

            handInstance = Instantiate(handmodel, transform); // 핸드 인스턴스추가
            handModelAnimator = handInstance.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation() // Trigger, Grip 애니메이션 value값 넣기
    {
        if(availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) 
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }

        if(availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}
