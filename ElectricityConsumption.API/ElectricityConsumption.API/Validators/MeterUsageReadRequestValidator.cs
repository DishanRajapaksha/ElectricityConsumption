using ElectricityConsumption.Protos;
using FluentValidation;

namespace ElectricityConsumption.API.Validators;

public class MeterUsageReadRequestValidator : AbstractValidator<MeterUsageReadRequest>
{
	public MeterUsageReadRequestValidator()
	{
		RuleFor(x => x.PageIndex).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
		RuleFor(x => x.PageSize).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0);
	}
}
