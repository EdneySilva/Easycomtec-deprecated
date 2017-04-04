using System;
using System.Linq.Expressions;

namespace Easycomtec.Lib
{
    public interface IValidator
    {
        void Execute(IValidationResult resuldadoGeral);
    }

    public interface IValidator<T> : IValidator
    {
        IValidator<T> Context(T item);
        IValidator<T> Configurate(Expression<Func<T, bool>> configurate);
        IValidator<T> Message(Func<T, string> message);
    }

    public class Validator<T> : IValidator<T>
    {
        T Item { get; set; }
        Expression<Func<T, bool>> Validation { get; set; }
        Func<T, string> MessageBuilder { get; set; }

        public Validator()
        {

        }

        public IValidator<T> Context(T item)
        {
            this.Item = item;
            return this;
        }

        public IValidator<T> Configurate(Expression<Func<T, bool>> configurar)
        {
            Validation = configurar;
            return this;
        }

        public IValidator<T> Message(Func<T, string> mensagem)
        {
            MessageBuilder = mensagem;
            return this;
        }

        public void Execute(IValidationResult result)
        {
            if (this.Validation.Compile().Invoke(this.Item))
                return;
            //result.AdicionarErro(
            //    this.Validation.ToString(),
            //    this.MessageBuilder?.Invoke(this.Item) ??
            //    $"Não foi gerado resultado positivo para: {this.Validation.ToString()}"
            //);
        }
    }
}