using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StyleNavigator
{
    public class FlexibleToolbar : FlexibleGUI
        {
            int selected=0;
            string[] choices;
            public FlexibleToolbar(string name) : base(name)
            {
                choices=new string[5];
                for(int i=0;i<choices.Length;i++)
                    choices[i]="Toolbar-"+(i+1).ToString();
            }

            public override void Draw()
            {
                Draw(new GUIContent("Default"),null,0);
            }
            public override void Draw(GUIContent content, GUIStyle style, float horizontalSpace)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(horizontalSpace);
                selected=GUILayout.Toolbar(selected,choices,style,BasicOptions);
                GUILayout.EndHorizontal();
            }

        
        }
}