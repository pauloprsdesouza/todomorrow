using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System;

namespace Todomorrow.Infrastructure.Database.Converters
{
    public sealed class GuidConverter : IPropertyConverter
    {
        public object FromEntry(DynamoDBEntry entry)
        {
            string entryAsString = entry?.AsString();

            return entryAsString == null ? null : Guid.Parse(entryAsString);
        }

        public DynamoDBEntry ToEntry(object value)
        {
            return value.ToString();
        }
    }
}
