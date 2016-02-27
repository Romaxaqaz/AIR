using Domain.Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Lab5
{
    public static class XDocumentSerializer
    {
        private static string path = "myxml.xml";
        private static readonly string NameXmlDataTag = "Data";
        private static object returnObj = null;
        public static string Path { get { return path; } set { path = value; } }

        public static void CreateXML<T>(IEnumerable<T> enumerable) where T : DataStorage
        {
            XDocument xDoc = new XDocument();
            XElement typeData = new XElement(NameXmlDataTag);
            xDoc.Add(typeData);
            foreach (var item in enumerable)
            {
                SaveObjectToXML(item, xDoc);
            }
        }

        public static void CreateXMLfromObject<T>(T obj) where T : DataStorage
        {
            XDocument xDoc = new XDocument();
            XElement typeData = new XElement(NameXmlDataTag);
            xDoc.Add(typeData);

            var type = obj.GetType();
            var properties = type.GetProperties();

            XElement item = new XElement(type.Name);
            foreach (var propertyInfo in properties)
            {
                XElement name = new XElement(propertyInfo.Name);
                name.Value = propertyInfo.GetValue(obj).ToString();
                item.Add(name);
            }
            xDoc.Root.Add(item);
            xDoc.Save(path);
        }


        private static void SaveObjectToXML<T>(T obj, XDocument xDoc)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            XElement item = new XElement(type.FullName);
            foreach (var propertyInfo in properties)
            {
                XElement name = new XElement(propertyInfo.Name);
                name.Value = propertyInfo.GetValue(obj).ToString();
                item.Add(name);
            }
            xDoc.Root.Add(item);
            xDoc.Save(path);
        }

        public static T GetXmlObject<T>() where T : DataStorage
        {
            var returnObj = Activator.CreateInstance<T>();
            XDocument xDoc = XDocument.Load(path);
            Type type = typeof(T);

            foreach (XElement el in xDoc.Root.Elements())
            {
                foreach (XElement element in el.Elements())
                {
                    var property = type.GetProperty(element.Name.LocalName);
                    property.SetValue(returnObj, Convert.ChangeType(element.Value, property.PropertyType));
                }
            }
            return returnObj;
        }

        public static List<DataStorage> GetXml<T>() where T : DataStorage
        {
            var listData = new List<DataStorage>();
            XDocument xDoc = XDocument.Load(path);
            Type type = typeof(T);

            foreach (XElement mainElement in xDoc.Root.Elements())
            {
                type = Type.GetType(mainElement.Name.LocalName);
                returnObj = Activator.CreateInstance(type, new object[] { });
                foreach (XElement secondElement in mainElement.Elements())
                {
                    var property = type.GetProperty(secondElement.Name.LocalName);
                    property.SetValue(returnObj, Convert.ChangeType(secondElement.Value, property.PropertyType));
                }
                listData.Add((T)returnObj);
            }
            return listData;
        }
    }
}
