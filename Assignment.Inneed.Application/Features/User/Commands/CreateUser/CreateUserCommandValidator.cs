using Assignment.Inneed.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(p => p.FullName)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .NotNull()
           .MaximumLength(70)
           .WithMessage("{PropertyName} must be fewer than 70 characters");
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .EmailAddress()
            .WithMessage("Must be a valid email address");
        RuleFor(q => q)
            .MustAsync(EmailUnique)
            .WithMessage("User already exists");
    }


    private Task<bool> EmailUnique(CreateUserCommand command, CancellationToken token)
    {
        return _userRepository.IsEmailUnique(command.Email);
    }
}
