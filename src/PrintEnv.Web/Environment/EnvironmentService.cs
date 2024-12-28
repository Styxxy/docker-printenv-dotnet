namespace PrintEnv.Web.Environment;

public class EnvironmentService
{
    public Dictionary<string, string> Get()
    {
        var env = System.Environment.GetEnvironmentVariables();
        var enumerator = env.GetEnumerator();
        var result = new Dictionary<string, string>(env.Count);
        while (enumerator.MoveNext()) {
            result[enumerator.Key.ToString()!] = enumerator.Value?.ToString() ?? string.Empty;
        }
        return result;
    }
}
