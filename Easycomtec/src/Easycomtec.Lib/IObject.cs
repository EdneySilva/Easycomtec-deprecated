namespace Easycomtec.Lib
{
    public interface IObject
    {
        IValidationResult Validate(IAssert assert);
    }
}