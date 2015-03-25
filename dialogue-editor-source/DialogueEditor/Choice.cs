using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogueEditor {
	public class Choice{

        private string targetID;
        private string playerText;
        public string Target {
            get{return targetID;}
            set{targetID = value;}}
        public string Player{
            get{return playerText;}
            set{playerText = value;}}

        public Choice() {
            Player = "";
            Target = "";
        }
		public Choice (string player, string target){
			Player = player;
			Target = target;
		}
        public override string ToString () {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("User Text: '" + Player + "'");
            sb.AppendLine("Target Node: '" + Target + "'");
            return sb.ToString(0, sb.Length);
        }
        /// <summary>
        /// Returns a copy of this Choice.
        /// </summary>
        public Choice Copy() {
            Choice choiceCopy = new Choice(this.playerText, this.targetID);
            return choiceCopy;
        }
        /// <summary>
        /// Determines whether a specified Choice is equal to the current Choice, in terms of value. 
        /// </summary>
        public bool ValueEquals(Choice comparedChoice) {
            if (this.Player != comparedChoice.Player) {
                return false;
            } else if (this.Target != comparedChoice.Target) {
                return false;
            } else {
                return true;
            }
        }
	}
}