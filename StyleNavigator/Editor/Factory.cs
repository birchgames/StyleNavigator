using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StyleNavigator
{
    public static class Factory
    {
        public static FlexibleGUI CreateButton(string name){
            return new FlexibleButton(name);
        }
        public static FlexibleGUI CreateBox(string name){
            return new FlexibleBox(name);
        }
        public static FlexibleGUI CreateToolbar(string name){
            return new FlexibleToolbar(name);
        }
        public static FlexibleGUI CreateEnumPopup(string name){
            return new FlexibleEnumPopup(name);
        }
        public static FlexibleGUI CreateLabel(string name){
            return new FlexibleLabel(name);
        }
      
        public static FlexibleGUI CreateTextArea(string name){
            return new FlexibleTextArea(name);
        }
        public static FlexibleGUI CreateToggle(string name){
            return new FlexibleToggle(name);
        }
     
    
    
    }
}