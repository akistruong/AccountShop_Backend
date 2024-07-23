using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace AccountShop.Shared.Validators
{
    public class RuleBuilder<TProperty>
    {
        private readonly IValidator validator;
        private readonly TProperty property;

        public RuleBuilder(IValidator validator, TProperty property)
        {
            this.validator = validator;
            this.property = property;
        }

        public RuleBuilder<TProperty> NotNull(string? message = null)
        {
            bool Func(TProperty b) => property is not null && !property.Equals(default);
            message = message ?? "";
            var rule = new Rule<TProperty>(Func, property, message);
            this.validator.AddRule(rule);
            return this;
        }

        public RuleBuilder<TProperty> Must(Func<TProperty, bool> predicate, string? message = null)
        {
            message = message ?? "";
            var rule = new Rule<TProperty>(predicate, property, message);
            this.validator.AddRule(rule);
            return this;
        }
    }
}