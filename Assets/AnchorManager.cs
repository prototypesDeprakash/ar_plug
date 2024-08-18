using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AnchorManager : MonoBehaviour
{
    public GameObject objectToAnchor; // The object you want to anchor

    private ARAnchorManager anchorManager;
    private ARSessionOrigin arSessionOrigin;

    void Start()
    {
        anchorManager = FindObjectOfType<ARAnchorManager>();
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>();

        if (anchorManager == null || arSessionOrigin == null)
        {
            Debug.LogError("ARAnchorManager or ARSessionOrigin not found in the scene.");
            return;
        }

        // Create a new anchor at the object's position
        CreateAnchor();
    }

    private void CreateAnchor()
    {
        if (anchorManager == null) return;

        // Use the current position and rotation of the object
        Pose pose = new Pose(objectToAnchor.transform.position, objectToAnchor.transform.rotation);
        ARAnchor anchor = anchorManager.AddAnchor(pose);

        if (anchor != null)
        {
            // Set the object's parent to the ARAnchor
            objectToAnchor.transform.parent = anchor.transform;
            objectToAnchor.transform.localPosition = Vector3.zero;
            objectToAnchor.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogError("Failed to create anchor.");
        }
    }
}
