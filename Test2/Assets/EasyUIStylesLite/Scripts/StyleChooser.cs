using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[ExecuteInEditMode]
[System.Serializable]
public class StyleChooser : MonoBehaviour {

	public bool hasText;
	public bool hasImage;
    public bool hasButton;
	public bool hasToggle;
    public bool hasSlider;
    public bool hasInput;
	public bool hasDropdown;
    public bool hasTMProText;
    public bool hasTMProInput;
    public bool hasTMProDropdown;

	public Text text;
	public Image image;
    public Button button;
	public Toggle toggle;
    public Slider slider;
    public InputField input;
	public Dropdown dropdown;
    public TextMeshProUGUI tmproText;
    public TMP_InputField tmproInput;
    public TMP_Dropdown tmproDropdown;

    public int imageStyleIndex;
    public int textStyleIndex;
    public int buttonStyleIndex;
    public int toggleStyleIndex;
    public int sliderStyleIndex;
    public int inputStyleIndex;
    public int dropdownStyleIndex;
    public int tmproTextStyleIndex;
    public int tmproInputStyleIndex;
    public int tmproDropdownStyleIndex;

	EasyUI_Text thisTextStyle;
	EasyUI_Image thisImageStyle;
    EasyUI_Button thisButtonStyle;
	EasyUI_Toggle thisToggleStyle;
    EasyUI_Slider thisSliderStyle;
    EasyUI_Input thisInputStyle;
	EasyUI_Dropdown thisDropdownStyle;
    EasyUI_TMPText thisTMProTextStyle;
    EasyUI_TMPInput thisTMProInputStyle;
    EasyUI_TMPDropDown thisTMProDropDownStyle;

    public EasyUI_Style_Data easyUI_Data;

    private delegate void UpdateStyles();
    private static event UpdateStyles updateStyles;

    // Use this for initialization
    void Start () {

        Initialize();        
	}

    public void Initialize()
    {
        //only runs in edit mode
        if (Application.isPlaying)
            this.enabled = false;


        //Grab scriptable object
        LoadData();

        //Use to check type of UI element and later for changing style
        text = this.GetComponent<Text>();
        image = this.GetComponent<Image>();

        if (text != null)
            hasText = true;
        else
            hasText = false;

        if (image != null)
            hasImage = true;
        else
            hasImage = false;

    }

    private void OnEnable()
    {
        updateStyles += ForceUpdate;
    }

    private void OnDisable()
    {
        updateStyles -= ForceUpdate;
    }

    //called from editor window when a style is changed
    public static void UpdateStyle()
    {
        updateStyles?.Invoke();
    }

    private void OnValidate()
    {
        UpdateStyle();
    }

    public void ForceUpdate()
    {
        Debug.Log("Doing force update");

        if (easyUI_Data == null)
            LoadData();

        if (hasText)
            UpdateTextFormat();
        else if (hasImage)
            UpdateImageFormat();

        if (easyUI_Data == null)
            return;

    }

    public void LoadData()
    {

#if UNITY_EDITOR
        easyUI_Data = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/EasyUIStylesLite/Resources/EasyUIData.asset", typeof(EasyUI_Style_Data)) as EasyUI_Style_Data;


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
#endif
    }

    public void UpdateTextFormat()
    {
        if (easyUI_Data.textList.Count == 0)
            return;

        if (textStyleIndex == 0)
            return;

        if (textStyleIndex > easyUI_Data.textList.Count)
        {
            thisTextStyle = easyUI_Data.textList[0];
            return;
        }

        thisTextStyle = easyUI_Data.textList[textStyleIndex - 1];

        if (thisTextStyle == null)
            return;

        if (thisTextStyle.syncFont)
            text.font = thisTextStyle.font;
        if (thisTextStyle.syncFontSize)
            text.fontSize = thisTextStyle.fontSize;
        if (thisTextStyle.syncFontStyle)
            text.fontStyle = thisTextStyle.fontStyle;
        if (thisTextStyle.syncTextAnchor)
            text.alignment = thisTextStyle.textAnchor;
        if (thisTextStyle.syncVerticalWrapMode)
            text.verticalOverflow = thisTextStyle.vertWrap;
        if (thisTextStyle.syncHorizontalWrapMode)
            text.horizontalOverflow = thisTextStyle.horzWrap;
        if (thisTextStyle.syncBestFit)
        {
            text.resizeTextForBestFit = thisTextStyle.resizeForBestFit;
            text.resizeTextMinSize = thisTextStyle.minSize;
            text.resizeTextMaxSize = thisTextStyle.maxSize;
        }
        if (thisTextStyle.syncTextColor)
            text.color = thisTextStyle.textColor;
        if (thisTextStyle.syncTexMat)
            text.material = thisTextStyle.textMat;
        if (thisTextStyle.syncRaycastTarget)
            text.raycastTarget = thisTextStyle.isRaycastTarget;
    }

