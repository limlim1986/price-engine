using PriceEngine.Core.Entities;

namespace PriceEngine.Core.Interfaces
{
    public interface IProductVisitor
    {
        void Execute(Product product);
    }
}