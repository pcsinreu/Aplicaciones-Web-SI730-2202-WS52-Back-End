namespace LearningCenter.Domain;

public interface IEncryptDomain
{
    string Ecnrypt(string password);
    string Decrypt(string paswordEncrypted);
}