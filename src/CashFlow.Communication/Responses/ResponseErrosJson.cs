namespace CashFlow.Communication.Responses;

//classe de erros
public class ResponseErrosJson
{
    //para recebermos uma lista de erros é necessario criar dois consstrutores pode podemos receber uma
    // lista e erros ou apenas uma mensagem 
    // para isso a classe pode criar dois construtores um para uma mensagem e um para um alista de erros
    public List<string> ErrorMessages { get; set; }

    public ResponseErrosJson(string errorMessage)
    {
     ErrorMessages = [errorMessage];
    }

    public ResponseErrosJson(List<string> errorMesssage)
    {
        ErrorMessages = errorMesssage;
    }
}
