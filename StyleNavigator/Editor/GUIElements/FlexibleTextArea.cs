using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace StyleNavigator
{
    public class FlexibleTextArea : FlexibleGUI
        {
            private string value;

            public FlexibleTextArea(string name) : base(name)
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
                value=EditorGUILayout.TextArea(value,style,BasicOptions);
                GUILayout.EndHorizontal();
            }

        
        }
}