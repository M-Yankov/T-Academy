using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XML_TreeView
{
    public partial class XmlProcess : Page
    {
        private const string ADDITIONAL_INDENTATION = "    ";
        private const string DEFAULT_INDENTATION = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NodeChaaged(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            this.GetChildNodesRecursive((sender as TreeView).SelectedNode, result);
            this.literalXMl.Text = result.ToString();
            this.labelXML.Text = Server.HtmlEncode(result.ToString());
        }

        private void GetChildNodesRecursive(TreeNode node, StringBuilder result, string indent = DEFAULT_INDENTATION)
        {
            result.AppendLine(indent + "<" + node.Value + ">");

            if (node.ChildNodes.Count > 0)
            {
                foreach (TreeNode item in node.ChildNodes)
                {
                    this.GetChildNodesRecursive(item, result, indent + ADDITIONAL_INDENTATION);
                }
            }
            else
            {
                result.AppendLine(indent + ADDITIONAL_INDENTATION + node.Text);
            }

            result.AppendLine(indent + "</" + node.Value + ">");
        }
    }
}