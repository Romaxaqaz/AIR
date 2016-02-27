using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace Domain.Lab5
{
    public class XmlDocumentSerializer
    {
        #region Serialize
        public XmlDocument Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            if (obj is IEnumerable)
            {
                return this.SerializeEnumeration(obj as IEnumerable);
            }

            return this.SerializeObject(obj);
        }

        private XmlDocument SerializeEnumeration(IEnumerable obj)
        {
            var doc = new XmlDocument();
            var collectionElement = doc.CreateElement("collection");
            foreach (var item in obj)
            {
                this.InsertObjectXml(doc, item, collectionElement);
            }

            doc.AppendChild(collectionElement);
            return doc;
        }

        private XmlDocument SerializeObject(object obj)
        {
            var doc = new XmlDocument();
            this.InsertObjectXml(doc, obj);
            return doc;
        }

        private void PopulateInstance(object instance, XmlNode element)
        {
            var values = this.GetValuesFromXml(element);
            var objectType = instance.GetType();

            foreach (var property in objectType.GetProperties())
            {
                this.TrySetProperty(instance, values, property);
            }
        }

        private Dictionary<string, string> GetPropertyValues(object obj)
        {
            var objectType = obj.GetType();
            var values = new Dictionary<string, string>();

            foreach (var property in objectType.GetProperties())
            {
                values.Add(property.Name, property.GetValue(obj).ToString());
            }

            return values;
        }

        private void InsertObjectXml(XmlDocument doc, object obj, XmlNode parentNode = null)
        {
            var values = this.GetPropertyValues(obj);

            var root = doc.CreateElement(obj.GetType().FullName);
            (parentNode ?? doc).AppendChild(root);

            foreach (var property in values)
            {
                var element = doc.CreateElement(property.Key);
                element.InnerText = property.Value;
                root.AppendChild(element);
            }
        }
        #endregion

        #region Deserialize
        public T Deserialize<T>(XmlDocument doc) where T : class, new()
        {
            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }

            if (typeof(T).GetInterfaces().Any(x => x == typeof(IEnumerable)))
            {
                return this.DeserializeEnumeration<T>(doc);
            }

            return DeserializeObject<T>(doc.FirstChild);
        }

        private T DeserializeEnumeration<T>(XmlDocument doc) where T : class, new()
        {
            XmlDocumentSerializer.ValidateDocument(doc);

            Type genericArgument = typeof(T).GenericTypeArguments.First();
            var outputList = GetOutputList<T>(genericArgument);
            var currentNode = doc.FirstChild.FirstChild;

            while (currentNode != null)
            {
                var instance = this.DeserializeObject(Type.GetType(currentNode.Name), currentNode);

                outputList.Add(instance);
                currentNode = currentNode.NextSibling;
            }

            return outputList as T;
        }

        private static IList GetOutputList<T>(Type genericArgument) where T : class, new()
        {
            var listType = typeof(List<>);
            listType = listType.MakeGenericType(genericArgument);
            return Activator.CreateInstance(listType) as IList;
        }

        private static void ValidateDocument(XmlDocument doc)
        {
            doc.Schemas.Add(XmlSchema.Read(new StringReader(Resource.Schema), null));
            doc.Validate((sender, e) => { throw e.Exception; });
        }

        private T DeserializeObject<T>(XmlNode xmlNode) where T : new()
        {
            var instance = Activator.CreateInstance<T>();
            this.PopulateInstance(instance, xmlNode);
            return instance;
        }

        private object DeserializeObject(Type type, XmlNode xmlNode)
        {
            var instance = Activator.CreateInstance(type);
            this.PopulateInstance(instance, xmlNode);
            return instance;
        }

        private void TrySetProperty<T>(T instance, Dictionary<string, string> values, System.Reflection.PropertyInfo property) where T : new()
        {
            var propertyValue = values.FirstOrDefault(x => x.Key == property.Name);

            if (propertyValue.Equals(null) == false)
            {
                try
                {
                    property.SetValue(instance, Convert.ChangeType(propertyValue.Value, property.PropertyType));
                }
                catch
                {
                    // log or something
                }
            }
        }

        private Dictionary<string, string> GetValuesFromXml(XmlNode xmlRoot)
        {
            var values = new Dictionary<string, string>();
            var nodes = xmlRoot.ChildNodes;

            for (int i = 0; i < nodes.Count; i++)
            {
                values.Add(nodes[i].Name, nodes[i].InnerText);
            }

            return values;
        }
        #endregion
    }
}
