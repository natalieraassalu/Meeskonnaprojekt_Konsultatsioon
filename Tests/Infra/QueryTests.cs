using Abc.Aids;
using Abc.Infra;
using Abc.Tests.Aids;


namespace Abc.Tests.Infra;

    [TestClass]
    public class QueryTests : BaseTests<Query>
    {
        private readonly int[] pageSizes = [7, 15, 25, 50, 100];
        private string baseUrl;
        private Dictionary<string, string> d;
        private Query q;
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            baseUrl = GetRandom.String(3, 10);
            d = new Dictionary<string, string>
            {
                [nameof(Query.Page)] = GetRandom.UInt8(1).ToString(),
                [nameof(Query.PageSize)] = pageSizes[GetRandom.Int32(0, pageSizes.Length)].ToString(),
                [nameof(Query.SortBy)] = GetRandom.String(3, 10),
                [nameof(Query.SortDir)] = GetRandom.Bool() ? "asc" : "desc",
                [nameof(Query.SearchBy)] = GetRandom.String(3, 10),
                [nameof(Query.Selected)] = GetRandom.String(3, 10),
                [nameof(Query.SearchStr)] = GetRandom.String(3, 10)
            };
            q = new Query(d);
        }
        [TestMethod]
        public void PageSizesTest()
        {
            areEqual(pageSizes.Length, Query.PageSizes.Length);
            for (var i = 0; i < pageSizes.Length; i++)
                areEqual(pageSizes[i], Query.PageSizes[i]);
        }
        [TestMethod]
        public void PageTest()
        {
            areEqual(d[nameof(Query.Page)], q.Page.ToString());
            areEqual(1, obj.Page);
        }
        [TestMethod]
        public void PageSizeTest()
        {
            areEqual(d[nameof(Query.PageSize)], q.PageSize.ToString());
            areEqual(pageSizes[0], obj.PageSize);
        }
        [TestMethod]
        public void SortByTest()
        {
            areEqual(d[nameof(Query.SortBy)], q.SortBy);
            areEqual("", obj.SortBy);
        }
        [TestMethod]
        public void SortDirTest()
        {
            areEqual(d[nameof(Query.SortDir)], q.SortDir);
            areEqual("", obj.SortDir);
        }
        [TestMethod]
        public void SearchByTest()
        {
            areEqual(d[nameof(Query.SearchBy)], q.SearchBy);
            areEqual("", obj.SearchBy);
        }
        [TestMethod]
        public void SelectedTest()
        {
            areEqual(d[nameof(Query.Selected)], q.Selected);
            areEqual("", obj.Selected);
        }
        [TestMethod]
        public void SearchStrTest()
        {
            areEqual(d[nameof(Query.SearchStr)], q.SearchStr);
            areEqual("", obj.SearchStr);
        }
        private string buildExpected(int? page = null, int? pageSize = null) => $"{baseUrl}" +
            $"?Page={page?.ToString() ?? d[nameof(Query.Page)]}" +
            $"&PageSize={pageSize?.ToString() ?? d[nameof(Query.PageSize)]}" +
            $"&SortBy={d[nameof(Query.SortBy)]}" +
            $"&SortDir={d[nameof(Query.SortDir)]}" +
            $"&SearchBy={d[nameof(Query.SearchBy)]}" +
            $"&SearchStr={d[nameof(Query.SearchStr)]}";
        private string buildExpected(Guid id) => buildExpected() + $"&Selected={id}";
        [TestMethod]
        public void HrefTest()
        {
            var actual = q.Href(baseUrl);
            var expected = buildExpected();
            areEqual(expected, actual);
            areEqual("", obj.Href(null));
        }
        [TestMethod]
        public void PageHrefTest()
        {
            var page = GetRandom.UInt8(1);
            var pageSize = GetRandom.Int8(5);
            var actual = q.Href(baseUrl, page, pageSize);
            var expected = buildExpected(page, pageSize);
            areEqual(expected, actual);
            areEqual("", obj.Href(null, null, null));
        }
        [TestMethod]
        public void SelectHrefTest()
        {
            var id = GetRandom.Guid();
            var actual = q.Href(baseUrl, id);
            var expected = buildExpected(id);
            areEqual(expected, actual);
            areEqual("", obj.Href(null, Guid.Empty));
        }
    }

