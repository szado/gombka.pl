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

    handleVotes() {
        const upButton = document.querySelector('#thumb-up-button'),
            downButton = document.querySelector('#thumb-down-button'),
            videoId = document.querySelector('#video-id-input').value;

        function onClick() {
            fetch("/videos/vote", {
                method: 'PUT',
                body: JSON.stringify({
                    VideoId: parseInt(videoId),
                    Type: this === upButton ? 0 : 1
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (!response.ok) {
                        alert('Błąd przy zapisie głosu!');
                        return;
                    }

                    console.log(this === downButton, this === upButton, this)
                    downButton.disabled = this === downButton;
                    upButton.disabled = this === upButton;
                });
        }

        upButton.addEventListener('click', onClick);
        downButton.addEventListener('click', onClick);
    }

    matchRoute(route) {
        route = route
            .replaceAll('/', '\/')
            .replaceAll('*', '(.*?)');
        return window.location.pathname.match(new RegExp(`^${route}$`, 'i'));
    }

    init() {
        this.handleSearch();
        if (this.matchRoute('/videos/watch/*')) {
            this.handleVotes();
        }
    }
}

const app = new App;
app.init();