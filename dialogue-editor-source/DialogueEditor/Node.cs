using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DialogueEditor {

	public class Node {
		private string npcText;
		private string id;
		private List<Choice> choices = new List<Choice>();
		
		public string NPC {
			get {return npcText;}
			set {npcText = value;}
		}
		public string ID {
			get {return id;}
			set {id = value;}
		}
		public List<Choice> Choices {
			get {return choices;}
			set	{choices = value;}
		}
		
		public Node (string npc, string id, List<Choice> choices){
			NPC = npc;
			ID = id;
			Choices = choices;
		}
        public Node () {
            NPC = "";
            ID = "";
            Choices = new List<Choice>();
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NPC text: '" + NPC + "'");
            sb.AppendLine("ID: '" + ID + "'");
            sb.AppendLine("Choices:");
            for (int i = 0; i < Choices.Count; i ++) {
               sb.AppendLine(Choices[i].ToString());
          }
            return sb.ToString(0,sb.Length);
        }
        /// <summary>
        /// Returns a copy of this Node.
        /// </summary>
        public Node Copy() {
            List<Choice> choiceListCopy = new List<Choice>(this.Choices.Count);
            foreach (Choice c in this.Choices) {
                 choiceListCopy.Add(c.Copy());
            }
            Node nodeCopy = new Node(this.npcText, this.id, choiceListCopy);
            return nodeCopy;
        }
        /// <summary>
        /// Determines whether a specified Node is equal to the current Node, in terms of value.
        /// </summary>
        public bool ValueEquals (Node comparedNode) {
            if (this.ID != comparedNode.ID) {
                return false;
            } else if (this.NPC != comparedNode.NPC) {
                return false;
            } else if (this.Choices.Count != comparedNode.Choices.Count) {
                return false;
            } else {
                for (int index = 0; index < this.Choices.Count; index ++) {
                    if (!this.Choices[index].ValueEquals(comparedNode.Choices[index])) {
                        return false;
                    }
                }
                return true;
            }
        }
	}
}
