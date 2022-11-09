using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class EasyUIStyle_Base
{
    public int displayOrder = 0;
    public int previousOrder = 0;

    public string styleName = "New Style";
    public bool maximize = true;

    public virtual void ToggleAll(bool _isOn)
    {}

    public virtual EasyUIStyle_Base MakeCopy()
    {
        return null;
    }
}

[System.Serializable]
public class EasyUI_Image : EasyUIStyle_Base
{
	public Color color = new Color(0f,0f,0f,1f);
	public Sprite sprite;
	public Material material;
	public bool raycastTarget = true;
	public bool preserveAspect = false;
	public Image.Type imageType;
	public bool fillCenter = true;

	//Filled Type
	public Image.FillMethod fillMethod = Image.FillMethod.Radial360;
	public Image.Origin360 origin360 = Image.Origin360.Bottom;
	public Image.Origin180 origin180 = Image.Origin180.Bottom;
	public Image.Origin90 origin90 = Image.Origin90.BottomLeft;
	public Image.OriginHorizontal originHorz = Image.OriginHorizontal.Left;
	public Image.OriginVertical originVert = Image.OriginVertical.Bottom;
	public float fillAmount  = 1;
	public bool clockwise = true;

    //track syncing
    public bool syncColor = true;
    public bool syncSprite = true;
    public bool syncMaterial = true;
    public bool syncRaycastTarget = true;
    public bool syncPreserveAspect = true;
    public bool syncImageType = true;
    public bool syncFillCenter = true;
    public bool syncFillMethod = true;
    public bool syncOrigin360 = true;
    public bool syncOrigin180 = true;
    public bool syncOrigin90 = true;
    public bool syncOriginHorzontal = true;
    public bool syncOriginVertical = true;
    public bool syncFillAmount = true;
    public bool syncClockwise = true;

    public override void ToggleAll(bool _isOn)
    {
        syncColor = _isOn;
        syncSprite = _isOn;
        syncMaterial = _isOn;
        syncRaycastTarget = _isOn;
        syncPreserveAspect = _isOn;
        syncImageType = _isOn;
        syncFillCenter = _isOn;
        syncFillMethod = _isOn;
        syncOrigin360 = _isOn;
        syncOrigin180 = _isOn;
        syncOrigin90 = _isOn;
        syncOriginHorzontal = _isOn;
        syncOriginVertical = _isOn;
        syncFillAmount = _isOn;
        syncClockwise = _isOn;
    }

    public override EasyUIStyle_Base MakeCopy()
    {
        EasyUI_Image _style = new EasyUI_Image();
        _style.styleName = "New Image Style";

        _style.color = this.color;
        _style.sprite = this.sprite;
        _style.material = this.material;
        _style.raycastTarget = this.raycastTarget;
        _style.imageType = this.imageType;
        _style.fillCenter = this.fillCenter;
        _style.fillMethod = this.fillMethod;
        _style.origin360 = this.origin360;
        _style.origin180 = this.origin180;
        _style.origin90 = this.origin90;
        _style.originHorz = this.originHorz;
        _style.originVert = this.originVert;
        _style.fillAmount = this.fillAmount;
        _style.clockwise = this.clockwise;

        _style.syncColor = this.syncColor;
        _style.syncSprite = this.syncSprite;
        _style.syncMaterial = this.syncMaterial;
        _style.syncRaycastTarget = this.syncRaycastTarget;
        _style.syncPreserveAspect = this.syncPreserveAspect;
        _style.syncImageType = this.syncImageType;
        _style.syncFillCenter = this.syncFillCenter;
        _style.syncFillMethod = this.syncFillMethod;
        _style.syncOrigin360 = this.syncOrigin360;
        _style.syncOrigin180 = this.syncOrigin180;
        _style.syncOrigin90 = this.syncOrigin90;
        _style.syncOriginHorzontal = this.syncOriginHorzontal;
        _style.syncOriginVertical = this.syncOriginVertical;
        _style.syncFillAmount = this.syncFillAmount;
        _style.syncClockwise = this.syncClockwise;

        return _style;
    }

    public EasyUI_Image MakeCopy(Image image)
    {
        EasyUI_Image _style = new EasyUI_Image();
        _style.styleName = image.gameObject.name + " style";
        _style.color = image.color;
        _style.sprite = image.sprite;
        _style.material = image.material;
        _style.raycastTarget = image.raycastTarget;
        _style.imageType = image.type;
        _style.fillCenter = image.fillCenter;
        _style.fillMethod = image.fillMethod;
        _style.origin360 = (Image.Origin360)image.fillOrigin;
        _style.origin180 = (Image.Origin180)image.fillOrigin;
        _style.origin90 = (Image.Origin90)image.fillOrigin;
        _style.originHorz = (Image.OriginHorizontal)image.fillOrigin;
        _style.originVert = (Image.OriginVertical)image.fillOrigin;
        _style.fillAmount = image.fillAmount;
        _style.clockwise = image.fillClockwise;

        return _style;
    }
}

