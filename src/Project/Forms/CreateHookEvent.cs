using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SXAHook.Forms
{
    public class CreateHookEvent : SubmitActionBase<string>
    {
        public CreateHookEvent(ISubmitActionData submitActionData) : base(submitActionData)
        {

        }

        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull((object)formSubmitContext, nameof(formSubmitContext));

            return this.CreateHookEventData(formSubmitContext.FormId, formSubmitContext.SessionId, formSubmitContext.Fields);
        }

        protected virtual bool CreateHookEventData(Guid formId, Guid sessionId, IList<IViewModel> postedFields)
        {
            ChannelData data = new ChannelData();
            try
            {
                foreach (var field in postedFields)
                {
                    if (field.Name == "rdoType")
                    {
                        data.Type = GetValue(field);
                    }
                    else if (field.Name == "txtName")
                    {
                        data.Name = GetValue(field);
                    }

                    else if (field.Name == "txtEndPoint")
                    {
                        data.EndPoint = GetValue(field);
                    }
                    else if (field.Name == "txtTokenID")
                    {
                        data.TokenID = GetValue(field);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex, (object)this);
                return false;
            }
        }
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        public string GetValue(IViewModel postedField)
        {
            Assert.ArgumentNotNull((object)postedField, "postedField");
            IValueField valueField = postedField as IValueField;
            PropertyInfo property = postedField.GetType().GetProperty("Value");
            object obj;
            if (property == null)
            {
                obj = (object)null;
            }
            else
            {
                IViewModel viewModel = postedField;
                obj = property.GetValue((object)viewModel);
            }
            object postedValue = obj;
            if (postedValue == null)
                return string.Empty;
            string parsedValue = ParseFieldValue(postedValue);

            return parsedValue;
        }

        protected static string ParseFieldValue(object postedValue)
        {
            Assert.ArgumentNotNull(postedValue, "postedValue");
            List<string> list = new List<string>();
            IList secondList = postedValue as IList;
            if (secondList != null)
            {
                foreach (object obj in (IEnumerable)secondList)
                    list.Add(obj.ToString());
            }
            else
                list.Add(postedValue.ToString());
            return string.Join(",", (IEnumerable<string>)list);
        }

        public class ChannelData
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string EndPoint { get; set; }
            public string TokenID { get; set; }
        }
    }
}