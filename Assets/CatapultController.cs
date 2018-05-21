using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatapultController : MonoBehaviour {

    public Camera ControlCamera;

    public Camera AmmoCamera;

    public Slider TensionSlider;

    public GameObject Arm;

    public SpringJoint FiringSpring;

    public SpringJoint RestraintSpring;

    public List<SpringJoint> SpringJoints;
    public bool camSwitch = true;

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
        Destroy(RestraintSpring);
    }
    
    public void GetTension(float Tension)
    {
        FiringSpring.spring = TensionSlider.value;
    }
}
