using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Lab7
{
    public sealed class Describer
    {
        private const string template = "{0} {1} {2} {3}\n{{4}\n\n}";
        private const string propTempalte = "{0} {1} {2} {3}";

        public static void WriteDeclaratiuon(object instace)
        {
            var type = instace.GetType().Name == "Type" ? (Type)instace : instace.GetType();
            string accessType;
            if (type.IsPublic)
            {
                accessType = "public";
            }
            else
            {
                accessType = "protected";
            }

            var seales = type.IsSealed ? "sealed" : string.Empty;

            string typeType = "";

            if (type.IsClass)
            {
                typeType = "class";
            }

            if (type.IsInterface)
            {
                typeType = "interface";
            }

            var name = type.Name;
            var propertiesCollection = new List<string>();

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                propertiesCollection.Add(RenderProperty("public", property.PropertyType.Name, property.Name, property.CanRead, property.CanWrite));
            }

            string body = "";
            foreach (var prop in propertiesCollection)
            {
                body += prop + Environment.NewLine;
            }

            var fileBody = string.Format(template, accessType, seales, typeType, name, body);

            System.IO.File.WriteAllText("SomeClass.cs", fileBody);
        }

        private static string RenderProperty(string accessModifier, string returnType, string Name, bool canGet, bool canSet)
        {
            var accessor = "{ " +
                (canGet ? "get; " : string.Empty) +
                (canSet ? "set; " : string.Empty) + "}";
            return string.Format(propTempalte, accessModifier, returnType, Name, accessor);
        }
    }
}
