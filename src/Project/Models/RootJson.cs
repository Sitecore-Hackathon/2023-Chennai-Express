using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SXAHook.Models
{
    public class RootJson
    {
        public string EventName { get; set; }
        public Item Item { get; set; }
        public string WebhookItemId { get; set; }
        public string WebhookItemName { get; set; }
        public string Type { get; set; }
        public DateTime dateTime { get; set; }
    }
    public class Item
    {
        public string Language { get; set; }
        public int Version { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string TemplateId { get; set; }
        public string MasterId { get; set; }
        public List<SharedField> SharedFields { get; set; }
        public List<object> UnversionedFields { get; set; }
        public List<VersionedField> VersionedFields { get; set; }
    }
    public class SharedField
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class VersionedField
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public int Version { get; set; }
        public string Language { get; set; }
    }
}