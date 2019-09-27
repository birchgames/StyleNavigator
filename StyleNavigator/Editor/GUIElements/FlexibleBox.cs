using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StyleNavigator
{
    

    public class FlexibleBox:FlexibleGUI
    {
        public FlexibleBox(string name) : base(name)
        {
        }

        public override void Draw()
        {
            Draw(new GUIContent("Default"),null,0);
        }

        public override void Draw(GUIContent content,GUIStyle style,float horizontalSpace)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(horizontalSpace);
            GUILayout.Box(content,style,BasicOptions);
            GUILayout.EndHorizontal();
        }
    }
}