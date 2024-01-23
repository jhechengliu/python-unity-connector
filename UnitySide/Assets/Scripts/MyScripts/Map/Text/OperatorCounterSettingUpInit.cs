using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OperatorCounterSettingUpInit : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private UserRegister userRegister;

    private void Start()
    {
        text.text = $"Unplaced Operators: {userRegister.GetMaxOperatorCount()}";
    }
}
