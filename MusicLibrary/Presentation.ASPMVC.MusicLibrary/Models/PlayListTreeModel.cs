using Ext.Net;
namespace MusicManager.Presentation.ASPMVC.MusicLibrary.Models
{
    public class PlayListTreeModel 
    {
        public static Ext.Net.Node BuildTree()
        {
            Ext.Net.Node root = new Ext.Net.Node();
            root.Text = "Root";

            Ext.Net.Node musicNode = new Ext.Net.Node();
            musicNode.Leaf = true;
            musicNode.Text="Music";
            musicNode.NodeID = "Music";

            Ext.Net.Node genreNode = new Ext.Net.Node();
            genreNode.Leaf = false;
            genreNode.NodeID = "Genre";
            genreNode.Text = "Genre";
            genreNode.Expanded = false;
            genreNode.Icon = Icon.Folder;

            
            Node danceNode = getNode("Dance");
            Node hiphopNode = getNode("HipHop");
            Node popNode = getNode("Pop");
            Node rockNode = getNode("Rock");

            genreNode.Children.Add(danceNode);
            genreNode.Children.Add(hiphopNode);
            genreNode.Children.Add(danceNode);
            genreNode.Children.Add(rockNode);
            
            


            root.Children.Add(musicNode);
            root.Children.Add(genreNode);
           

            return root;
        }


        public static Node getNode(string title)
        {
            Ext.Net.Node node = new Ext.Net.Node();
            node.Leaf = true;
            node.Text = title;
            node.NodeID = title;
            return node;
        }


    }
}
