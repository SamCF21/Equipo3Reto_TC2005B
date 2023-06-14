using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum PrefabType { Text, Button }

public class TMPro_Test : MonoBehaviour
{
    [SerializeField] PrefabType type;
    [SerializeField] GameObject textPrefab;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform contentTransform;
    [SerializeField] TextMeshProUGUI showField;

    public void LoadNames(SesionList allSesiones)
    {
        ClearContents();
        GameObject uiItem;
        for (int i=0; i<allSesiones.sesiones.Count; i++) {
            // Create new GUI objects
            if (type == PrefabType.Button) {
                uiItem = Instantiate(buttonPrefab);
            } else {
                uiItem = Instantiate(textPrefab);
            }
            // Add them to the ScollView content
            uiItem.transform.SetParent(contentTransform);

            // Set the position of each element
            RectTransform rectTransform = uiItem.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2 (0, -50 * i);

            // Extract the text from the argument object
            Sesion s = allSesiones.sesiones[i];
            //Debug.Log("ID: " + us.id_users + " | " + us.name + " " + us.surname);

            if (type == PrefabType.Button) {
                // Set the text
                TextMeshProUGUI field = uiItem.GetComponentInChildren<TextMeshProUGUI>();
                field.text = "Sesion " + s;
                // Set the callback
                Button btn = uiItem.GetComponent<Button>();
		        //btn.onClick.AddListener(delegate {ShowPerson(pc.color_ojos + " " + pc.color_piel); });
            }else if (type == PrefabType.Text) {
                TextMeshProUGUI field = uiItem.GetComponent<TextMeshProUGUI>();
                field.text = "Sesion " + s;
            }
        }
    }

    // Delete any child objects
    void ClearContents()
    {
        foreach (Transform child in contentTransform) {
            Destroy(child.gameObject);
        }
    }

    void ShowPerson(string colors)
    {
        showField.text = "Chef looks: " + colors + "!";
    }
}
