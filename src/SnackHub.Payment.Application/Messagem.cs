namespace SnackHub.Payment.Application;

public class Messagem
{
    public string Code { get; private set; }
    public string Descripion { get; private set; }

    public Messagem(string code, string descripion)
    {
        this.Code = code;
        this.Descripion = descripion;
    }
}