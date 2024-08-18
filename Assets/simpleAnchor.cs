using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class simpleAnchor : MonoBehaviour
{

    public string tagToAnchor = "gobj"; // The tag to find and anchor
    public ARSessionOrigin arSessionOrigin;
    public ARAnchorManager anchorManager;

    void Start()
    {
        //arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
        //anchorManager = FindObjectOfType<ARAnchorManager>();

        if (arSessionOrigin == null || anchorManager == null)
        {
            Debug.LogError("ARSessionOrigin or ARAnchorManager not found in the scene.");
            return;
        }

        AnchorTaggedObjects();
    }

    private void AnchorTaggedObjects()
    {
        // Find all objects with the specified tag
        GameObject[] objectsToAnchor = GameObject.FindGameObjectsWithTag(tagToAnchor);

        foreach (GameObject obj in objectsToAnchor)
        {
            // Create a pose based on the object's current position
            Pose pose = new Pose(obj.transform.position, obj.transform.rotation);

            // Create anchor
            ARAnchor anchor = anchorManager.AddAnchor(pose);

            if (anchor != null)
            {
                // Ensure the object is not already parented to another anchor
                if (obj.transform.parent != null && obj.transform.parent.GetComponent<ARAnchor>() != null)
                {
                    Debug.LogWarning($"Object {obj.name} is already parented to another anchor.");
                    continue; // Skip this object
                }

                // Set the object's parent to the ARAnchor
                obj.transform.parent = anchor.transform;

                // Adjust local position and rotation to ensure correct alignment
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.LogError($"Failed to create anchor for object {obj.name}.");
            }
        }
    }
}