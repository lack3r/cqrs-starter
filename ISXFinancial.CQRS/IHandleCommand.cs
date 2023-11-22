using System.Collections;

namespace ISXFinancial.CQRS
{
    public interface IHandleCommand<TCommand>
    {
        IEnumerable Handle(TCommand c);
    }
}
