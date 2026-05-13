using Abc.Infra;

namespace Abc.Shared.Code;

public class UrlParams(Uri url)
{
    private readonly Dictionary<string, string> d = [];
    public Abc.Infra.Query Parse()
    {
        var q = url?.Query?.TrimStart('?');
        if (string.IsNullOrEmpty(q)) return new Abc.Infra.Query();
        var pars = q.Split('&', StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in pars) add(p.Split('=', 2));
        return new Abc.Infra.Query(d);
    }
    private void add(string[] pair)
    {
        if (pair.Length != 2) return;
        d[pair[0]] = Uri.UnescapeDataString(pair[1]);
    }
}
