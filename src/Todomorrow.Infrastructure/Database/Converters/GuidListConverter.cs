using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Todomorrow.Infrastructure.Database.Converters
{
    public class GuidListConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            if (value == null)
                return new DynamoDBNull();

            List<Guid> guidList = (List<Guid>)value;
            IEnumerable<string> stringGuidList = guidList.ConvertAll(guid => guid.ToString());

            return stringGuidList.ToArray();
        }

        public object FromEntry(DynamoDBEntry entry)
        {
            List<string> stringGuidList = entry.AsListOfString();
            List<Guid> guidList = stringGuidList.ConvertAll(strGuid => Guid.Parse(strGuid));

            return guidList;
        }
    }
}