[System.Serializable]
public class EasyUI_Text : EasyUIStyle_Base
{
	public Font font;
	public FontStyle fontStyle = FontStyle.Normal;
	public int fontSize = 14;
	public Color textColor = new Color(0f,0f,0f,1f);
	public Material textMat;
	public TextAnchor textAnchor = TextAnchor.UpperLeft;
	public HorizontalWrapMode horzWrap = HorizontalWrapMode.Overflow;
	public VerticalWrapMode vertWrap = VerticalWrapMode.Truncate;
	public bool resizeForBestFit;
	public int minSize = 10;
	public int maxSize = 40;
	public bool isRaycastTarget = true;

    public bool syncFont = true;
    public bool syncFontStyle = true;
    public bool syncFontSize = true;
    public bool syncTextColor = true;
    public bool syncTexMat = true;
    public bool syncTextAnchor = true;
    public bool syncHorizontalWrapMode = true;
    public bool syncVerticalWrapMode = true;
    public bool syncBestFit = true;
    public bool syncRaycastTarget = true;

    public override void ToggleAll(bool _isOn)
    {
        syncFont = _isOn;
        syncFontStyle = _isOn;
        syncFontSize = _isOn;
        syncTextColor = _isOn;
        syncTexMat = _isOn;
        syncTextAnchor = _isOn;
        syncHorizontalWrapMode = _isOn;
        syncVerticalWrapMode = _isOn;
        syncBestFit = _isOn;
        syncRaycastTarget = _isOn;
    }

    public override EasyUIStyle_Base MakeCopy()
    {
        EasyUI_Text _style = new EasyUI_Text();
        _style.styleName = "New Text Style";

        _style.font = this.font;
        _style.fontStyle = this.fontStyle;
        _style.fontSize = this.fontSize;
        _style.textColor = this.textColor;
        _style.textMat = this.textMat;
        _style.textAnchor = this.textAnchor;
        _style.horzWrap = this.horzWrap;
        _style.vertWrap = this.vertWrap;
        _style.resizeForBestFit = this.resizeForBestFit;
        _style.minSize = this.minSize;
        _style.maxSize = this.maxSize;
        _style.isRaycastTarget = this.isRaycastTarget;

		_style.syncFont = this.syncFont;
		_style.syncFontStyle = this.syncFontStyle;
		_style.syncFontSize = this.syncFontSize;
		_style.syncTextColor = this.syncTextColor;
		_style.syncTexMat = this.syncTexMat;
		_style.syncTextAnchor = this.syncTextAnchor;
		_style.syncHorizontalWrapMode = this.syncHorizontalWrapMode;
		_style.syncVerticalWrapMode = this.syncVerticalWrapMode;
		_style.syncBestFit = this.syncBestFit;
		_style.syncRaycastTarget = this.syncRaycastTarget;

        return _style;
    }

    public EasyUI_Text MakeCopy(Text text)
    {
        EasyUI_Text _style = new EasyUI_Text();
        _style.styleName = text.name + " style";
        _style.font = text.font;
        _style.fontStyle = text.fontStyle;
        _style.fontSize = text.fontSize;
        _style.textColor = text.color;
        _style.textMat = text.material;
        _style.textAnchor = text.alignment;
        _style.horzWrap = text.horizontalOverflow;
        _style.vertWrap = text.verticalOverflow;
        _style.resizeForBestFit = text.resizeTextForBestFit;
        _style.minSize = text.resizeTextMinSize;
        _style.maxSize = text.resizeTextMaxSize;
        _style.isRaycastTarget = text.raycastTarget;

        return _style;
    }
}

[System.Serializable]
public class EasyUI_Button : EasyUIStyle_Base
{

}

[System.Serializable]
public class EasyUI_Toggle : EasyUI_Button
{

}

[System.Serializable]
public class EasyUI_Slider : EasyUI_Button
{
	
}

[System.Serializable]
public class EasyUI_Input : EasyUI_Button
{
	
}

[System.Serializable]
public class EasyUI_Dropdown : EasyUI_Button
{
	
    }

[System.Serializable]
public class EasyUI_TMPText : EasyUIStyle_Base
{

    
}

[System.Serializable]
public class EasyUI_TMPInput : EasyUI_Input
{
    
}

[System.Serializable]
public class EasyUI_TMPDropDown: EasyUI_Dropdown
{
    
}

