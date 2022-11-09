using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
//using ClickToFormat;

public class EasyUIStyle : EditorWindow {

	[MenuItem ("Window/Easy UI Style Manager")]
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(EasyUIStyle));
        EditorWindow.GetWindow(typeof(EasyUIStyle)).minSize = new Vector2(400, 320);		
	}

    //remove Lists
    List<EasyUI_Image> removeImageList = new List<EasyUI_Image>();
	List<EasyUI_Text> removeTextList = new List<EasyUI_Text>();
    List<EasyUI_Button> removeButtonList = new List<EasyUI_Button>();
	List<EasyUI_Toggle> removeToggleList = new List<EasyUI_Toggle>();
    List<EasyUI_Input> removeInputList = new List<EasyUI_Input>();
    List<EasyUI_Slider> removeSliderList = new List<EasyUI_Slider>();
	List<EasyUI_Dropdown> removeDropdownList = new List<EasyUI_Dropdown>();
    List<EasyUI_TMPText> removeTMProTextList = new List<EasyUI_TMPText>();
    List<EasyUI_TMPInput> removeTMProInputList = new List<EasyUI_TMPInput>();
    List<EasyUI_TMPDropDown> removeTMProDropdownList = new List<EasyUI_TMPDropDown>();

    //Duplicate containers    
    EasyUIStyle_Base duplicateStyle;

    public enum _type
	{
		Image,
		Text,
        TextMeshPro,
        Button,
        Toggle,
        Slider,
        InputField,
        TextMeshProInput,
        Dropdown,
        TextMeshProDropdown,
        Settings
	}
	public static _type thisType; //public and static so it can be set from inspector...

    private static EasyUI_Style_Data easyUI_Data;
    GUISkin skin;
	Vector2 scrollPos = new Vector2();
    float toggleWidth = 50f;

    //stored for GUI sizing
	EditorWindow window;

	void OnEnable()
	{

        GetSkin();      
        
        SetWindow();
		window = EditorWindow.GetWindow(typeof(EasyUIStyle));

        LoadData();		
	}

	void OnDisable()
	{
		UpdateAsset();
	}

    //Gets data and sets lists
    void LoadData()
    {
        easyUI_Data = AssetDatabase.LoadAssetAtPath("Assets/EasyUIStylesLite/Resources/EasyUIData.asset", typeof(EasyUI_Style_Data)) as EasyUI_Style_Data;

        //attempt to find data in other folder
        if (easyUI_Data == null)
        {
            string[] guids = UnityEditor.AssetDatabase.FindAssets("EasyUIData");
            if (guids.Length > 0)
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);
                easyUI_Data = UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(EasyUI_Style_Data)) as EasyUI_Style_Data;
            }
        }

        if (easyUI_Data == null)
        {
            EasyUI_Style_Data data = ScriptableObject.CreateInstance<EasyUI_Style_Data>();
            string assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/EasyUIData.asset");
            Debug.Log("Couldn't Find Easy UI Data. Created new copy in Assets. Feel free to move it :) ");
            AssetDatabase.CreateAsset(data, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            return;        
        }         
        
    }

    private void GetSkin()
    {
        if (EditorGUIUtility.isProSkin)
            skin = EditorGUIUtility.Load("Assets/EasyUIStylesLite/Resources/EasyUI_DarkSKin.guiskin") as GUISkin;
        else
            skin = EditorGUIUtility.Load("Assets/EasyUIStylesLite/Resources/EasyUI_LightSkin.guiskin") as GUISkin;

        //attempt to find data in other folder
        if (skin == null)
        {
            string[] guids;
            if (EditorGUIUtility.isProSkin)
                guids = UnityEditor.AssetDatabase.FindAssets("EasyUI_DarkSKin");
            else
                guids = UnityEditor.AssetDatabase.FindAssets("EasyUI_LightSkin");

            if (guids.Length > 0)
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[0]);

                if (EditorGUIUtility.isProSkin)
                    skin = EditorGUIUtility.Load(path) as GUISkin;
                else
                    skin = EditorGUIUtility.Load(path) as GUISkin;
            }
        }
    }

    void OnGUI()
	{
        //Check if data found
        // if not search again
        if (Event.current.type != EventType.Repaint)
        {
            if (easyUI_Data == null)
            {
                LoadData();
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (skin == null)
            GetSkin();

        GUILayout.Box("Easy UI Styles - Manager", skin.GetStyle("EditorHeading"));

        EditorGUILayout.Space();
        EditorGUI.indentLevel++;

        thisType = (_type)EditorGUILayout.EnumPopup("UI Style To Edit", thisType);
        EditorGUI.indentLevel--;

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
		
        if (thisType != _type.Settings)
        {
            if (thisType == _type.Image || thisType == _type.Text)
            {
                if (GUILayout.Button("Add " + thisType.ToString() + " Style"))
                {
                    switch (thisType)
                    {
                        case _type.Image:
                            AddImage();
                            break;
                        case _type.Text:
                            AddText();
                            break;
                    }

                    UpdateAsset();
                }

  
                if (GUILayout.Button("Minimize All"))
                {
                    MaximizeAll(thisType, false);
                }
                if (GUILayout.Button("Maximize All"))
                {
                    MaximizeAll(thisType, true);
                }
            }
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        //EditorGUILayout.LabelField("",GUILayout.Width(width),GUILayout.Height(height));

        if (thisType == _type.Image)
            DrawImageUI();
        else if (thisType == _type.Text)
            DrawTextUI();
        else 
            DrawNotAvailable();

        //not sure why so many are needed... there is certainly a better way to do this
        EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();
		EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.EndScrollView();        

        CleanUp();

        if (easyUI_Data != null)
        {
            if (easyUI_Data.imageList.Count == 0)
                Debug.LogError("list is empty!");
        }
        else
            LoadData();

		if(GUI.changed && easyUI_Data != null)
		{
            StyleChooser.UpdateStyle();
            EditorUtility.SetDirty(easyUI_Data);
		}
	}

    private void DrawNotAvailable()
    {
        EditorGUILayout.LabelField("This feature is available in the full paid version of Easy UI Styles.", skin.GetStyle("ColumnHeading"));
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Or free for my Patrons.", skin.GetStyle("ColumnHeading"));
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Open Asset Store"))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/tools/utilities/easy-ui-styles-73899?aid=1100lHSw");
        }

        if (GUILayout.Button("OWS Patreon"))
        {
            Application.OpenURL("https://www.patreon.com/onewheelstudio");
        }
        EditorGUILayout.EndHorizontal();

    }

    void AddText()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Text newText = new EasyUI_Text();
        easyUI_Data.textList.Add(newText);
        newText.styleName = "Text Style " + easyUI_Data.textList.Count;
        newText.displayOrder = easyUI_Data.textList.Count - 1;
    }
    void AddImage()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Image newImage = new EasyUI_Image();
        easyUI_Data.imageList.Add(newImage);
        newImage.styleName = "Image Style " + easyUI_Data.imageList.Count;
        newImage.displayOrder = easyUI_Data.imageList.Count - 1;
        newImage.previousOrder = easyUI_Data.imageList.Count - 1;
    }
    void AddButton()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Button newButton = new EasyUI_Button();
        easyUI_Data.buttonList.Add(newButton);
        newButton.styleName = "Button Style " + easyUI_Data.buttonList.Count;
    }
    void AddToggle()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Toggle newToggle = new EasyUI_Toggle();
        easyUI_Data.toggleList.Add(newToggle);
        newToggle.styleName = "Toggle Style " + easyUI_Data.toggleList.Count;
    }
    void AddSlider()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Slider newSlider = new EasyUI_Slider();
        easyUI_Data.sliderList.Add(newSlider);
        newSlider.styleName = "Slider Style " + easyUI_Data.sliderList.Count;
    }
    void AddInput()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Input newInput = new EasyUI_Input();
        easyUI_Data.inputList.Add(newInput);
        newInput.styleName = "Input Style " + easyUI_Data.inputList.Count;
    }
    void AddDropDown()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_Dropdown newDropDown = new EasyUI_Dropdown();
        easyUI_Data.dropdownList.Add(newDropDown);
        newDropDown.styleName = "Dropdown Style " + easyUI_Data.dropdownList.Count;
    }

    void AddTMProText()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_TMPText newTMProText = new EasyUI_TMPText();
        newTMProText.styleName = "TMP Text Style " + easyUI_Data.tmproTextList.Count;
        easyUI_Data.tmproTextList.Add(newTMProText);
    }

    void AddTMProInput()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_TMPInput newTMProText = new EasyUI_TMPInput();
        newTMProText.styleName = "TMP Input Style " + easyUI_Data.tmproInputList.Count;

        easyUI_Data.tmproInputList.Add(newTMProText);
    }

    void AddTMProDropdown()
    {
        if (easyUI_Data == null)
            return;

        EasyUI_TMPDropDown newTMProText = new EasyUI_TMPDropDown();
        newTMProText.styleName = "TMP Dropdown Style " + easyUI_Data.tmproDropdownList.Count;
        easyUI_Data.tmproDropdownList.Add(newTMProText);
    }

    void DuplicateStyle(EasyUIStyle_Base _style)
    {
        if (easyUI_Data == null)
            return;

        if (_style is EasyUI_Image)
            duplicateStyle = _style.MakeCopy() as EasyUI_Image;
        else if (_style is EasyUI_Text)
            duplicateStyle = _style.MakeCopy() as EasyUI_Text;
        else if (_style is EasyUI_Slider)
            duplicateStyle = _style.MakeCopy() as EasyUI_Slider;
        else if (_style is EasyUI_TMPInput)
            duplicateStyle = _style.MakeCopy() as EasyUI_TMPInput;
        else if (_style is EasyUI_Input)
            duplicateStyle = _style.MakeCopy() as EasyUI_Input;
        else if (_style is EasyUI_Toggle)
            duplicateStyle = _style.MakeCopy() as EasyUI_Toggle;
        else if (_style is EasyUI_TMPDropDown)
            duplicateStyle = _style.MakeCopy() as EasyUI_TMPDropDown;
        else if (_style is EasyUI_Dropdown)
            duplicateStyle = _style.MakeCopy() as EasyUI_Dropdown;
        else if (_style is EasyUI_Button)
            duplicateStyle = _style.MakeCopy() as EasyUI_Button;
        else if (_style is EasyUI_TMPText)
            duplicateStyle = _style.MakeCopy() as EasyUI_TMPText;
    }

    //used from context menu
    public static void AddStyle(UnityEngine.UI.Text text)
    {
        //set style
        EasyUI_Style_Data _EasyUI_Data = AssetDatabase.LoadAssetAtPath("Assets/EasyUIStyles/Resources/EasyUIData.asset", typeof(EasyUI_Style_Data)) as EasyUI_Style_Data;
        EasyUI_Text newTextStyle = new EasyUI_Text();
        newTextStyle = newTextStyle.MakeCopy(text);
        //newTextStyle.styleName = text.gameObject.name + " Style";
        _EasyUI_Data.textList.Add(newTextStyle);

        //add style chooser
        StyleChooser sc = AddStyleChooser(text.gameObject);
        sc.textStyleIndex = _EasyUI_Data.textList.Count - 1;
    }

    public static void AddStyle(UnityEngine.UI.Image image)
    {
        //set style
        EasyUI_Style_Data _EasyUI_Data = AssetDatabase.LoadAssetAtPath("Assets/EasyUIStyles/Resources/EasyUIData.asset", typeof(EasyUI_Style_Data)) as EasyUI_Style_Data;
        EasyUI_Image newImageStyle = new EasyUI_Image();
        newImageStyle = newImageStyle.MakeCopy(image);
        _EasyUI_Data.imageList.Add(newImageStyle);

        //add style chooser
        StyleChooser sc = AddStyleChooser(image.gameObject);
        sc.imageStyleIndex = _EasyUI_Data.imageList.Count - 1;
    }

    public static StyleChooser AddStyleChooser(GameObject go)
    {
        if (go.GetComponent<StyleChooser>() == null)
            return go.AddComponent<StyleChooser>();
        else
            return go.GetComponent<StyleChooser>();
    }

    //Cleans up lists of UI styles
    //Needs to be done this way to avoid enumeration errors caused by GUI refresh
    void CleanUp()
    {
        if (easyUI_Data == null)
            return;

        foreach (EasyUI_Text t in removeTextList)
            easyUI_Data.textList.Remove(t);
        foreach (EasyUI_Image i in removeImageList)
            easyUI_Data.imageList.Remove(i);
        foreach (EasyUI_Button i in removeButtonList)
            easyUI_Data.buttonList.Remove(i);
        foreach (EasyUI_Toggle t in removeToggleList)
            easyUI_Data.toggleList.Remove(t);
        foreach (EasyUI_Slider i in removeSliderList)
            easyUI_Data.sliderList.Remove(i);
        foreach (EasyUI_Input i in removeInputList)
            easyUI_Data.inputList.Remove(i);
        foreach (EasyUI_Dropdown d in removeDropdownList)
            easyUI_Data.dropdownList.Remove(d);
        foreach (EasyUI_TMPText t in removeTMProTextList)
            easyUI_Data.tmproTextList.Remove(t);
        foreach (EasyUI_TMPInput t in removeTMProInputList)
            easyUI_Data.tmproInputList.Remove(t);
        foreach (EasyUI_TMPDropDown t in removeTMProDropdownList)
            easyUI_Data.tmproDropdownList.Remove(t);

        if (duplicateStyle != null)
        {
            if (duplicateStyle is EasyUI_Image)
                easyUI_Data.imageList.Add(duplicateStyle as EasyUI_Image);
            else if (duplicateStyle is EasyUI_Text)
                easyUI_Data.textList.Add(duplicateStyle as EasyUI_Text);
            else if (duplicateStyle is EasyUI_Slider)
                easyUI_Data.sliderList.Add(duplicateStyle as EasyUI_Slider);
            else if (duplicateStyle is EasyUI_TMPInput)
                easyUI_Data.tmproInputList.Add(duplicateStyle as EasyUI_TMPInput);
            else if (duplicateStyle is EasyUI_Input)
                easyUI_Data.inputList.Add(duplicateStyle as EasyUI_Input);
            else if (duplicateStyle is EasyUI_Toggle)
                easyUI_Data.toggleList.Add(duplicateStyle as EasyUI_Toggle);
            else if (duplicateStyle is EasyUI_TMPDropDown)
                easyUI_Data.tmproDropdownList.Add(duplicateStyle as EasyUI_TMPDropDown);
            else if (duplicateStyle is EasyUI_Dropdown)
                easyUI_Data.dropdownList.Add(duplicateStyle as EasyUI_Dropdown);
            else if (duplicateStyle is EasyUI_Button)
                easyUI_Data.buttonList.Add(duplicateStyle as EasyUI_Button);
            else if (duplicateStyle is EasyUI_TMPText)
                easyUI_Data.tmproTextList.Add(duplicateStyle as EasyUI_TMPText);

            duplicateStyle = null;
        }
    }

    void UpdateAsset()
    {
        if (easyUI_Data == null || Application.isPlaying)
            return;

        EditorUtility.SetDirty(easyUI_Data);
        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();

        if (easyUI_Data.imageList.Count == 0)
            Debug.LogError("list is empty!");
    }

    //Allows Easy UI window to be opened from inspector
    static void SetWindow()
	{
        Style_Chooser_Inspector.SetWindow(EditorWindow.GetWindow(typeof(EasyUIStyle)));
    }

    void DrawImageUI()
    {
        float startHeight = 0f;

        for (int i = 0; i < easyUI_Data.imageList.Count; i++)
        {
            easyUI_Data.imageList[i].displayOrder = i;
        }

        foreach (EasyUI_Image i in easyUI_Data.imageList)
        {
            ///Code to adjust size of box area
            float lengthOfBox;
            if (!i.maximize)
                lengthOfBox = 30f;
            else if (i.sprite != null)
            {
                if (i.imageType == UnityEngine.UI.Image.Type.Filled)
                    lengthOfBox = 325f;
                else
                    lengthOfBox = 255f;
            }
            else
                lengthOfBox = 205f;

            //blank label allows scrollview to expand
            GUILayout.Label("", GUILayout.Height(lengthOfBox));
            //background shading
            GUILayout.BeginArea(new Rect(10f, startHeight, window.position.width - 30f, lengthOfBox), skin.box);
            startHeight += lengthOfBox + 10f;

            DrawTopStyleButtons(i);

            if (i.maximize)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();
                i.styleName = EditorGUILayout.TextField("Style Name : ", i.styleName);
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();

                //EditorGUILayout.LabelField("  Sync", GUILayout.Width(toggleWidth));
                EditorGUILayout.BeginHorizontal();
                EditorGUI.indentLevel--;

                if (GUILayout.Button("Sync", GUILayout.Width(50)))
                {
                    i.ToggleAll(!i.syncColor);
                }
                EditorGUI.indentLevel++;
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                i.syncColor = EditorGUILayout.Toggle(i.syncColor, GUILayout.Width(toggleWidth));
                i.color = EditorGUILayout.ColorField("Tint", i.color);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                i.syncMaterial = EditorGUILayout.Toggle(i.syncMaterial, GUILayout.Width(toggleWidth));
                i.material = EditorGUILayout.ObjectField("Material", i.material, typeof(Material), false) as Material;
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                i.syncRaycastTarget = EditorGUILayout.Toggle(i.syncRaycastTarget, GUILayout.Width(toggleWidth));
                i.raycastTarget = EditorGUILayout.Toggle("Raycast Target", i.raycastTarget);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                i.syncSprite = EditorGUILayout.Toggle(i.syncSprite, GUILayout.Width(toggleWidth));
                i.sprite = EditorGUILayout.ObjectField("Image", i.sprite, typeof(Sprite), false) as Sprite;
                EditorGUILayout.EndHorizontal();

                if (i.sprite != null)
                {
                    EditorGUILayout.BeginHorizontal();
                    i.syncImageType = EditorGUILayout.Toggle(i.syncImageType, GUILayout.Width(toggleWidth));
                    i.imageType = (UnityEngine.UI.Image.Type)EditorGUILayout.EnumPopup("Image Type", i.imageType);
                    EditorGUILayout.EndHorizontal();

                    if (i.imageType == UnityEngine.UI.Image.Type.Filled)
                    {
                        EditorGUILayout.BeginHorizontal();
                        i.syncFillMethod = EditorGUILayout.Toggle(i.syncFillMethod, GUILayout.Width(toggleWidth));
                        i.fillMethod = (UnityEngine.UI.Image.FillMethod)EditorGUILayout.EnumPopup("Fill Method", i.fillMethod);
                        EditorGUILayout.EndHorizontal();


                        EditorGUILayout.BeginHorizontal();
                        i.syncFillMethod = EditorGUILayout.Toggle(i.syncFillMethod, GUILayout.Width(toggleWidth));
                        EditorGUI.indentLevel++;
                        switch (i.fillMethod)
                        {
                            case UnityEngine.UI.Image.FillMethod.Horizontal:
                                i.originHorz = (UnityEngine.UI.Image.OriginHorizontal)EditorGUILayout.EnumPopup("Fill Method", i.originHorz);
                                break;
                            case UnityEngine.UI.Image.FillMethod.Vertical:
                                i.originVert = (UnityEngine.UI.Image.OriginVertical)EditorGUILayout.EnumPopup("Fill Method", i.originVert);
                                break;
                            case UnityEngine.UI.Image.FillMethod.Radial90:
                                i.origin90 = (UnityEngine.UI.Image.Origin90)EditorGUILayout.EnumPopup("Fill Method", i.origin90);
                                break;
                            case UnityEngine.UI.Image.FillMethod.Radial180:
                                i.origin180 = (UnityEngine.UI.Image.Origin180)EditorGUILayout.EnumPopup("Fill Method", i.origin180);
                                break;
                            case UnityEngine.UI.Image.FillMethod.Radial360:
                                i.origin360 = (UnityEngine.UI.Image.Origin360)EditorGUILayout.EnumPopup("Fill Method", i.origin360);
                                break;
                        }
                        EditorGUI.indentLevel--;
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        i.syncFillAmount = EditorGUILayout.Toggle(i.syncFillAmount, GUILayout.Width(toggleWidth));
                        EditorGUI.indentLevel++;
                        i.fillAmount = EditorGUILayout.Slider("Fill Amount", i.fillAmount, 0f, 1f);
                        EditorGUI.indentLevel--;
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        i.syncClockwise = EditorGUILayout.Toggle(i.syncClockwise, GUILayout.Width(toggleWidth));
                        EditorGUI.indentLevel++;
                        i.clockwise = EditorGUILayout.Toggle("Clockwise", i.clockwise);
                        EditorGUI.indentLevel--;
                        EditorGUILayout.EndHorizontal();
                    }


                    EditorGUILayout.BeginHorizontal();
                    i.syncPreserveAspect = EditorGUILayout.Toggle(i.syncPreserveAspect, GUILayout.Width(toggleWidth));
                    i.preserveAspect = EditorGUILayout.Toggle("Preserve Aspect", i.preserveAspect);
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUI.indentLevel--;
                EditorGUILayout.Space();

            }
            GUILayout.EndArea();

        }
    }

    void DrawTextUI()
    {
        float startHeight = 10f;

        foreach (EasyUI_Text t in easyUI_Data.textList)
        {
            ///Code to adjust size of box area
			float lengthOfBox;
            if (!t.maximize)
                lengthOfBox = 30f;
            else if (!t.resizeForBestFit)
                lengthOfBox = 285f;
            else
                lengthOfBox = 320f;

            //blank label allows scrollview to expand
            GUILayout.Label("", GUILayout.Height(lengthOfBox));
            //background shading
            GUILayout.BeginArea(new Rect(10f, startHeight, window.position.width - 30f, lengthOfBox), skin.box);
            startHeight += lengthOfBox + 10f;

            DrawTopStyleButtons(t);

            //Don't display if not maximized
            if (t.maximize)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.Space();
                t.styleName = EditorGUILayout.TextField("Edit Style Name : ", t.styleName);
                EditorGUILayout.Space();


                EditorGUILayout.BeginHorizontal();
                EditorGUI.indentLevel--;
                if (GUILayout.Button("Sync", GUILayout.Width(50)))
                {
                    t.ToggleAll(!t.syncFont);
                }
                EditorGUI.indentLevel++;
                EditorGUILayout.EndHorizontal();

                ///t.styleName = EditorGUILayout.TextField("Style Name : ", t.styleName);

                EditorGUILayout.BeginHorizontal();
                t.syncFont = EditorGUILayout.Toggle(t.syncFont, GUILayout.Width(toggleWidth));
                t.font = EditorGUILayout.ObjectField("Font", t.font, typeof(Font), false) as Font;
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncFontSize = EditorGUILayout.Toggle(t.syncFontSize, GUILayout.Width(toggleWidth));
                t.fontSize = EditorGUILayout.IntField("Font Size", t.fontSize);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncFontStyle = EditorGUILayout.Toggle(t.syncFontStyle, GUILayout.Width(toggleWidth));
                t.fontStyle = (FontStyle)EditorGUILayout.EnumPopup("Font Style", t.fontStyle);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();

                EditorGUILayout.BeginHorizontal();
                t.syncTextAnchor = EditorGUILayout.Toggle(t.syncTextAnchor, GUILayout.Width(toggleWidth));
                t.textAnchor = (TextAnchor)EditorGUILayout.EnumPopup("Text Alignment", t.textAnchor);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncHorizontalWrapMode = EditorGUILayout.Toggle(t.syncHorizontalWrapMode, GUILayout.Width(toggleWidth));
                t.horzWrap = (HorizontalWrapMode)EditorGUILayout.EnumPopup("Horizontal Overflow", t.horzWrap);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncVerticalWrapMode = EditorGUILayout.Toggle(t.syncVerticalWrapMode, GUILayout.Width(toggleWidth));
                t.vertWrap = (VerticalWrapMode)EditorGUILayout.EnumPopup("Vertical Overflow", t.vertWrap);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncBestFit = EditorGUILayout.Toggle(t.syncBestFit, GUILayout.Width(toggleWidth));
                t.resizeForBestFit = EditorGUILayout.Toggle("Best Fit", t.resizeForBestFit);
                EditorGUILayout.EndHorizontal();


                if (t.resizeForBestFit)
                {
                    EditorGUI.indentLevel++;
                    EditorGUI.indentLevel++;
                    EditorGUI.indentLevel++;
                    EditorGUI.indentLevel++;
                    t.minSize = EditorGUILayout.IntField("Min Size", t.minSize);
                    t.maxSize = EditorGUILayout.IntField("Max Size", t.maxSize);
                    EditorGUI.indentLevel--;
                    EditorGUI.indentLevel--;
                    EditorGUI.indentLevel--;
                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.Space();

                EditorGUILayout.BeginHorizontal();
                t.syncTextColor = EditorGUILayout.Toggle(t.syncTextColor, GUILayout.Width(toggleWidth));
                t.textColor = EditorGUILayout.ColorField("Text Color", t.textColor);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncTexMat = EditorGUILayout.Toggle(t.syncTexMat, GUILayout.Width(toggleWidth));
                t.textMat = EditorGUILayout.ObjectField("Material", t.textMat, typeof(Material), false) as Material;
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                t.syncRaycastTarget = EditorGUILayout.Toggle(t.syncRaycastTarget, GUILayout.Width(toggleWidth));
                t.isRaycastTarget = EditorGUILayout.Toggle("Raycast Target", t.isRaycastTarget);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUI.indentLevel--;
            }

            GUILayout.EndArea();
        }
    }


    //Adds style chooser to all children of a canvas
    void AddToALL<T>() where T : Component
    {
        Object[] tempArray;
        tempArray = Resources.FindObjectsOfTypeAll(typeof(Canvas));

		foreach(Object go in tempArray)
		{
            GameObject tempGo;
            tempGo = GameObject.Find(go.name);

            //Get all children
            Transform[] childList;
            childList = tempGo.GetComponentsInChildren<Transform>();

            foreach (Transform child in childList)
            {
                if(child.GetComponent<T>() && !child.GetComponent<StyleChooser>())
                {
                    child.gameObject.AddComponent<StyleChooser>();
                }
            }
		}
	}

    //Removes Style Chooser to all children of a canvas
    void RemoveFromALL<T>() where T : Component
    {
        //return object not gameobject
        Object[] tempArray;
        tempArray = Resources.FindObjectsOfTypeAll(typeof(Canvas));

        foreach (Object go in tempArray)
        {
            //Search for gameobject by name to be able to get gameobject
            GameObject tempGo;
            tempGo = GameObject.Find(go.name);

            //Get all children
            Transform[] childList;
            childList = tempGo.GetComponentsInChildren<Transform>();

            foreach (Transform child in childList)
            {
                if (child.GetComponent<T>() && child.GetComponent<StyleChooser>())
                {
                    DestroyImmediate(child.gameObject.GetComponent<StyleChooser>());
                }
            }
        }
    }

    public static void MaximizeAll(_type m_type, bool max)
    {
        switch (m_type)
        {
            case _type.Image:
                foreach (EasyUI_Image i in easyUI_Data.imageList)
                {
                    i.maximize = max;
                }
                break;
            case _type.Text:
                foreach (EasyUI_Text t in easyUI_Data.textList)
                {
                    t.maximize = max;
                }
                break;
            case _type.Button:
                foreach (EasyUI_Button b in easyUI_Data.buttonList)
                {
                    b.maximize = max;
                }
                break;
            case _type.Toggle:
                foreach (EasyUI_Toggle t in easyUI_Data.toggleList)
                {
                    t.maximize = max;
                }
                break;
            case _type.Slider:
                foreach (EasyUI_Slider s in easyUI_Data.sliderList)
                {
                    s.maximize = max;
                }
                break;
            case _type.InputField:
                foreach (EasyUI_Input i in easyUI_Data.inputList)
                {
                    i.maximize = max;
                }
                break;
            case _type.Dropdown:
                foreach (EasyUI_Dropdown d in easyUI_Data.dropdownList)
                {
                    d.maximize = max;
                }
                break;
            case _type.TextMeshPro:
                foreach (EasyUI_TMPText t in easyUI_Data.tmproTextList)
                {
                    t.maximize = max;
                }
                break;
            case _type.TextMeshProInput:
                foreach (EasyUI_TMPInput t in easyUI_Data.tmproInputList)
                {
                    t.maximize = max;
                }
                break;
            case _type.TextMeshProDropdown:
                foreach (EasyUI_TMPDropDown t in easyUI_Data.tmproDropdownList)
                {
                    t.maximize = max;
                }
                break;
        }
    }


    public static void OpenStyle(_type m_type, int index)
    {
        Debug.Log("Index " + index);

        switch (m_type)
        {
            case _type.Image:
                easyUI_Data.imageList[index - 1].maximize = true;
                break;
            case _type.Text:
                easyUI_Data.textList[index - 1].maximize = true;

                break;
            case _type.Button:
                easyUI_Data.buttonList[index - 1].maximize = true;

                break;
            case _type.Toggle:
                easyUI_Data.toggleList[index - 1].maximize = true;

                break;
            case _type.Slider:
                easyUI_Data.sliderList[index - 1].maximize = true;

                break;
            case _type.InputField:
                easyUI_Data.inputList[index - 1].maximize = true;
                break;
            case _type.Dropdown:
                easyUI_Data.dropdownList[index - 1].maximize = true;
                break;
            case _type.TextMeshPro:
                easyUI_Data.tmproTextList[index - 1].maximize = true;
                break;
            case _type.TextMeshProInput:
                easyUI_Data.tmproInputList[index - 1].maximize = true;
                break;
            case _type.TextMeshProDropdown:
                easyUI_Data.tmproDropdownList[index - 1].maximize = true;
                break;

        }
    }


    //Draws basic buttons for each style
    void DrawTopStyleButtons(EasyUIStyle_Base _style)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(_style.styleName.ToString(), skin.GetStyle("StyleHeading"));
        //if (GUILayout.Button(Resources.Load("Up") as Texture2D))
        //{
        //    MoveStyle<CTS_Image>(_style as CTS_Image, true, imageList);
        //}
        //if (GUILayout.Button(Resources.Load("Down") as Texture2D))
        //{
        //    MoveStyle<CTS_Image>(_style as CTS_Image, false, imageList);
        //}
        if (_style.maximize)
        {
            if (GUILayout.Button("Minimize"))
            {
                _style.maximize = false;
            }
        }
        else
        {
            if (GUILayout.Button("Maximize"))
            {
                _style.maximize = true;
            }
        }
        if (GUILayout.Button("Duplicate"))
        {
            if (_style is EasyUI_Image)
                DuplicateStyle(_style as EasyUI_Image);
            else if (_style is EasyUI_Text)
                DuplicateStyle(_style as EasyUI_Text);
            else if (_style is EasyUI_Slider)
                DuplicateStyle(_style as EasyUI_Slider);
            else if (_style is EasyUI_TMPInput)
                DuplicateStyle(_style as EasyUI_TMPInput);
            else if (_style is EasyUI_Input)
                DuplicateStyle(_style as EasyUI_Input);
            else if (_style is EasyUI_Toggle)
                DuplicateStyle(_style as EasyUI_Toggle);
            else if (_style is EasyUI_TMPDropDown)
                DuplicateStyle(_style as EasyUI_TMPDropDown);
            else if (_style is EasyUI_Dropdown)
                DuplicateStyle(_style as EasyUI_Dropdown);
            else if (_style is EasyUI_Button)
                DuplicateStyle(_style as EasyUI_Button);
            else if (_style is EasyUI_TMPText)
                DuplicateStyle(_style as EasyUI_TMPText);


        }
        if (GUILayout.Button("Remove"))
        {
            removeImageList.Add(_style as EasyUI_Image);
            removeTextList.Add(_style as EasyUI_Text);
            removeButtonList.Add(_style as EasyUI_Button);
            removeSliderList.Add(_style as EasyUI_Slider);
            removeToggleList.Add(_style as EasyUI_Toggle);
            removeInputList.Add(_style as EasyUI_Input);
            removeDropdownList.Add(_style as EasyUI_Dropdown);
            removeTMProTextList.Add(_style as EasyUI_TMPText);
            removeTMProInputList.Add(_style as EasyUI_TMPInput);
            removeTMProDropdownList.Add(_style as EasyUI_TMPDropDown);
        }
        EditorGUILayout.EndHorizontal();
    }

    void MoveStyle<T>(T _style, bool moveUp, List<T> _styleList)
    {
        if (!_styleList.Contains(_style))
            return;

        int currentPos;
        int nextPos;

        currentPos = _styleList.IndexOf(_style);

        if (currentPos == 0 && moveUp)
            return;
        else if (currentPos == _styleList.Count - 1 && !moveUp)
            return;

        if (moveUp)
            nextPos = currentPos - 1;
        else
            nextPos = currentPos + 1;

        Debug.Log("Moving style from " + currentPos + " to " + nextPos);

        T style1 = _styleList[currentPos];
        T style2 = _styleList[nextPos];

        _styleList[currentPos] = style2;
        _styleList[nextPos] = style1;
    }

}
