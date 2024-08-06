namespace AccountShop.Shared.Validators
{
    public interface IRule
    {
        public bool Validate();

        public string Message { get; }
    }

    public class Rule<TProperty> : IRule
    {
        public Func<TProperty, bool> validationFunc;
        private TProperty _property;

        public Rule(Func<TProperty, bool> validationFunc, TProperty property, string message)
        {
            this.validationFunc = validationFunc;
            _property = property;
            Message = message;
        }

        public string Message { get; }

        public bool Validate()
        {
            return validationFunc.Invoke(_property);
        }
    }
}