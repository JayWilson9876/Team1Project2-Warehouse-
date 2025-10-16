using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour
{
    Image uiImage;

    void Start()
    {
        uiImage = GetComponent<Image>();
    }

    void Update()
    {
        if (uiImage.sprite == null)
        {
            uiImage.enabled = false;
        }
        else
        {
            uiImage.enabled = true;
        }
    }
}
