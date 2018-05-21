using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatapultController : MonoBehaviour {

    public Camera ControlCamera;

    public Camera AmmoCamera;

    public Rigidbody mainRigidbody;

    public Slider TensionSlider;

    public Slider RestraintTensionSlider;

    public GameObject Arm;

    public SpringJoint FiringSpring;

    public SpringJoint RestraintSpring;

    public List<SpringJoint> SpringJoints;
    public bool camSwitch = true;


    private Vector3 vectorZero = new Vector3(0.001f, 0.001f, 0.001f);

    private void Start()
    {
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
        camSwitch = !camSwitch;
        ControlCamera.gameObject.SetActive(camSwitch);
        AmmoCamera.gameObject.SetActive(!camSwitch);
    }

    public  void fireCatapult()
    {
        RestraintSpring.spring = 0;
        RestraintTensionSlider.value = 0;
        mainRigidbody.AddForce(vectorZero);
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
