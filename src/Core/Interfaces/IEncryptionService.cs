using EnduranceJudge.Core.ConventionalServices;

namespace EnduranceJudge.Core.Interfaces
{
    public interface IEncryptionService : IService
    {
        string Encrypt(string content);

        string Decrypt(string encrypted);
    }
}
