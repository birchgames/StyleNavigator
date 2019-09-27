using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace StyleNavigator
{
    public class StyleNavigator : EditorWindow {

    [MenuItem("Window/StyleNavigator")]
    private static void ShowWindow() {
        var window = GetWindow<StyleNavigator>();
        window.titleContent = new GUIContent("StyleNavigator");
        window.Show();
    }

    private Vector2 scrollVal,styleScrollVal;
    private List<FlexibleGUI> elements;
    private GUIContent content;
    private string textContent="Content";
    private Texture2D textureContent;
    private string tooltip="Tooltip";

    private GUISkin skin;
    private float width=480,height=60;
    private StyleNavigator.EditorSkin editorSkin=StyleNavigator.EditorSkin.Inspector;
    private int selection=92;
    private string searchText="";
    public enum EditorSkin
    {
        Scene,
        Inspector
    }
    private void OnEnable() {
        
        elements=new List<FlexibleGUI>();
        string texturePath="Assets/StyleNavigator/birch_games_logo_4.png";
        if(System.IO.File.Exists(texturePath))
            textureContent=(Texture2D)AssetDatabase.LoadAssetAtPath(texturePath,typeof(Texture2D));
         elements.Add(Factory.CreateBox("GUI.Box"));
    }
    private void OnGUI() {

            skin=editorSkin==StyleNavigator.EditorSkin.Inspector?EditorGUIUtility.GetBuiltinSkin(UnityEditor.EditorSkin.Inspector):
                                                                 EditorGUIUtility.GetBuiltinSkin(UnityEditor.EditorSkin.Scene);

           GUIStyle textField=new GUIStyle(EditorStyles.textField){
                
           } ;
    GUIStyle h1 = new GUIStyle(skin.customStyles[137])
        {
            font= EditorStyles.whiteMiniLabel.font,
            fontStyle = FontStyle.Bold,
            fontSize = 21,
            margin = new RectOffset(0, 0, 0, 10),
            contentOffset=new Vector2(0,-14),
            alignment = TextAnchor.MiddleCenter
        };
          GUIStyle h2Hex = new GUIStyle(skin.customStyles[161])
        {
            font= EditorStyles.whiteMiniLabel.font,
            fontStyle = FontStyle.Bold,
            contentOffset=new Vector2(0,3),
            padding=new RectOffset(0,0,8,0),
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter
        };
        GUIStyle h2 = new GUIStyle(skin.customStyles[139])
        {
            font= EditorStyles.whiteMiniLabel.font,
            fontStyle = FontStyle.Bold,
            contentOffset=new Vector2(0,-2),
            padding=new RectOffset(0,0,8,0),
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter
        };

        GUIStyle box=new GUIStyle(skin.customStyles[570]){

        };

        GUIStyle label=new GUIStyle(EditorStyles.whiteMiniLabel){
                fontSize=11,
        };
        GUIStyle buttonStyle = new GUIStyle(skin.customStyles[43]);

        GUILayout.BeginVertical(skin.customStyles[144]);

        GUILayout.BeginHorizontal();
        GUILayout.Space(-200+position.width/2);
        GUILayout.Label("Style Navigator",h1,GUILayout.Width(400));
        GUILayout.EndHorizontal();

        

        GUILayout.Space(15);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Content text:",label,GUILayout.Width(120));
        textContent=GUILayout.TextField(textContent,textField,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Content texture:",label,GUILayout.Width(120));
        textureContent=(Texture2D)EditorGUILayout.ObjectField(textureContent,typeof(Texture2D),false,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Tooltip:",label,GUILayout.Width(120));
        tooltip=GUILayout.TextField(tooltip,textField,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Content Width:",label,GUILayout.Width(120));
        width=EditorGUILayout.Slider(width,20,600,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Content Height:",label,GUILayout.Width(120));
        height=EditorGUILayout.Slider(height,20,600,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Style Index:",label,GUILayout.Width(120));
        selection=EditorGUILayout.IntSlider(selection,0,575,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Skin Choice:",label,GUILayout.Width(120));
        editorSkin=(StyleNavigator.EditorSkin)EditorGUILayout.EnumPopup(editorSkin,GUILayout.Width(position.width-130));
        GUILayout.EndHorizontal();
       

        GUILayout.EndVertical();
       
       Rect lastRect=GUILayoutUtility.GetLastRect();

    scrollVal=GUILayout.BeginScrollView(scrollVal,skin.customStyles[138],GUILayout.MaxHeight(position.height-lastRect.height-100));



        GUILayout.Space(15);
        GUILayout.BeginHorizontal();
        DrawFlexibleGUIElements(elements,new GUIContent(textContent,textureContent,tooltip),new GUIStyle(skin.customStyles[selection]),20);
        
        GUILayout.BeginVertical(skin.box,GUILayout.Width(110));
        GUILayout.Label("Current Skin : "+editorSkin.ToString(),EditorStyles.boldLabel);
        GUILayout.Label("Current Style : "+skin.customStyles[selection],EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Search:",GUILayout.Width(45));
        searchText=GUILayout.TextField(searchText,skin.customStyles[534]);
          GUILayout.EndHorizontal();
        GUILayout.Space(5);
        styleScrollVal=GUILayout.BeginScrollView(styleScrollVal,GUILayout.MaxHeight(position.height-lastRect.height-100));
        for(int i=0;i<skin.customStyles.Length;i++){
            GUIStyle currentStyle=skin.customStyles[i];
            if(searchText!=null&&currentStyle.name.ToLower().Contains(searchText.ToLower()))
                GUILayout.Label(i.ToString()+" : "+currentStyle.name);
        }
        GUILayout.EndScrollView();

      

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();


        float w=110;
        GUILayout.BeginVertical(skin.customStyles[142]);
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Add Button",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateButton("GUI.Button"));
        }
        if(GUILayout.Button("Add Box",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateBox("GUI.Box"));
        }
        if(GUILayout.Button("Add Toolbar",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateToolbar("GUI.Toolbar"));
        }
         if(GUILayout.Button("Add EnumPopup",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateEnumPopup("GUI.EnumPopup"));
        }
         if(GUILayout.Button("Add Label",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateLabel("GUI.Label"));
        }
    
         if(GUILayout.Button("Add TextArea",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateTextArea("GUI.TextArea"));
        }
         if(GUILayout.Button("Add Toggle",buttonStyle,GUILayout.Width(w))){
            elements.Add(Factory.CreateToggle("GUI.Toggle"));
        }
        
         if(GUILayout.Button("Clear",buttonStyle,GUILayout.Width(w))){
            elements.Clear();}

        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
          

    }

    private void DrawFlexibleGUIElements(List<FlexibleGUI> lst,GUIContent content,GUIStyle style,float horizontalSpace){

            GUILayout.BeginVertical();
            foreach (var item in lst)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(20);
                item.Width=width;
                item.Height=height;
                
                GUILayout.Label(item.name+" ------------------ ",EditorStyles.whiteMiniLabel,GUILayout.Width(100));
                GUILayout.Space(10);
                item.Draw(content,style,horizontalSpace);
                GUILayout.EndHorizontal();
            }
                    GUILayout.EndVertical();
    }
}
}



