using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Zoo.AnimalMaker.Core.Dto;
using Zoo.AnimalMaker.Core.Exceptions;

namespace Zoo.AnimalMaker.Core.Repositories {
    
    /// <summary>
    /// XML Repository class that will populate Animal properties from an XML file
    /// </summary>
    public class XmlRepository : IAnimalRepository {

        /// <summary>
        /// FeedProperties implementation
        /// </summary>
        /// <param name="animal">Animal implementation that require it's properties need to be populated</param>
        public void FeedProperties(IAnimal animal)
        {
            var xmlFilePath = ConfigurationManager.AppSettings["dataXmlFilePath"] ?? "";

            if (!string.IsNullOrEmpty(xmlFilePath))
            {
                var animalType = animal.GetType().Name;
                var library = GetDataFromXml<List<Animal>>(xmlFilePath);

                if (library != null && library.Any())
                {
                    var dtoAnimal = library.FirstOrDefault(a => a.TypeName.ToLower() == animalType.ToLower());
                    if (dtoAnimal != null)
                    {
                        // Populate property values from the values retrieved from xml
                        animal.TypeName = dtoAnimal.TypeName;
                        animal.NumberOfLegs = dtoAnimal.NumberOfLegs;
                        animal.DailyFeedCost = dtoAnimal.DailyFeedCost;                       
                    }
                }
            }
        }

        /// <summary>
        /// Returns the desirialized object for a given xml file path and the expected object type
        /// </summary>
        /// <typeparam name="T">Type of the expected return object</typeparam>
        /// <param name="strFilePath">Xml data file path</param>
        /// <returns>Object of type T</returns>
        public static T GetDataFromXml<T>(string strFilePath) {
            var xmldoc = new XmlDocument();
            xmldoc.Load(strFilePath.Replace("bin\\debug", ""));
            var result = xmldoc.DeserializeFromXml<T>();
            return (T)result;
        }
    }


    public static class SerializationExtensions
    {
        /// <summary>
        /// Extension method to Deserialize a xml document to an object of the defined type (T)
        /// </summary>
        /// <typeparam name="T">type of the expected deserialized object</typeparam>
        /// <param name="xml">XML file object required to be deserialized</param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(this XmlDocument xml) {

            try {
                XmlSerializer serializer;
                if (xml.DocumentElement != null) {
                    var xRoot = new XmlRootAttribute { ElementName = xml.DocumentElement.Name, IsNullable = true };
                    serializer = new XmlSerializer(typeof(T), xRoot);
                } else
                    serializer = new XmlSerializer(typeof(T));

                using (var reader = new XmlNodeReader(xml)) {
                    var message = serializer.Deserialize(reader);
                    return (T)message;
                }
            } 
            catch (Exception ex)
            {
                throw new AnimalDataXmlDeserializingException(ex);
            }
        }
    }

}
