using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace lms.apis.core.Helpers.Processors
{
    public static class XmlProcessor
    {
        public static string TransformToXml<T>(this List<T> itemsList, XmlRootAttribute xmlRootNamespace = null)
        {
            if (xmlRootNamespace == null)
            {
                xmlRootNamespace = new XmlRootAttribute
                {
                    ElementName = itemsList.GetType().ToString(),
                    Namespace = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority),
                    IsNullable = true
                };
            }

            var xmlString = new StringWriter();
            var serializer = new XmlSerializer(itemsList.GetType(), xmlRootNamespace);
            serializer.Serialize(xmlString, itemsList);

            return xmlString.ToString();
        }

    }
}