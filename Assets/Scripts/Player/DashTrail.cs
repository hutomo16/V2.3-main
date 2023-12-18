using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTrail : MonoBehaviour
{
    [SerializeField]
    private GameObject hierarchyRoot;

    [SerializeField]
    private float activationTime = 1f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            StartCoroutine(ActivateHierarchyForDuration());
        }
    }

    IEnumerator ActivateHierarchyForDuration()
    {
        ActivateHierarchy();
        yield return new WaitForSeconds(activationTime);
        DeactivateHierarchy();
    }

    void ActivateHierarchy()
    {
        if (hierarchyRoot != null)
        {
            hierarchyRoot.SetActive(true);
        }
        else
        {
            Debug.LogError("Hierarchy root is not assigned!");
        }
    }

    void DeactivateHierarchy()
    {
        if (hierarchyRoot != null)
        {
            hierarchyRoot.SetActive(false);
        }
        else
        {
            Debug.LogError("Hierarchy root is not assigned!");
        }
    }
}
