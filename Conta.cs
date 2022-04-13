public class Conta
{
    public int Codigo { get; }
    public double Saldo { get; private set; }
    
    public Conta(int codigo)
    {
        Codigo = codigo;
        Saldo = 0.0;
    }

    public void Sacar(double valor)
    {
        ValidarValor(valor);
        VerificarSaldo(valor);
        Saldo -= valor;
    }

    public void Depositar(double valor)
    {
        ValidarValor(valor);
        Saldo += valor;
    }

    public void Transferir(double valor, Conta conta)
    {
        ValidarValor(valor);
        VerificarSaldo(valor);

        Saldo -= valor;
        conta.Saldo += valor;

        //não precisa da validação, pois os métodos Sacar e Depositar estão sendo chamados
        //Sacar(valor);
        //conta.Depositar(valor);
    }

    private void ValidarValor(double valor)
    {
        if(valor <= 0.0) throw new ArgumentException("Valor deve ser maior que zero.");
    }

    private void VerificarSaldo(double valor)
    {
        if(valor > Saldo) throw new ArgumentException("Saldo insuficiente.");
    }
}