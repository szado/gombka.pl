class App {
    handleSearch() {
        const searchForm = document.querySelector('form#search-form');

        if (!searchForm) {
            return;
        }

        searchForm.addEventListener('submit', (e) => {
            const querySearch = document.querySelector('input#query-search');

            if (!querySearch.value) {
                e.preventDefault();
            }

        });
    }

    init() {
        this.handleSearch();
    }
}

const app = new App;
app.init();