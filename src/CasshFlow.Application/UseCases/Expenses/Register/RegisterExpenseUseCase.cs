﻿using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        ValidateForm(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void ValidateForm(RequestRegisterExpenseJson request)
    {
     var validator = new RegisterExpenseValidator();

     var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
      

            throw new ErrorOnValidationException(errorMessages);

        }


    }
}
