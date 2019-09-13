using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Internal;

namespace ERPSYS.MVC.Extensions.ModelState
{
    public static class ModelStateExtensions
    {
        public static string GetAllErrors(this ModelStateDictionary modelState)
        {
            var stringBuilder = new StringBuilder();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                    .Select(error => new Error(fieldKey, error.ErrorMessage));
                int index = fieldKey.IndexOf(".");
                string key = fieldKey.Substring(index + 1);
                stringBuilder.AppendLine($"Campo {key} inválido");
            }


            return stringBuilder.ToString();
        }
    }
    
    public class Error
    {
        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }
        public string Key{ get; set; }
        public string Message { get; set; }
    }
}