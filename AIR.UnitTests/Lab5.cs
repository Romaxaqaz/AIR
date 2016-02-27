using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Xsl;
using Domain.Lab1;
using Domain.Lab5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace AIR.UnitTests
{
    [TestClass]
    public class Lab5
    {
        private Fixture fixture;

        [TestInitialize]
        public void Initialize()
        {
            fixture = new Fixture();
        }

        [TestMethod]
        public void Lab5_Anton_Serialize_1()
        {
            const string path = "input.xml";
            var hdd = fixture.Create<Hdd>();
            XmlSerializer.Save(hdd, path);

            var result = XmlSerializer.LoadObject<Hdd>(path);
            File.Delete(path);

            AssertFields(result, hdd);
        }

        [TestMethod]
        public void Lab5_Anton_Serialize_2()
        {
            const string path = "input.xml";
            var hdd = fixture.Create<Hdd>();
            XmlSerializer.Save(hdd, path);

            var result = XmlSerializer.LoadObject<DataStorage>(path);
            File.Delete(path);

            AssertFields(result, hdd);
        }

        [TestMethod]
        public void Lab5_Anton_Serialize3()
        {
            const string path = "input.xml";
            var collection = new Queue<DataStorage>(fixture.CreateMany<Hdd>(3));
            collection.Enqueue(fixture.Create<DataStorage>());
            collection.Enqueue(fixture.Create<Cd>());
            XmlSerializer.Save((IEnumerable<DataStorage>)collection, path);
            var list = XmlSerializer.LoadCollection<DataStorage>(path, x => new Stack<DataStorage>(x));
            File.Delete(path);

            Assert.IsInstanceOfType(list, typeof(Stack<DataStorage>));
            Assert.AreEqual(collection.Count, list.Count());
            for (int i = 0; i < collection.Count; ++i)
            {
                var result = list.ToList()[list.Count() - 1 - i];
                var exp = collection.ToList()[i];
                Assert.IsInstanceOfType(result, exp.GetType());
                AssertFields(result, exp);
            }
        }

        private void AssertFields(object result, object expected)
        {
            foreach (var propertyInfo in result.GetType().GetProperties())
            {
                Assert.AreEqual(expected.GetType().GetProperty(propertyInfo.Name).GetValue(expected),
                    propertyInfo.GetValue(result));
            }
        }

        [TestMethod]
        public void Lab5_GreyWarden_Serialize_Doc_1()
        {
            var xmlDocSerializer = new XmlDocumentSerializer();
            var hdd = fixture.Create<Hdd>();
            var xmlDoc = xmlDocSerializer.Serialize(hdd);

            var capacity = xmlDoc.GetElementsByTagName("Capacity");
            Assert.IsTrue(capacity.Count > 0 && capacity[0].InnerText == hdd.Capacity.ToString());

            var hddInterface = xmlDoc.GetElementsByTagName("Interface");
            Assert.IsTrue(hddInterface.Count > 0 && hddInterface[0].InnerText == hdd.Interface);

            var recordingSpeed = xmlDoc.GetElementsByTagName("RecordingSpeed");
            Assert.IsTrue(recordingSpeed.Count > 0 && recordingSpeed[0].InnerText == hdd.RecordingSpeed.ToString());
        }

        [TestMethod]
        public void Lab5_GreyWarden_Serialize_Doc_2()
        {
            var xmlDocSerializer = new XmlDocumentSerializer();
            var hdd = fixture.Create<Hdd>();
            var xmlDoc = xmlDocSerializer.Serialize(hdd);
            var resultHdd = xmlDocSerializer.Deserialize<Hdd>(xmlDoc);

            Assert.AreEqual(hdd.Capacity, resultHdd.Capacity);
            Assert.AreEqual(hdd.Interface, resultHdd.Interface);
            Assert.AreEqual(hdd.RecordingSpeed, resultHdd.RecordingSpeed);
        }

        [TestMethod]
        public void Lab5_GreyWarden_Serialize_Doc_3()
        {
            var xmlDocSerializer = new XmlDocumentSerializer();
            var list = new List<Hdd> { fixture.Create<Hdd>() };
            var xmlDoc = xmlDocSerializer.Serialize(list);
            var resultList = xmlDocSerializer.Deserialize<List<Hdd>>(xmlDoc);

            Assert.AreEqual(list[0].Capacity, resultList[0].Capacity);
            Assert.AreEqual(list[0].Interface, resultList[0].Interface);
            Assert.AreEqual(list[0].RecordingSpeed, resultList[0].RecordingSpeed);
        }

        [TestMethod]
        public void Lab5_GreyWarden_Serialize_Doc_4()
        {
            var xmlDocSerializer = new XmlDocumentSerializer();
            var list = new List<DataStorage> { fixture.Create<Hdd>(), fixture.Create<Cd>() };
            var xmlDoc = xmlDocSerializer.Serialize(list);
            var resultList = xmlDocSerializer.Deserialize<List<DataStorage>>(xmlDoc);

            Assert.AreEqual(list[0].Capacity, resultList[0].Capacity);
            Assert.AreEqual(list[0].RecordingSpeed, resultList[0].RecordingSpeed);
            Assert.AreEqual(list[1].Capacity, resultList[1].Capacity);
            Assert.AreEqual(list[1].RecordingSpeed, resultList[1].RecordingSpeed);
        }

        [TestMethod]
        public void Lab5_Roma_XDocumentTest_1()
        {
            var cd = fixture.Create<Cd>();
            XDocumentSerializer.Path = "Romaxml1.xml";
            XDocumentSerializer.CreateXMLfromObject<Cd>(cd);
            var getXml = XDocumentSerializer.GetXmlObject<Cd>();
            AssertFields(getXml, cd);
        }

        [TestMethod]
        public void Lab5_Roma_XDocumentTest_2()
        {
            var hdd = fixture.Create<Hdd>();
            XDocumentSerializer.Path = "Romaxml2.xml";
            XDocumentSerializer.CreateXMLfromObject<Hdd>(hdd);
            var res = XDocumentSerializer.GetXmlObject<Hdd>();
            
            Assert.AreEqual(hdd.Capacity, res.Capacity);
            Assert.AreEqual(hdd.Interface, res.Interface);
            Assert.AreEqual(hdd.RecordingSpeed, res.RecordingSpeed);
        }

        [TestMethod]
        public void Lab5_Roma_XDocumentTest_3()
        {
            var collection = new List<DataStorage>();
            collection.Add(fixture.Create<Hdd>());
            collection.Add(fixture.Create<DataStorage>());
            collection.Add(fixture.Create<Cd>());
            collection.Add(fixture.Create<Hdd>());
            collection.Add(fixture.Create<DataStorage>());
            collection.Add(fixture.Create<Cd>());

            XDocumentSerializer.Path = "Romaxml3.xml";
            XDocumentSerializer.CreateXML((IEnumerable<DataStorage>)collection);
            var getXml = XDocumentSerializer.GetXml<DataStorage>();

            Assert.IsTrue(getXml.Count != 0);
        }

        [TestMethod]
        public void Lab5_Roma_xmlToxslt()
        {
            var transformer = new XslCompiledTransform();
            transformer.Load("F:/roma.xslt");
            transformer.Transform("F:/romaXML.xml", "F:/roma.html");
        }

        [TestMethod]
        public void XmlToHtml()
        {
            var transformer = new XslCompiledTransform();
            transformer.Load("Lab5_res/template.xslt");
            transformer.Transform("Lab5_res/ds.xml", "Lab5_res/ds.html");
        }
    }
}
