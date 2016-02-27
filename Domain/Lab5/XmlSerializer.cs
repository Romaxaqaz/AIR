using System;
using System.Collections.Generic;
using System.Xml;
using Domain.Lab1;

namespace Domain.Lab5
{
    public static class XmlSerializer
    {
        const string ClassAttribute = "class", CollectionAttribute = "collection";

        public static void Save<T>(T obj, string path) where T : DataStorage
        {
            using (var writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                SaveObject(obj, writer);
                writer.WriteEndDocument();
            }
        }

        public static void Save<T>(IEnumerable<T> collection, string path) where T : DataStorage
        {
            using (var writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(CollectionAttribute);
                writer.WriteAttributeString(ClassAttribute, CollectionAttribute);
                foreach (var obj in collection)
                {
                    SaveObject(obj, writer);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void SaveObject(object obj, XmlWriter writer)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            writer.WriteStartElement(type.FullName);
            writer.WriteAttributeString(ClassAttribute, ClassAttribute);
            foreach (var propertyInfo in properties)
            {
                writer.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(obj).ToString());
            }

            writer.WriteEndElement();
        }

        public static IEnumerable<T> LoadCollection<T>(string path, Func<IEnumerable<T>, IEnumerable<T>> converter = null) where T : DataStorage
        {
            var collection = Activator.CreateInstance<List<T>>();
            using (var reader = XmlReader.Create(path))
            {
                Type type = null;
                reader.Read();
                reader.Read();
                do
                {
                    var obj = LoadObject<T>(reader);
                    if (obj != null)
                    {
                        collection.Add(obj);
                    }

                } while (reader.ReadState != ReadState.EndOfFile);
            }

            return converter == null ? collection : converter(collection);
        }

        private static T LoadObject<T>(XmlReader reader) where T : DataStorage
        {
            object obj = null;
            Type type = null;
            var endELemntName = "";
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.XmlDeclaration) continue;

                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == endELemntName) break;

                if (reader.ReadState == ReadState.EndOfFile ||
                    reader.NodeType == XmlNodeType.EndElement &&
                    reader.Name == CollectionAttribute) return null;

                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.GetAttribute(ClassAttribute) == ClassAttribute)
                    {
                        type = Type.GetType(reader.Name);
                        if (type != null && (type.IsSubclassOf(typeof(DataStorage)) || type == typeof(DataStorage)))
                            obj = Activator.CreateInstance(type, new object[] { });

                        endELemntName = reader.Name;
                        continue;
                    }

                    if (type == null || obj == null)
                    {
                        throw new Exception("Type Does not exist");
                    }

                    if (obj.GetType().GetProperty(reader.Name) != null)
                    {
                        var propinfo = type.GetProperty(reader.Name);
                        reader.Read();
                        propinfo.SetValue(obj, reader.NodeType == XmlNodeType.Text
                            ? Convert.ChangeType(reader.Value, propinfo.PropertyType)
                            : null);
                    }
                }
            }


            return reader.EOF ? null : (T)obj;
        }

        public static T LoadObject<T>(string path) where T : DataStorage, new()
        {
            T obj;
            using (var reader = XmlReader.Create(path))
            {
                obj = LoadObject<T>(reader);
            }

            return obj;
        }
    }
}
