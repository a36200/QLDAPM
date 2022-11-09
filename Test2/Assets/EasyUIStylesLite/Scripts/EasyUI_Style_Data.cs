using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (fileName = "EasyUIData",menuName = "Easy UI Style Data Container", order = 1010)]
[System.Serializable]
public class EasyUI_Style_Data : ScriptableObject {

    [SerializeField]
    public List<EasyUI_Image> imageList = new List<EasyUI_Image>();
    [SerializeField]
    public List<EasyUI_Text> textList = new List<EasyUI_Text>();
    [SerializeField]
    public List<EasyUI_Button> buttonList = new List<EasyUI_Button>();
    [SerializeField]
    public List<EasyUI_Toggle> toggleList = new List<EasyUI_Toggle>();
    [SerializeField]
    public List<EasyUI_Slider> sliderList = new List<EasyUI_Slider>();
    [SerializeField]
    public List<EasyUI_Input> inputList = new List<EasyUI_Input>();
    [SerializeField]
    public List<EasyUI_Dropdown> dropdownList = new List<EasyUI_Dropdown>();
    [SerializeField]
    public List<EasyUI_TMPText> tmproTextList = new List<EasyUI_TMPText>();
    [SerializeField]
    public List<EasyUI_TMPInput> tmproInputList = new List<EasyUI_TMPInput>();
    [SerializeField]
    public List<EasyUI_TMPDropDown> tmproDropdownList = new List<EasyUI_TMPDropDown>();

}


