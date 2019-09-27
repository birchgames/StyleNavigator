using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StyleNavigator
{

    public enum ExampleEnum{
        Enum1,
        Enum2,
        Enum3,
        Enum4,
        Enum5
    }
    public class FlexibleEnumPopup : FlexibleGUI
        {
            private ExampleEnum example;
            public FlexibleEnumPopup(string name) : base(name)
            {
            }

            public override void Draw()
            {
                Draw(new GUIContent("Default"),null,0);
            }
            public override void Draw(GUIContent content, GUIStyle style, float horizontalSpace)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(horizontalSpace);
                example=(ExampleEnum)EditorGUILayout.EnumPopup(example,style,BasicOptions);
                GUILayout.EndHorizontal();
            }

        
        }
}