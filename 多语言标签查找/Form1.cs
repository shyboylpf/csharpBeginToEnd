using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 多语言标签查找
{
    public partial class Form1 : Form
    {
        private List<Language> mylist = new List<Language>();

        public Form1()
        {
            InitializeComponent();
            loadLanguageXML();
        }

        private void loadLanguageXML()
        {
            string xmlPath = "zh-cn.xml";
            using (FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(fs);
                //获取根节点
                XmlNode root = xDoc.DocumentElement;
                foreach (XmlNode item in root.ChildNodes)
                {
                    //输出子节点
                    foreach (XmlNode node in item.ChildNodes)
                    {
                        Language info = new Language();
                        info.Module = item.Attributes["ID"].InnerText;
                        info.Key = node.Attributes["ID"].InnerText;
                        info.Value = node.InnerText;
                        mylist.Add(info);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string content = textBox1.Text;
            var item = mylist.FirstOrDefault(q => q.Value.Equals(content));
            if (item != null)
            {
                string label = $"{item.Module}_{item.Key}";
                textBox2.Text = label;
                textBox3.Text = $"<%=base.Lang_CurrentUser(\"{label}\") %>";
            }
            else
            {
                textBox2.Text = "无数据";
                textBox3.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xmlPath = "zh-cn.xml";
            string xmlPathEn = "en-us.xml";

            XmlDocument xDoc = new XmlDocument();
            string sourceContent = textBox1.Text;
            string translateContent = textBox4.Text;
            if (string.IsNullOrEmpty(sourceContent) || string.IsNullOrEmpty(translateContent))
            {
                MessageBox.Show("有空值");
                return;
            }
            XmlNode xmlNodeAtt = xDoc.CreateAttribute("ID");
            var translateContentSplit = translateContent.Split(" ").ToList();

            for (int i = 0; i < translateContentSplit.Count; i++)
            {
                translateContentSplit[i] = char.ToUpper(translateContentSplit[i][0]) + translateContentSplit[i].Substring(1);
            }

            xmlNodeAtt.Value = "lbl_" + string.Join("", translateContentSplit);

            XmlNode xmlNode = xDoc.CreateElement("tag");
            xmlNode.Attributes.SetNamedItem(xmlNodeAtt);

            mylist.Add(new Language()
            {
                Module = "web",
                Key = xmlNodeAtt.Value,
                Value = sourceContent
            });

            using (FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                xDoc.Load(fs);
            }
            using (FileStream fs = new FileStream(xmlPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                xmlNode.InnerText = sourceContent;
                //获取根节点
                XmlNode root = xDoc.DocumentElement;
                var nodes = root.ChildNodes;
                XmlNode webNode = nodes.Item(5);
                foreach (XmlNode node in nodes)
                {
                    if (node.ChildNodes.Count != 0)
                    {
                        string att = node.Attributes["ID"].InnerText;

                        if (!string.IsNullOrEmpty(att) && att.Equals("web"))
                        {
                            webNode = node;
                        }
                    }
                }
                webNode.AppendChild(xmlNode);

                xDoc.Save(fs);
            }
            using (FileStream fs = new FileStream(xmlPathEn, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                xDoc.Load(fs);
            }
            using (FileStream fs = new FileStream(xmlPathEn, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                xmlNode.InnerText = translateContent;
                //获取根节点
                XmlNode root = xDoc.DocumentElement;
                var nodes = root.ChildNodes;
                XmlNode webNode = nodes.Item(5);
                foreach (XmlNode node in nodes)
                {
                    if (node.ChildNodes.Count != 0)
                    {
                        string att = node.Attributes["ID"].InnerText;

                        if (!string.IsNullOrEmpty(att) && att.Equals("web"))
                        {
                            webNode = node;
                        }
                    }
                }
                webNode.AppendChild(xmlNode);

                xDoc.Save(fs);
            }
            button1_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mylist = new List<Language>();
            loadLanguageXML();
            MessageBox.Show("reload success");
        }
    }

    [DataContract]
    [Serializable]
    public class Language
    {
        private string _Module = "";

        /// <summary>
        /// 模块
        /// </summary>
        [DataMember]
        public string Module
        {
            get { return _Module; }
            set { _Module = value; }
        }

        private string _Key = "";

        /// <summary>
        /// 键
        /// </summary>
        [DataMember]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        private string _Value = "";

        /// <summary>
        /// 值
        /// </summary>
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}