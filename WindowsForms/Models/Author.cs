using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace WindowsForms.Models
{

    [Serializable, XmlRoot(ElementName = "Authors_table")]
    [XmlType("Authors_table")]
    public class Authors_table
    {
        [XmlElement("author")]
        public List<Author> Authors { get; set; }
        
    }
    public class Author
    {
        [XmlElement("au_id")]
        public string au_id { get; set; }

        [XmlElement("au_lname")]
        public string au_lname { get; set; }

        [XmlElement("au_fname")]
        public string au_fname { get; set; }

        [XmlElement("phone")]
        public string phone { get; set; }

        [XmlElement("address")]
        public string address { get; set; }

        [XmlElement("city")]
        public string city { get; set; }

        [XmlElement("state")]
        public string state { get; set; }

        [XmlElement("zip")]
        public string zip { get; set; }

        [XmlElement("contract")]
        public bool contract { get; set; }
    }
}
