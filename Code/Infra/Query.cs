
namespace Abc.Infra;

public sealed class Query(Dictionary<string, string> d = null)
{
    private const string empty = "";
    public Query() : this(null) { }
    public static int[] PageSizes => [7, 15, 25, 50, 100];
    public int Page => toInt(get(nameof(Page)), 1);
    public int PageSize => toInt(get(nameof(PageSize)), PageSizes[0]);
    public string SortBy => get(nameof(SortBy)) ?? empty;
    public string SortDir => get(nameof(SortDir)) ?? empty;
    public string SearchBy => get(nameof(SearchBy)) ?? empty;
    public string Selected => get(nameof(Selected)) ?? empty;
    public string SearchStr => get(nameof(SearchStr)) ?? empty;
    private string get(string s) => (d ?? []).TryGetValue(s, out var x) ? x : null;
    private static int toInt(string s, int def) => int.TryParse(s, out var i) ? i : def;

    private string sort => string.IsNullOrEmpty(SortBy)
        ? string.Empty : $"&{nameof(SortBy)}={SortBy}&{nameof(SortDir)}={SortDir}";
    private string search => string.IsNullOrEmpty(SearchStr)
        ? string.Empty : $"&{nameof(SearchBy)}={SearchBy}&{nameof(SearchStr)}={SearchStr}";
    private string selected(Guid id) => (Selected == id.ToString())
        ? string.Empty : $"&{nameof(Selected)}={id}";
    public string Href(string baseUri, int? page = null, int? pageSize = null)
        => isNull(baseUri) ? empty : $"{baseUri}?{nameof(Page)}={page ?? Page}&{nameof(PageSize)}={pageSize ?? PageSize}{sort}{search}";
    public string Href(string baseUri, Guid id) => isNull(baseUri) ? empty : Href(baseUri) + selected(id);
    private static bool isNull(string s) => string.IsNullOrWhiteSpace(s);
}


