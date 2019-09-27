using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StyleNavigator
{
    public abstract class FlexibleGUI 
    {
        private float contentWidth=100;
        private float contentHeight=150;
        public string name;
        public FlexibleGUI(string name)=>this.name=name;
        public float Width{
            get
            {
                return contentWidth;
            }
            set
            {
                contentWidth=value;
            }
        }
        public float Height{
            get
            {
                return contentHeight;
            }
            set
            {
                contentHeight=value;
            }
        }
        protected GUILayoutOption[] BasicOptions{
            get
            {
                return new[]{GUILayout.Width(contentWidth),GUILayout.Height(contentHeight)};
            }
        }
        public abstract void Draw();
        public abstract void Draw(GUIContent content,GUIStyle style,float horizontalSpace);

    }

   
   

}
