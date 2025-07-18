﻿using FluentValidation;
using FluentValidation.Validators;
using ImperialMarmoraria.Exception;
using System.Text.RegularExpressions;

namespace ImperialMarmoraria.Application.UseCases.User.Register;
public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_MESSAGE_KEY = "ErrorMessage";

    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_MESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password) ||
            password.Length < 8 ||
            !UpperCaseLetter().IsMatch(password) ||
            !LowerCaseLetter().IsMatch(password) ||
            !Numbers().IsMatch(password) ||
            !SpecialSymbols().IsMatch(password)) 
        {
            context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.SENHA_INVALIDA);
            return false;
        }

        return true;
    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseLetter();
    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowerCaseLetter();
    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex Numbers();
    [GeneratedRegex(@"[!?\@#&*\.\-_]+")]
    private static partial Regex SpecialSymbols();
}