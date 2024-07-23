using AccountShop.Abtractions.Entity;
using AccountShop.Shared.Extentions;
using System.Linq.Expressions;

namespace AccountShop.Shared.Validators
{
    public interface IValidator
    {
        public void AddRule(IRule rule);
    }

    public class Validator<TEntity> : IValidator
    {
        private readonly List<IRule> rules = new();
        private readonly List<string> errorMessages = new();
        private readonly TEntity entity;

        public Validator(TEntity entity)
        {
            this.entity = entity;
        }

        public void Validate()
        {
            foreach (var rule in rules)
                if (!rule.Validate()) errorMessages.Add(rule.Message);
            if (errorMessages.Any()) throw new ValidationException("Validate Exception");
        }

        public void AddRule(IRule rule)
        {
            rules.Add(rule);
        }

        public RuleBuilder<TProperty> RuleFor<TProperty>(Expression<Func<TEntity, TProperty>> predicate)
        {
            var func = predicate.Compile();
            var ruleBuilder = new RuleBuilder<TProperty>(this, func.Invoke(entity));
            return ruleBuilder;
        }
    }

    public class Validator
    {
        public static Validator<TEntity> Create<TEntity>(TEntity entity)
        {
            return new Validator<TEntity>(entity);
        }
    }
}