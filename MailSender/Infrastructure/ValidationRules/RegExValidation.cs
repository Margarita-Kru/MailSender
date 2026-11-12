using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.Infrastructure.ValidationRules
{
    class RegExValidation: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return AllowNull ? ValidationResult.ValidResult : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет требованиям {Pattern}");
            if (_Regex is null) return ValidationResult.ValidResult;
            if (value is not string str)
                str = value.ToString();
            return _Regex.IsMatch(str) ? ValidationResult.ValidResult : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет требованиям {Pattern}");
        }
        private Regex _Regex;
        public string Pattern
        {
            get => _Regex.ToString();
            set => _Regex = string.IsNullOrEmpty(value) ? null : new(value);
        }
        public bool AllowNull { get; set; }
        public string ErrorMessage { get; set; }

    }
}
