using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace DialogueEditor {
    /// <summary>
    /// Singleton; deals with data serialization/deserialisation, storage and access
    /// </summary>
    public class Data {
        private static Data  instance = new Data();
        public static Data Instance {
            get {return instance;}
            set {instance = value;}
        }
        private Node[] nodes;

        Queue<string> SpareIDS;
        Dictionary<string, Node> nodesByID;
        Dictionary<string, Node> savedNodesByID;
        
        private Data() {
            SpareIDS = new Queue<string>();
            nodes = new Node[0];
            nodesByID = new Dictionary<string,Node>();
            savedNodesByID = GetIDNodeDictionary(nodes, true);
        }
        public Node AddNode() {
            Node n = new Node();
            if (SpareIDS.Count == 0) {
                Node[] nodesTemp = nodes;
                nodes = new Node[nodesTemp.Length + 1];
                nodesTemp.CopyTo(nodes, 0);
                nodes[nodesTemp.Length] = n;
                n.ID = Base64.ConvertTo(nodesTemp.Length);
            }
            else{
                n.ID = SpareIDS.Dequeue();
                nodes[Base64.ConvertFrom(n.ID)] = n;
            }
            nodesByID[n.ID] = n;
            return n;
        }
        /// <summary>
        /// Attempts to remove a node of specified ID; returns true if sucessful.
        /// </summary>
        public bool RemoveNode(string id) {
            try{
                if (nodes[Base64.ConvertFrom(id)] != null) {
                    nodes[Base64.ConvertFrom(id)] = null;
                    nodesByID.Remove(id);
                    SpareIDS.Enqueue(id);
                    return true;
                }
                else {
                    return false;
                }
            }catch (IndexOutOfRangeException) {
                return false;
            }
        }
        /// <summary>
        /// Gets the Node corrosponding to specified ID; returns null if no Node is found.
        /// </summary>
        public Node GetNodeByID(string ID) {
            try {return nodesByID[ID];}
            catch (KeyNotFoundException) {
            return null;}
        }
        /// <summary>
        /// Gets an array containing all nodes.
        /// </summary>
        public Node[] Nodes {
            get {
                Node[] allNodes = new Node[nodes.Length];
                int indexCounter = 0;
                foreach (Node n in nodes) {
                    if (n != null) {
                        allNodes[indexCounter] = n;
                        indexCounter ++;
                    }
                }
                Array.Resize(ref allNodes, indexCounter);
                return allNodes;
            }
        }
        /// <summary>
        /// Gets all Nodes that contain one or more choices that target a specified Node.
        /// </summary>
        public List<Node> GetTargetingNodes(Node targetNode) {
            List<Node> targetingNodes = new List<Node>();
            bool nodeHasBeenAdded;
            foreach (Node n in nodes) {
                if (n != null) {
                    nodeHasBeenAdded = false;
                    foreach (Choice c in n.Choices) {
                        if (c.Target == targetNode.ID) {
                            if (!nodeHasBeenAdded) {
                                targetingNodes.Add(n);
                                nodeHasBeenAdded = true;
                            }
                        }
                    }
                }
            }
            return targetingNodes;
        }
        public List<Node> GetNodesByStringSearch(string pattern, NodeSearchLookIn lookIn, 
                bool matchCase, bool wholeWord) {
            if (!matchCase) {
                pattern = pattern.ToUpper();
            }
            if (wholeWord) {
                pattern = " " + pattern + " ";
            }
            List<Node> results = new List<Node>(nodes.Length);
            bool hasMatched;
            foreach (Node n in nodes) {
                if (n != null) {
                    hasMatched = false;
                    if ((lookIn == NodeSearchLookIn.Both) || 
                        (lookIn == NodeSearchLookIn.NPCText)) {
                        if (matchCase) {
                            if (n.NPC.Contains(pattern)) {
                                results.Add(n);
                                hasMatched = true;
                            }
                        } else if (n.NPC.ToUpper().Contains(pattern)) {
                            results.Add(n);
                            hasMatched = true;
                        }
                    }
                    if (!hasMatched) {
                        if ((lookIn == NodeSearchLookIn.Both) || 
                            (lookIn == NodeSearchLookIn.PlayerText)) {
                            for (int index  = 0; ((index < n.Choices.Count) 
                                && !hasMatched); index ++) {
                                if (matchCase) {
                                    if (n.Choices[index].Player.Contains(pattern)) {
                                        results.Add(n);
                                        hasMatched = true;
                                    }
                                } else if (n.Choices[index].Player.ToUpper().Contains(pattern)) {
                                    results.Add(n);
                                    hasMatched = true;
                                }
                            }
                        }
                    }
                }
            }
            return results;
        }
        /// <summary>
        /// Returns a Generic.Dictionary containing Nodes (values) paired to thier IDs (Keys).
        /// </summary>
        private static Dictionary<string, Node> GetIDNodeDictionary(Node[] nodesArray, bool shouldCopyNodes) {
            Dictionary<string, Node>  nodesDictionary = new Dictionary<string,Node>(); 
            foreach (Node n in nodesArray) {
                if (n != null) {
                    if (shouldCopyNodes) {
                        nodesDictionary[n.ID] = n.Copy();
                    } else {
                        nodesDictionary[n.ID] = n;
                    }
                }
            }
            return nodesDictionary;
        }
        public void Clear() {            
            SpareIDS.Clear();
            nodes = new Node[0];
            nodesByID.Clear();
            savedNodesByID.Clear();
            savedNodesByID = GetIDNodeDictionary(nodes, true);
        }
        public int GetGreatestID() {
            return nodes.Length;
        }
        public bool AreIDsIllegal() {
            for (int index = 0; index < nodes.Length; index ++) {
                if (nodes[index] != null) {
                    if (nodes[index].ID != Base64.ConvertTo(index)) {
                        return true;
                    }
                }
            }
            return false;
        }
        public void AssignLegalIDs() {
            for (int i = 0; i < nodes.Length; i ++) {
                if (nodes[i] != null) {
                    string oldNodeID = nodes[i].ID;
                    nodes[i].ID = Base64.ConvertTo(i);
                    for (int n = 0; n < nodes.Length; n ++) {
                        if (nodes[n] != null) {
                            for (int c = 0; c <  nodes[n].Choices.Count; c ++){
                                if (nodes[n].Choices[c].Target == oldNodeID) {
                                    nodes[n].Choices[c].Target = nodes[i].ID;
                                }
                            }
                        }
                    }
                }
            }
            nodesByID = GetIDNodeDictionary(nodes, false);
        }
        public bool IsAllDataSaved() {
            if (savedNodesByID.Count == nodesByID.Count) {
                Dictionary<String,Node>.KeyCollection nodesByIDKeys = nodesByID.Keys;
                foreach (string id in nodesByIDKeys) {
                    if ((!savedNodesByID.ContainsKey(id)) ||
                        (!nodesByID[id].ValueEquals(savedNodesByID[id]))) {
                        return false;
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// Updates the saved version of the data regardless of whether this was ever saved.
        /// </summary>
        public void ForceSaved() {
            savedNodesByID = GetIDNodeDictionary(nodes, true);
        }
        private void cleanUpChoiceTargets () {
            foreach (Node n in nodes) {
                if (n != null) {
                    for (int index = 0; index < n.Choices.Count; index ++) {
                        if (!nodesByID.ContainsKey(n.Choices[index].Target)) {
                            n.Choices[index].Target = "";
                        }
                    }
                }
            }
        }
        public void LoadFile (string path) {
            bool attemptToLoad = true;
            while (attemptToLoad) {
                try {
                    StreamReader streamReader = new StreamReader (path);
                    JsonTextReader reader = new JsonTextReader(streamReader);
                    nodes = new Node[32];
                    Node[] nodesTemp;
                    int greatestNodeIndex = 0;
                    string propertyNameTemp = "";
		            bool hasSavedNode = false;
		            Node nodeTemp;
		            string idTemp = "";		
		            string npcTextTemp = "";
		            List<Choice> choicesTemp = new List<Choice>();
		            string playerTextTemp = null;		
		            string TargetTemp = "";
                    while (reader.Read()) {
                        if (reader.TokenType == JsonToken.PropertyName) {
                            propertyNameTemp = (string)reader.Value;
                        }
                        else if (reader.Depth == 4) {
                            if (propertyNameTemp == "Player") {
                                playerTextTemp = (string)reader.Value;
                            }
                            else if (propertyNameTemp == "Target") {
                                TargetTemp = (string)reader.Value;
                            }
                        }
                        else if (reader.Depth == 2) {
                            if (propertyNameTemp == "NPC") {
                                npcTextTemp = (string) reader.Value;
                                hasSavedNode = false;
                            }
                            else if (propertyNameTemp == "ID") {
                                idTemp = (string) reader.Value;
                            }
                        }
                        else if (reader.Depth == 3) {
                            if (playerTextTemp != null) {
                                choicesTemp.Add(new Choice(playerTextTemp,TargetTemp));
                                playerTextTemp = null;
                            }
                        }
                        else if (reader.Depth == 1) {
                            if (!hasSavedNode) {
                                nodeTemp = new Node(npcTextTemp, idTemp, choicesTemp);
                                choicesTemp = new List<Choice>();
                                int nodeIndexTemp = Base64.ConvertFrom(nodeTemp.ID);
                                if ((nodes.Length - 1) < nodeIndexTemp) {
                                    nodesTemp = nodes;
                                    nodes = new Node[nodeIndexTemp + 32];
                                    nodesTemp.CopyTo(nodes, 0);
                                }
                                    if (greatestNodeIndex < nodeIndexTemp) {
                                        greatestNodeIndex = nodeIndexTemp;
                                    }
                                    nodes[nodeIndexTemp] = nodeTemp;
                                    hasSavedNode = true;
                                }
                            }
                        }
                        if (nodes.Length != greatestNodeIndex) {
                            nodesTemp = nodes;
                            nodes = new Node[greatestNodeIndex + 1];
                            for (int index = 0; index < nodes.Length; index ++) {
                                nodes[index] = nodesTemp[index];
                            }
                        }
                        for (int index = nodes.Length - 1; index > -1; index --) {
                            if (nodes[index] == null) {
                                SpareIDS.Enqueue(Base64.ConvertTo(index));
                            }
                        }
                        nodesByID = GetIDNodeDictionary(nodes, false);
                        savedNodesByID = GetIDNodeDictionary(nodes, true);
                        bool isLooking = true;
                        for (int i = 0; ((i < nodes.Length) && (isLooking)); i++) {
                            if (nodes[i] != null) {
                                NodeEditPanel.RootNodePanel = new NodeEditPanel(nodes[0]);
                            }
                        }
                        streamReader.Close();
                        streamReader.Dispose();
                        cleanUpChoiceTargets();
                        attemptToLoad = false;
                    }
                    catch (IOException) {
                        DialogResult messageResult = System.Windows.Forms.MessageBox.Show
                            ("The file you are trying to access is in use.", "Unable To Open", 
                            MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (messageResult == DialogResult.Cancel) {
                            attemptToLoad = false;
                        }
                    }
                }
            }
            public void SaveFile(string path) {
                bool attemptToSave = true;
                while (attemptToSave) {
                try {
                    JsonSerializer serializer = new JsonSerializer();
                    StreamWriter streamWriter = File.CreateText(path);
                    serializer.Serialize(streamWriter, nodes);
                    streamWriter.Close();
                    streamWriter.Dispose();
                    savedNodesByID = Data.GetIDNodeDictionary(nodes, true);
                    attemptToSave = false;
                }
                catch (IOException) {
                    DialogResult messageResult = System.Windows.Forms.MessageBox.Show
                        ("The file you are trying to write to is in use.", "Unable To Save", 
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (messageResult == DialogResult.Cancel) {
                        attemptToSave = false;
                    }
                }
            }
        }
    }
    public enum NodeSearchLookIn : byte {NPCText, PlayerText, Both};
}