    public void UpdateImageFormat()
    {
        if (easyUI_Data.imageList.Count == 0)
            return;

        if (imageStyleIndex == 0)
            return;

        if (imageStyleIndex > easyUI_Data.imageList.Count)
        {
            thisImageStyle = easyUI_Data.imageList[0];
            return;
        }
        thisImageStyle = easyUI_Data.imageList[imageStyleIndex - 1];

        if (thisImageStyle == null)
            return;

        if (thisImageStyle.syncColor)
            image.color = thisImageStyle.color;
        if (thisImageStyle.syncMaterial)
            image.material = thisImageStyle.material;
        if (thisImageStyle.syncSprite)
            image.sprite = thisImageStyle.sprite;
        if (thisImageStyle.syncRaycastTarget)
            image.raycastTarget = thisImageStyle.raycastTarget;
        if (thisImageStyle.syncImageType)
            image.type = thisImageStyle.imageType;

        if (thisImageStyle.imageType == UnityEngine.UI.Image.Type.Filled)
        {
            if (thisImageStyle.syncFillMethod)
                image.fillMethod = thisImageStyle.fillMethod;

            switch (thisImageStyle.fillMethod)
            {
                case UnityEngine.UI.Image.FillMethod.Horizontal:
                    if (thisImageStyle.syncOriginHorzontal)
                        image.fillOrigin = (int)thisImageStyle.originHorz;
                    break;
                case UnityEngine.UI.Image.FillMethod.Vertical:
                    if (thisImageStyle.syncOriginVertical)
                        image.fillOrigin = (int)thisImageStyle.originVert;
                    break;
                case UnityEngine.UI.Image.FillMethod.Radial90:
                    if (thisImageStyle.syncOrigin90)
                        image.fillOrigin = (int)thisImageStyle.origin90;
                    break;
                case UnityEngine.UI.Image.FillMethod.Radial180:
                    if (thisImageStyle.syncOrigin180)
                        image.fillOrigin = (int)thisImageStyle.origin180;
                    break;
                case UnityEngine.UI.Image.FillMethod.Radial360:
                    if (thisImageStyle.syncOrigin360)
                        image.fillOrigin = (int)thisImageStyle.origin360;
                    break;
            }
            if (thisImageStyle.syncClockwise)
                image.fillClockwise = thisImageStyle.clockwise;
            if (thisImageStyle.syncFillAmount)
                image.fillAmount = thisImageStyle.fillAmount;
        }
        else if (thisImageStyle.syncFillCenter)
            image.fillCenter = thisImageStyle.fillCenter;

        if (thisImageStyle.syncPreserveAspect)
            image.preserveAspect = thisImageStyle.preserveAspect;
    }

    void UpdateButtonFormat()
    {

    }

	void UpdateToggleFormat()
	{

	}

	void UpdateSliderFormat()
	{

	}

	void UpdateInputFormat()
	{
		
	}

    void UpdateTMProTextFormat()
    {
	    
    }

    void UpdateTMProInput()
    {
        
    }

    void UpdateTMProDropdown()
    {
       
    }

    void UpdateDropdownFormat()
	{
		
	}

	void UpdateButtonCore(EasyUI_Button style, Selectable uiObject)
	{

		
    }

}
