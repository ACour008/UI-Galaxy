using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISelectionRotator : MonoBehaviour
{
    [SerializeField] Image insideSelection;
    [SerializeField] Image outsideSelection;
    [SerializeField] float outsideRotationSpeed;
    [SerializeField] float insideRotationMultiplier;

    private bool shouldRotate;

    private void Update()
    {
        if (shouldRotate)
        {
            outsideSelection.transform.Rotate(new Vector3(0, 0, outsideRotationSpeed) * Time.deltaTime);
            insideSelection.transform.Rotate(new Vector3(0, 0, -(outsideRotationSpeed * insideRotationMultiplier) * Time.deltaTime));
        }
    }

    private void OnEnable() => shouldRotate = true;

    private void OnDisable() => shouldRotate = false;
}
