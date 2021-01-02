using EnduranceContestManager.Core.ConventionalServices;

namespace EnduranceContestManager.Core.Interfaces
{
    public interface IEncryptionService : IService
    {
        string Encrypt(string content);

        string Decrypt(string encrypted);
    }
}