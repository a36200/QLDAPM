using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ContextMenuAdditions {

    [MenuItem("CONTEXT/Text/Add Easy UI Style")]
    [MenuItem("CONTEXT/Button/Add Easy UI Style")]
    [MenuItem("CONTEXT/Image/Add Easy UI Style")]
    [MenuItem("CONTEXT/Toggle/Add Easy UI Style")]
    [MenuItem("CONTEXT/Slider/Add Easy UI Style")]
    [MenuItem("CONTEXT/Dropdown/Add Easy UI Style")]
    [MenuItem("CONTEXT/InputField/Add Easy UI Style")]
    [MenuItem("CONTEXT/TMP_Text/Add Easy UI Style")]
    [MenuItem("CONTEXT/TMP_InputField/Add Easy UI Style")]
    [MenuItem("CONTEXT/TMP_Dropdown/Add Easy UI Style")]
    static void AddButtonStyle(MenuCommand command)
    {
        //if style chooser on object then don't add style - its already added
        //add styles

        if (command.context.GetType() == typeof(Text))
        {
            Text text = (Text)command.context;
            if (!HasStyleChooser(text.gameObject) || GetIndex(command) == text.GetComponent<StyleChooser>().textStyleIndex)
                EasyUIStyle.AddStyle(text);
            else
            {
                OpenEditorWindow();
                EasyUIStyle.thisType = EasyUIStyle._type.Text;
                EasyUIStyle.MaximizeAll(EasyUIStyle.thisType, false);
                EasyUIStyle.OpenStyle(EasyUIStyle.thisType, text.GetComponent<StyleChooser>().textStyleIndex);
            }
        }
        else if (command.context.GetType() == typeof(Image))
        {
            Image image = (Image)command.context;
            if (!HasStyleChooser(image.gameObject) || GetIndex(command) == image.GetComponent<StyleChooser>().imageStyleIndex)
                EasyUIStyle.AddStyle(image);
            else
            {
                OpenEditorWindow();
                EasyUIStyle.thisType = EasyUIStyle._type.Image;
                EasyUIStyle.MaximizeAll(EasyUIStyle.thisType, false);
                EasyUIStyle.OpenStyle(EasyUIStyle.thisType, image.GetComponent<StyleChooser>().imageStyleIndex);
            }
        }

    }

    private static int GetIndex(MenuCommand command)
    {
        if (command.context.GetType() == typeof(Text))
        {
            Text text = (Text)command.context;
            return text.GetComponent<StyleChooser>().textStyleIndex;
        }
        else if (command.context.GetType() == typeof(Button))
        {
            Button button = (Button)command.context;
            return button.GetComponent<StyleChooser>().buttonStyleIndex;
        }
        else if (command.context.GetType() == typeof(Image))
        {
            Image image = (Image)command.context;
            return image.GetComponent<StyleChooser>().imageStyleIndex;

        }
        else if (command.context.GetType() == typeof(Toggle))
        {
            Toggle toggle = (Toggle)command.context;
            return toggle.GetComponent<StyleChooser>().toggleStyleIndex;
        }
        else if (command.context.GetType() == typeof(Slider))
        {
            Slider slider = (Slider)command.context;
            return slider.GetComponent<StyleChooser>().sliderStyleIndex;

        }
        else if (command.context.GetType() == typeof(TMPro.TMP_Dropdown))
        {
            TMPro.TMP_Dropdown dropDown = (TMPro.TMP_Dropdown)command.context;
            return dropDown.GetComponent<StyleChooser>().tmproDropdownStyleIndex;
        }
        else if (command.context.GetType() == typeof(Dropdown))
        {
            Dropdown dropDown = (Dropdown)command.context;
            return dropDown.GetComponent<StyleChooser>().dropdownStyleIndex;

        }
        else if (command.context.GetType() == typeof(TMPro.TMP_InputField))
        {
            TMPro.TMP_InputField inputField = (TMPro.TMP_InputField)command.context;
            return inputField.GetComponent<StyleChooser>().tmproInputStyleIndex;
        }
        else if (command.context.GetType() == typeof(InputField))
        {
            InputField inputField = (InputField)command.context;
            return inputField.GetComponent<StyleChooser>().inputStyleIndex;
        }
        else if (command.context.GetType() == typeof(TMPro.TextMeshProUGUI))
        {
            TMPro.TMP_Text tmpText = (TMPro.TMP_Text)command.context;
            return tmpText.GetComponent<StyleChooser>().tmproTextStyleIndex;
        }
        else
            return 0;
    }

    private static bool HasStyleChooser(GameObject go)
    {
        if (go.GetComponent<StyleChooser>() == null)
            return false;
        else
            return true;
    }

    private static void OpenEditorWindow()
    {
        EditorWindow.GetWindow(typeof(EasyUIStyle));
        EditorWindow.GetWindow(typeof(EasyUIStyle)).minSize = new Vector2(400, 320);
    }
}
