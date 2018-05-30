using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatapultController : MonoBehaviour {

    public Camera ControlCamera;

    public Camera AmmoCamera;
    public Camera MoveCamera;

    public Rigidbody mainRigidbody;

    public Slider TensionSlider;

    public Slider RestraintTensionSlider;

    public Slider MoveSlider;

    public Slider RotateSlider;
    public GameObject Arm;

    public SpringJoint FiringSpring;
    public SpringJoint FiringSpring2;

    public SpringJoint RestraintSpring;

    public List<SpringJoint> SpringJoints;
    public bool camSwitch = true;
    public GameObject RotationPoint;

    private Vector3 vectorZero = new Vector3(0.001f, 0.001f, 0.001f);

    private int CameraNumber = 0;
    private void Start()
    {
        //MoveSlider.value = transform.position.x;
       // RotateSlider.value = transform.rotation.y;

        SpringJoints.AddRange(Arm.GetComponents<SpringJoint>());

        for (int i = 0; i < SpringJoints.Capacity; i++)
        {
            if(SpringJoints[i].connectedBody.gameObject.name == "Anchor2")
            {
                FiringSpring = SpringJoints[i];
            }

            else
            {
                RestraintSpring = SpringJoints[i];
            }
        }
    }

    void ResetCatapult()
    {

    }

    public void SwitchCamera()
    {
        CameraNumber++;

        if (CameraNumber > 3)
        {
            CameraNumber = 1;
        }
        switch (CameraNumber)
        {
            case 1:
                ControlCamera.gameObject.SetActive(true);
                AmmoCamera.gameObject.SetActive(false);
                MoveCamera.gameObject.SetActive(false);
                break;
            case 2:
                ControlCamera.gameObject.SetActive(false);
                AmmoCamera.gameObject.SetActive(true);
                MoveCamera.gameObject.SetActive(false);
                break;
            case 3:
                ControlCamera.gameObject.SetActive(false);
                AmmoCamera.gameObject.SetActive(false);
                MoveCamera.gameObject.SetActive(true);
                break;
            default:
                ControlCamera.gameObject.SetActive(false);
                AmmoCamera.gameObject.SetActive(false);
                MoveCamera.gameObject.SetActive(false);
            break;
        }
      

    }

    public  void fireCatapult()
    {
        RestraintSpring.spring = 0;
        RestraintTensionSlider.value = 0;
        mainRigidbody.AddForce(vectorZero);
    }
    public void GetMove(float Move)
    {
        //RotationPoint.transform.Translate = 
        RotationPoint.transform.position = new Vector3(MoveSlider.value, RotationPoint.transform.position.y, RotationPoint.transform.position.z);
    }

    public void GetRotate(float Rotate)
    {
        //transform.RotateAround(RotationPoint.transform.position, Vector3.down, RotateSlider.value);
        //transform.Rotate(new Vector3(transform.rotation.x, RotateSlider.value, transform.rotation.z));
        //transform.rotation = Quaternion.Euler(transform.rotation.x, RotateSlider.value, transform.rotation.z);
        RotationPoint.transform.eulerAngles = (new Vector3(transform.rotation.x, RotateSlider.value, transform.rotation.z));
    }
    public void GetTension(float Tension)
    {
        FiringSpring.spring = TensionSlider.value;

        mainRigidbody.AddForce(vectorZero);
    }

    public void GetRestraintTension(float Tension)
    {
        RestraintSpring.spring = RestraintTensionSlider.value;
        mainRigidbody.AddForce(vectorZero);
    }
}
