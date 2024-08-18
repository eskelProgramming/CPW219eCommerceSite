namespace CPW219eCommerceSite.Models
{
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int lastPage, int currentPage)
        {
            Games = games;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Game> Games { get; private set; }

        /// <summary>
        /// The last page of the catalog. Calculated by
        /// having a total number of products divided by
        /// products per page. 
        /// </summary>
        public int LastPage { get; private set; }

        public int CurrentPage { get; private set; }
    }
}
