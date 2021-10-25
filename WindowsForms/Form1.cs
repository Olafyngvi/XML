using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsForms.Models;
using System.Xml.Serialization;
using System.IO;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\example.xml";
        public Author authors { get; set; }
        public string Xml { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            while (reader.Read())
            {
                // Do some work here on the data.
                
            }
            Console.ReadLine();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\example.xml";

            AuthorsDataSet.ReadXml(filePath);
            Xml = Serialize(new Authors_table());
            Authors_table authors = DeserializeXMLFileToObject<Authors_table>(filePath);

            txtIme.Text = authors.Authors[0].au_fname;
            txtPrezime.Text = authors.Authors[0].au_lname;
            txtAdresa.Text = authors.Authors[0].address;

            dataGridView1.DataSource = AuthorsDataSet;
            dataGridView1.DataMember = "author";
        }

        private void ShowSchemaButton_Click(object sender, EventArgs e)
        {
            StringWriter swXML = new StringWriter();
            AuthorsDataSet.WriteXmlSchema(swXML);
            textBox1.Text = swXML.ToString();
        }
        private string Serialize(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using (var stringWriter = new StringWriter())
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(stringWriter, obj, ns);
                return stringWriter.ToString();
            }
        }
        private static T DeserializeXMLFileToObject<T>(string XmlFilename)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StreamReader xmlStream = new StreamReader(XmlFilename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnObject;
        }
    }
}
