using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TriLibCore.Samples
{
    public class LoadModelFromURLSample : MonoBehaviour
    {
        public TMP_InputField Inputfield;
        public Button loadButton; // Reference to the Button

        private void Start()
        {
            // Add a listener to the button to call LoadModel when clicked
            if (loadButton != null)
            {
                loadButton.onClick.AddListener(LoadModel);
            }
        }

        public  void LoadModel()
        {
            // Ensure the button click event triggers the model loading
            var assetLoaderOptions = AssetLoader.CreateDefaultLoaderOptions();
            var webRequest = AssetDownloader.CreateWebRequest(Inputfield.text);
            AssetDownloader.LoadModelFromUri(webRequest, OnLoad, OnMaterialsLoad, OnProgress, OnError, null, assetLoaderOptions);
        }

        private void OnError(IContextualizedError obj)
        {
            Debug.LogError($"An error occurred while loading your Model: {obj.GetInnerException()}");
        }

        private void OnProgress(AssetLoaderContext assetLoaderContext, float progress)
        {
            Debug.Log($"Loading Model. Progress: {progress:P}");
        }

        private void OnMaterialsLoad(AssetLoaderContext assetLoaderContext)
        {
            Debug.Log("Materials loaded. Model fully loaded.");
        }

        private void OnLoad(AssetLoaderContext assetLoaderContext)
        {
            Debug.Log("Model loaded. Loading materials.");
        }
    }
}
