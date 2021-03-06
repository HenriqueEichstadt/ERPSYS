﻿using ERPSYS.MVC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSYS.Common
{
    public class EntityValidationResultFactory : IEntityValidationResultFactory
    {
        private StringBuilder _validationMessage;

        public EntityValidationResultFactory()
        {
            _validationMessage = new StringBuilder();
        }

        public void NewResult(string message)
        {
            _validationMessage.AppendLine(message);
        }

        public string GetValidationMessage()
        {
            return _validationMessage.ToString();
        }
    }
}
