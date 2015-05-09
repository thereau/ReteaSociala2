using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class CheckDate : ValidationAttribute
    {
        public CheckDate() : base("{0} nu este o data valida")
        {
        }


        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                try
                {
                    var data = value.ToString();
                    string[] dates = data.Split('/');
                    if (dates.Length < 3 || dates.Length < 3)
                    {
                        throw new Exception();
                    }
                    int year = int.Parse(dates[2]);
                    int month = int.Parse(dates[0]);
                    int day = int.Parse(dates[1]);

                    DateTime dataSelectata = new DateTime(year,month,day);


                }
                catch (Exception e)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage); 
                }
            }
            else
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);            
            }
            return ValidationResult.Success;
        }
    }
}