using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController_A : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    [SerializeField]
    private List<GameObject> controllerModels;
    private GameObject controllerInstance;
    private InputDevice availableDevice;

    public bool renderController; // hand와 controller 사이를 변경할 변수
    public GameObject handModel; // hand 모델 프리펩
    private GameObject handInstance; // 핸드 인스턴스

    private Animator handModelAnimator; // 핸드 모델 애니메이션 변수

    //[SerializeField]
    //private GameObject Gun; // 컨트롤러로 잡을 오브젝트
    //[SerializeField]
    //private GameObject Sword; // 컨트롤러로 잡을 오브젝트
    //[SerializeField]
    //private GameObject Grenade; // 컨트롤러로 잡을 오브젝트

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
       
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        // 오른쪽 컨트롤러를 입력받기 위해 사용하는 것
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        foreach (var device in devices)
        {
            Debug.Log($"Available Device Name: {device.name}, Characteristic: {device.characteristics}");
        }
        if (devices.Count > 0)
        {
            availableDevice = devices[0];
            GameObject currentControllerModel;
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
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            else
            {
                  // Debug.LogError("Didn't get suitable controller model");
                 controllerInstance = Instantiate(controllerModels[0], transform);
                controllerInstance = Instantiate(currentControllerModel, transform);
            }

            handInstance = Instantiate(handModel, transform); // 핸드 인스턴스 추가
            handModelAnimator = handInstance.GetComponent<Animator>();
        }

    }
    // Update is called once per frame
     
    void Update()
    {
        if (!availableDevice.isValid)
        {
            TryInitialize();
          return;
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
            UpdateHandAnimation(); // 핸드 애니메이션은 여기서만 수행

        }



        //if (Gun != null)           // 게임 오브젝트 컨트롤러로 잡으면 삭제!!!!
        //{
        //    Debug.Log("cube in");

        //    bool menuButtonValue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.gripButton, out menuButtonValue) && menuButtonValue)
        //    {
        //        Debug.Log("availableDevice.TryGetFeatureValue ");

        //        Destroy(Gun.gameObject);

        //    }
        //}



        //if (Sword != null)           // 게임 오브젝트 컨트롤러로 잡으면 삭제!!!!
        //{
        //    Debug.Log("cube in");

        //    bool menuButtonValue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.gripButton, out menuButtonValue) && menuButtonValue)
        //    {
        //        Debug.Log("availableDevice.TryGetFeatureValue ");
        //        Destroy(Sword.gameObject);

        //    }
        //}

        //if (Grenade != null)           // 게임 오브젝트 컨트롤러로 잡으면 삭제!!!!
        //{
        //    Debug.Log("cube in");

        //    bool menuButtonValue;
        //    if (availableDevice.TryGetFeatureValue(CommonUsages.gripButton, out menuButtonValue) && menuButtonValue)
        //    {
        //        Debug.Log("availableDevice.TryGetFeatureValue ");
        //        Destroy(Grenade.gameObject);

        //    }
        //}
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
}
